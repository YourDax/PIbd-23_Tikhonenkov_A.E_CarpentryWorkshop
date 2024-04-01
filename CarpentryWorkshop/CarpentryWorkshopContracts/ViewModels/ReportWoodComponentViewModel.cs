namespace CarpentryWorkshopContracts.ViewModels
{
    public class ReportWoodComponentViewModel
    {
        public string WoodName { get; set; } = string.Empty;

        public int TotalCount { get; set; }

        public List<(string Component, int Count)> Components { get; set; } = new();
    }
}