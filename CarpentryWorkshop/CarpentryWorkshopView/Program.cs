using CarpentryWorkshopBusinessLogic.BusinessLogics;
using CarpentryWorkshopBusinessLogic.OfficePackage.Implements;
using CarpentryWorkshopBusinessLogic.OfficePackage;
using CarpentryWorkshopContracts.BusinessLogicsContracts;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopDatabaseImplement.Implements;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using CarpentryWorkshopView;

namespace CarpentryWorkshopView
{
    internal static class Program
    {
        private static ServiceProvider? _serviceProvider;
        public static ServiceProvider? ServiceProvider => _serviceProvider;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
            Application.Run(_serviceProvider.GetRequiredService<FormMain>());
        }
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(option =>
            {
                option.SetMinimumLevel(LogLevel.Information);
                option.AddNLog("nlog.config");
            });
            services.AddTransient<IComponentStorage, ComponentStorage>();
            services.AddTransient<IOrderStorage, OrderStorage>();
            services.AddTransient<IWoodStorage, WoodStorage>();
            services.AddTransient<IShopStorage, ShopStorage>();

            services.AddTransient<IComponentLogic, ComponentLogic>();
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<IWoodLogic, WoodLogic>();
            services.AddTransient<IShopLogic, ShopLogic>();

            services.AddTransient<IReportLogic, ReportLogic>();

            services.AddTransient<AbstractSaveToExcel, SaveToExcel>();
            services.AddTransient<AbstractSaveToWord, SaveToWord>();
            services.AddTransient<AbstractSaveToPdf, SaveToPdf>();

            services.AddTransient<FormMain>();
            services.AddTransient<FormComponent>();
            services.AddTransient<FormComponents>();
            services.AddTransient<FormCreateOrder>();
            services.AddTransient<FormWood>();
            services.AddTransient<FormWoodComponent>();
            services.AddTransient<FormWoods>();
            services.AddTransient<FormShop>();
            services.AddTransient<FormShops>();
            services.AddTransient<FormSupply>();
            services.AddTransient<FormSell>();
            services.AddTransient<FormReportWoodComponents>();
            services.AddTransient<FormReportOrders>();
        }
    }
}