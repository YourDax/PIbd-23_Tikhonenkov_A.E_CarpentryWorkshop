using CarpentryWorkshopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopBusinessLogic.OfficePackage.HelperModels
{
    public class WordShopInfo : IDocument
    {
        public string FileName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public List<ShopViewModel> Shops { get; set; } = new();
    }
}
