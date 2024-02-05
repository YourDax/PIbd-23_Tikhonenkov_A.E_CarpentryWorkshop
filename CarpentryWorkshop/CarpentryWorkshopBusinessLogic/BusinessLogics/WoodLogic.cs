using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.BusinessLogicsContracts;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopContracts.ViewModels;
using Microsoft.Extensions.Logging;


namespace CarpentryWorkshopBusinessLogic.BusinessLogics
{
    public class WoodLogic : IWoodLogic
    {
        private readonly ILogger _logger;
        private readonly IWoodStorage _woodStorage;
        public WoodLogic(ILogger<WoodLogic> logger, IWoodStorage woodStorage)
        {
            _logger = logger;
            _woodStorage = woodStorage;
        }
        public List<WoodViewModel>? ReadList(WoodSearchModel? model)
        {
            _logger.LogInformation("ReadList. WoodName:{WoodName}. Id:{ Id}", model?.WoodName, model?.Id);
            var list = model == null ? _woodStorage.GetFullList() : _woodStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }
        public WoodViewModel? ReadElement(WoodSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. WoodName:{WoodName}. Id:{ Id}", model.WoodName, model.Id);
            var element = _woodStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }
        public bool Create(WoodBindingModel model)
        {
            CheckModel(model);
            if (_woodStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }
        public bool Update(WoodBindingModel model)
        {
            CheckModel(model);
            if (_woodStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }
        public bool Delete(WoodBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_woodStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }
        private void CheckModel(WoodBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.WoodName))
            {
                throw new ArgumentNullException("Нет названия компонента", nameof(model.WoodName));
            }
            if (model.Price <= 0)
            {
                throw new ArgumentNullException("Цена компонента должна быть больше 0", nameof(model.Price));
            }
            _logger.LogInformation("Wood. WoodName:{WoodName}. Cost:{ Cost}. Id: { Id}", model.WoodName, model.Price, model.Id);
            var element = _woodStorage.GetElement(new WoodSearchModel
            {
                WoodName = model.WoodName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Компонент с таким названием уже есть");
            }
        }
    }
}
