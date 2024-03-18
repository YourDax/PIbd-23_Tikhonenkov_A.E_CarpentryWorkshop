using CarpentryWorkshopDataModels.Models;
using System.ComponentModel;

namespace CarpentryWorkshopContracts.ViewModels
{
    public class ShopViewModel : IShopModel
    {
        public int Id { get; set; }
        [DisplayName("Название магазина")]
        public string ShopName { get; set; }
        [DisplayName("Адрес магазина")]
        public string Address { get; set; }
        [DisplayName("Дата открытия")]
        public DateTime DateOpen { get; set; }
        public Dictionary<int, (IWoodModel, int)> ShopWoods { get; set; } = new();
    }
}
