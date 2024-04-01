using CarpentryWorkshopContracts.ViewModels;

namespace CarpentryWorkshopBusinessLogic.OfficePackage.HelperModels
{
    public class ExcelInfo
    {
        public string FileName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public List<ReportWoodComponentViewModel> WoodComponents { get; set; } = new();
    }
}