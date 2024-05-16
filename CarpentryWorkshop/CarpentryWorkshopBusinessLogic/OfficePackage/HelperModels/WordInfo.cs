using CarpentryWorkshopContracts.ViewModels;

namespace CarpentryWorkshopBusinessLogic.OfficePackage.HelperModels
{
    public class WordInfo : IDocument
    {
        public string FileName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public List<WoodViewModel> Woods { get; set; } = new();
    }
}