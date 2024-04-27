using CarpentryWorkshopDataModels.Enums;

namespace CarpentryWorkshopContracts.ViewModels
{
    public class ReportOrdersViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreate { get; set; }

        public string WoodName { get; set; } = string.Empty;

        public double Sum { get; set; }
        public string Status { get; set; } = string.Empty ;
    }
}