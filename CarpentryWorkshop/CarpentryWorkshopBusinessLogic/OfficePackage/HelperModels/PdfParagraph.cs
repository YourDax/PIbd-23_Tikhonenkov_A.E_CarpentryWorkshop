using CarpentryWorkshopBusinessLogic.OfficePackage.HelperEnums;

namespace CarpentryWorkshopBusinessLogic.OfficePackage.HelperModels
{
    public class PdfParagraph
    {
        public string Text { get; set; } = string.Empty;

        public string Style { get; set; } = string.Empty;

        public PdfParagraphAlignmentType ParagraphAlignment { get; set; }
    }
}