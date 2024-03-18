using CarpentryWorkshopDataModels.Models;

namespace CarpentryWorkshopContracts.BindingModels
{
    public class ShopBindingModel : IShopModel
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public DateTime DateOpen { get; set; }
        public Dictionary<int, (IWoodModel, int)> ShopWoods { get; set; } = new();
    }
}
