using CarpentryWorkshopDataModels.Models;

namespace CarpentryWorkshopContracts.BindingModels
{
    public class SupplyBindingModel : ISupplyModel
    {
        public int ShopId { get; set; }
        public int WoodId { get; set; }
        public int Count { get; set; }
    }
}
