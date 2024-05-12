using CarpentryWorkshopBusinessLogic.BusinessLogics;
using CarpentryWorkshopBusinessLogic.OfficePackage.Implements;
using CarpentryWorkshopBusinessLogic.OfficePackage;
using CarpentryWorkshopContracts.BusinessLogicsContracts;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopDatabaseImplement.Implements;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using CarpentryWorkshopBusinessLogic.MailWorker;
using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.DI;


namespace CarpentryWorkshopView
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            InitDependency();
            try
            {
                var mailSender = DependencyManager.Instance.Resolve<AbstractMailWorker>();
                mailSender?.MailConfig(new MailConfigBindingModel
                {
                    MailLogin = System.Configuration.ConfigurationManager.AppSettings["MailLogin"] ?? string.Empty,
                    MailPassword = System.Configuration.ConfigurationManager.AppSettings["MailPassword"] ?? string.Empty,
                    SmtpClientHost = System.Configuration.ConfigurationManager.AppSettings["SmtpClientHost"] ?? string.Empty,
                    SmtpClientPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SmtpClientPort"]),
                    PopHost = System.Configuration.ConfigurationManager.AppSettings["PopHost"] ?? string.Empty,
                    PopPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PopPort"])
                });

                var timer = new System.Threading.Timer(new TimerCallback(MailCheck!), null, 0, 100000);
            }
            catch (Exception ex)
            {
                var logger = DependencyManager.Instance.Resolve<ILogger>();
                logger?.LogError(ex, "Error");
            }
            Application.Run(DependencyManager.Instance.Resolve<FormMain>());
        }
        private static void InitDependency()
        {
            DependencyManager.InitDependency();

            DependencyManager.Instance.AddLogging(option =>
            {
                option.SetMinimumLevel(LogLevel.Information);
                option.AddNLog("nlog.config");
            });
            DependencyManager.Instance.RegisterType<IComponentStorage, ComponentStorage>();
            DependencyManager.Instance.RegisterType<IOrderStorage, OrderStorage>();
            DependencyManager.Instance.RegisterType<IWoodStorage, WoodStorage>();
            DependencyManager.Instance.RegisterType<IClientStorage, ClientStorage>();
            DependencyManager.Instance.RegisterType<IImplementerStorage, ImplementerStorage>();
            DependencyManager.Instance.RegisterType<IMessageInfoStorage, MessageInfoStorage>();
            DependencyManager.Instance.RegisterType<IBackUpLogic, BackUpLogic>();

            DependencyManager.Instance.RegisterType<IComponentLogic, ComponentLogic>();
            DependencyManager.Instance.RegisterType<IOrderLogic, OrderLogic>();
            DependencyManager.Instance.RegisterType<IWoodLogic, WoodLogic>();
            DependencyManager.Instance.RegisterType<IReportLogic, ReportLogic>();
            DependencyManager.Instance.RegisterType<IClientLogic, ClientLogic>();
            DependencyManager.Instance.RegisterType<IImplementerLogic, ImplementerLogic>();
            DependencyManager.Instance.RegisterType<IMessageInfoLogic, MessageInfoLogic>();
            DependencyManager.Instance.RegisterType<IWorkProcess, WorkModeling>();
            DependencyManager.Instance.RegisterType<AbstractMailWorker, MailKitWorker>(true);

            DependencyManager.Instance.RegisterType<AbstractSaveToExcel, SaveToExcel>();
            DependencyManager.Instance.RegisterType<AbstractSaveToWord, SaveToWord>();
            DependencyManager.Instance.RegisterType<AbstractSaveToPdf, SaveToPdf>();

            DependencyManager.Instance.RegisterType<FormMain>();
            DependencyManager.Instance.RegisterType<FormClients>();
            DependencyManager.Instance.RegisterType<FormComponent>();
            DependencyManager.Instance.RegisterType<FormComponents>();
            DependencyManager.Instance.RegisterType<FormCreateOrder>();
            DependencyManager.Instance.RegisterType<FormWood>();
            DependencyManager.Instance.RegisterType<FormWoodComponent>();
            DependencyManager.Instance.RegisterType<FormWoods>();
            DependencyManager.Instance.RegisterType<FormReportWoodComponents>();
            DependencyManager.Instance.RegisterType<FormReportOrders>();
            DependencyManager.Instance.RegisterType<FormImplementer>();
            DependencyManager.Instance.RegisterType<FormImplementers>();
            DependencyManager.Instance.RegisterType<FormMail>();
        }
        private static void MailCheck(object obj) => DependencyManager.Instance.Resolve<AbstractMailWorker>()?.MailCheck();
    }
}