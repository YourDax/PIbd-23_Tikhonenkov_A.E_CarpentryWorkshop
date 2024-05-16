using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarpentryWorkshopContracts.ViewModels;

namespace CarpentryWorkshopBusinessLogic.OfficePackage.HelperModels
{
    public class ExcelShop : IDocument
    {
        public string FileName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public List<ReportShopsViewModel> ShopWoods { get; set; } = new();
    }
}
