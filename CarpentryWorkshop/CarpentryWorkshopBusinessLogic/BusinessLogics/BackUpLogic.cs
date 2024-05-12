using Microsoft.Extensions.Logging;
using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.BusinessLogicsContracts;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopDataModels;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.Serialization.Json;

namespace CarpentryWorkshopBusinessLogic.BusinessLogics
{
    public class BackUpLogic : IBackUpLogic
    {
        private readonly ILogger _logger;

        private readonly IBackUpInfo _backUpInfo;

        public BackUpLogic(ILogger<BackUpLogic> logger, IBackUpInfo backUpInfo)
        {
            _logger = logger;
            _backUpInfo = backUpInfo;
        }

        public void CreateBackUp(BackUpSaveBinidngModel model)
        {
            if (_backUpInfo == null)
            {
                return;
            }
            try
            {
                _logger.LogDebug("Clear folder");
                var dirInfo = new DirectoryInfo(model.FolderName);
                if (dirInfo.Exists)
                {
                    foreach (var file in dirInfo.GetFiles())
                    {
                        file.Delete();
                    }
                }
                _logger.LogDebug("Delete archive");
                string fileName = $"{model.FolderName}.zip";
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                _logger.LogDebug("Get assembly");
                var typeIId = typeof(IId);
                var assembly = typeIId.Assembly;
                if (assembly == null)
                {
                    throw new ArgumentNullException("Сборка не найдена", nameof(assembly));
                }
                var types = assembly.GetTypes();
                var method = GetType().GetMethod("SaveToFile", BindingFlags.NonPublic | BindingFlags.Instance);
                _logger.LogDebug("Find {count} types", types.Length);
                foreach (var type in types)
                {
                    if (type.IsInterface && type.GetInterface(typeIId.Name) != null)
                    {
                        var modelType = _backUpInfo.GetTypeByModelInterface(type.Name);
                        if (modelType == null)
                        {
                            throw new InvalidOperationException($"Не найден класс-модель для {type.Name}");
                        }
                        _logger.LogDebug("Call SaveToFile method for {name} type", type.Name);
                        method?.MakeGenericMethod(modelType).Invoke(this, new object[] { model.FolderName });
                    }
                }
                _logger.LogDebug("Create zip and remove folder");
                ZipFile.CreateFromDirectory(model.FolderName, fileName);
                dirInfo.Delete(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SaveToFile<T>(string folderName) where T : class, new()
        {
            var records = _backUpInfo.GetList<T>();
            if (records == null)
            {
                _logger.LogWarning("{type} type get null list", typeof(T).Name);
                return;
            }
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));
            using var fs = new FileStream(string.Format("{0}/{1}.json", folderName, typeof(T).Name), FileMode.OpenOrCreate);
            jsonFormatter.WriteObject(fs, records);
        }
    }
}
