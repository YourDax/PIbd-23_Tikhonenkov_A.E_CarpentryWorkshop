using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopDatabaseImplement.Models
{
    public class Shop : IShopModel
    {
        public int Id { get; set; }

        [Required]
        public string ShopName { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public DateTime DateOpen { get; set; }

        [Required]
        public int WoodMaxCount { get; set; }

        [ForeignKey("ShopId")]
        public List<ShopWood> Woods { get; set; } = new();

        private Dictionary<int, (IWoodModel, int)>? _shopWoods = null;

        [NotMapped]
        public Dictionary<int, (IWoodModel, int)> ShopWoods
        {
            get
            {
                if (_shopWoods == null)
                {
                    _shopWoods = Woods
                    .ToDictionary(x => x.WoodId, x =>
                   (x.Wood as IWoodModel, x.Count));
                }
                return _shopWoods;
            }
        }

        public static Shop? Create(CarpentryWorkshopDatabase context, ShopBindingModel model)
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
                Woods = model.ShopWoods.Select(x => new ShopWood
                {
                    Wood = context.Woods.First(y => y.Id == x.Key),
                    Count = x.Value.Item2
                }).ToList()
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
            WoodMaxCount = model.WoodMaxCount;
        }

        public ShopViewModel GetViewModel => new()
        {
            Id = Id,
            ShopName = ShopName,
            Address = Address,
            DateOpen = DateOpen,
            ShopWoods = ShopWoods,
            WoodMaxCount = WoodMaxCount
        };

        public void UpdateWoods(CarpentryWorkshopDatabase context,
       ShopBindingModel model)
        {
            var shopWoods = context.ShopWoods.Where(rec =>
           rec.ShopId == model.Id).ToList();
            if (shopWoods != null && shopWoods.Count > 0)
            {
                context.ShopWoods.RemoveRange(shopWoods.Where(rec => !model.ShopWoods.ContainsKey(rec.WoodId)));

                context.SaveChanges();
                foreach (var updateWood in shopWoods)
                {
                    updateWood.Count =
                   model.ShopWoods[updateWood.WoodId].Item2;
                    model.ShopWoods.Remove(updateWood.WoodId);
                }
                context.SaveChanges();
            }
            var shop = context.Shops.First(x => x.Id == Id);
            foreach (var pc in model.ShopWoods)
            {
                context.ShopWoods.Add(new ShopWood
                {
                    Shop = shop,
                    Wood = context.Woods.First(x => x.Id == pc.Key),
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            _shopWoods = null;
        }
        public void WoodsDictionatyUpdate(CarpentryWorkshopDatabase context)
        {
            UpdateWoods(context, new ShopBindingModel
            {
                Id = Id,
                ShopWoods = ShopWoods,
            });
        }
    }
}
