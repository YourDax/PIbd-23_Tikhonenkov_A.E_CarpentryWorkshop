using CarpentryWorkshopDataModels.Models;

namespace CarpentryWorkshopContracts.BindingModels
{
    public class ShopBindingModel : IShopModel
    {
        public int Id { get; set; }
        public string ShopName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime DateOpen { get; set; }
        public Dictionary<int, (IWoodModel, int)> ShopWoods { get; set; } = new();
        public int WoodMaxCount { get; set; }
    }
}
