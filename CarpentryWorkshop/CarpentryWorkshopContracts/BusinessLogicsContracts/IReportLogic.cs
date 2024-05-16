using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.ViewModels;

namespace CarpentryWorkshopContracts.BusinessLogicsContracts
{
    public interface IReportLogic
    {
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        List<ReportWoodComponentViewModel> GetWoodComponent();

        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);

        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        void SaveComponentsToWordFile(ReportBindingModel model);

        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        void SaveWoodComponentToExcelFile(ReportBindingModel model);

        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        void SaveOrdersToPdfFile(ReportBindingModel model);

        List<ReportShopsViewModel> GetShops();
        List<ReportGroupOrdersViewModel> GetGroupedOrders();
        void SaveShopsToWordFile(ReportBindingModel model);
        void SaveShopsToExcelFile(ReportBindingModel model);
        void SaveGroupedOrdersToPdfFile(ReportBindingModel model);
    }
}