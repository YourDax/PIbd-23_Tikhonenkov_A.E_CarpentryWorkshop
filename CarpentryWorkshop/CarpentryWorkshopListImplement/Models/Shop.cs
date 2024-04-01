using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopListImplement.Models
{
    public class Shop : IShopModel
    {
        public int Id { get; private set; }
        public string ShopName { get; private set; }
        public string Address { get; private set; }
        public DateTime DateOpen { get; private set; }
        public Dictionary<int, (IWoodModel, int)> ShopWoods { get; private set; } = new();
        public int WoodMaxCount { get; private set; }

        public static Shop? Create(ShopBindingModel model)
        {
            if (model == null)
                return null;
            return new Shop()
            {
                Id = model.Id,
                ShopName = model.ShopName,
                Address = model.Address,
                DateOpen = model.DateOpen,
                WoodMaxCount = model.WoodMaxCount,
            };
        }

        public void Update(ShopBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            ShopName = model.ShopName;
            Address = model.Address;
            DateOpen = model.DateOpen;
        }

        public ShopViewModel GetViewModel => new()
        {
            Id = Id,
            ShopName = ShopName,
            Address = Address,
            DateOpen = DateOpen,
            ShopWoods = ShopWoods
        };
    }
}
