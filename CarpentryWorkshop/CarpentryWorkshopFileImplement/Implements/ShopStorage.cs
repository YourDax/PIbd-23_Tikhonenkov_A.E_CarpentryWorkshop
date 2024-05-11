using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopFileImplement.Implements
{
    public class ShopStorage : IShopStorage
    {
        private readonly DataFileSingleton source;

        public ShopStorage()
        {
            source = DataFileSingleton.GetInstance();
        }

        public List<ShopViewModel> GetFullList()
        {
            return source.Shops.Select(x => x.GetViewModel).ToList();
        }

        public List<ShopViewModel> GetFilteredList(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName))
            {
                return new();
            }
            return source.Shops.Where(x => x.ShopName.Contains(model.ShopName)).Select(x => x.GetViewModel).ToList();
        }

        public ShopViewModel? GetElement(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName) && !model.Id.HasValue)
            {
                return null;
            }
            return source.Shops.FirstOrDefault(x =>
            (!string.IsNullOrEmpty(model.ShopName) && x.ShopName == model.ShopName) ||
            (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        public ShopViewModel? Insert(ShopBindingModel model)
        {
            model.Id = source.Shops.Count > 0 ? source.Shops.Max(x => x.Id) + 1 : 1;
            var newShop = Shop.Create(model);
            if (newShop == null)
            {
                return null;
            }
            source.Shops.Add(newShop);
            source.SaveShops();
            return newShop.GetViewModel;
        }

        public ShopViewModel? Update(ShopBindingModel model)
        {
            var shop = source.Shops.FirstOrDefault(x => x.Id == model.Id);
            if (shop == null)
            {
                return null;
            }
            shop.Update(model);
            source.SaveShops();
            return shop.GetViewModel;
        }

        public ShopViewModel? Delete(ShopBindingModel model)
        {
            var shop = source.Shops.FirstOrDefault(x => x.Id == model.Id);
            if (shop != null)
            {
                source.Shops.Remove(shop);
                source.SaveShops();
                return shop.GetViewModel;
            }
            return null;
        }

        public bool Sale(SupplySearchModel model)
        {
            if (model == null || !model.WoodId.HasValue || !model.Count.HasValue)
                return false;
            int remainingSpace = source.Shops.Select(x => x.Woods.ContainsKey(model.WoodId.Value) ? x.Woods[model.WoodId.Value] : 0).Sum();
            if (remainingSpace < model.Count)
            {
                return false;
            }
            var shops = source.Shops.Where(x => x.Woods.ContainsKey(model.WoodId.Value)).OrderByDescending(x => x.Woods[model.WoodId.Value]).ToList();
            foreach (var shop in shops)
            {
                int residue = model.Count.Value - shop.Woods[model.WoodId.Value];
                if (residue > 0)
                {
                    shop.Woods.Remove(model.WoodId.Value);
                    shop.WoodsUpdate();
                    model.Count = residue;
                }
                else
                {
                    if (residue == 0)
                    {
                        shop.Woods.Remove(model.WoodId.Value);
                    }
                    else
                    {
                        shop.Woods[model.WoodId.Value] = -residue;
                    }
                    shop.WoodsUpdate();
                    source.SaveShops();
                    return true;
                }
            }
            source.SaveShops();
            return false;
        }

        public bool RestockingShops(SupplyBindingModel model)
        {
            if (model == null || source.Shops.Select(x => x.WoodMaxCount - x.ShopWoods.Select(y => y.Value.Item2).Sum()).Sum() < model.Count)
            {
                return false;
            }
            foreach (Shop shop in source.Shops)
            {
                int free_places = shop.WoodMaxCount - shop.ShopWoods.Select(x => x.Value.Item2).Sum();
                if (free_places <= 0)
                    continue;
                free_places = Math.Min(free_places, model.Count);
                model.Count -= free_places;
                if (shop.Woods.ContainsKey(model.WoodId))
                {
                    shop.Woods[model.WoodId] += free_places;
                }
                else
                {
                    shop.Woods.Add(model.WoodId, free_places);
                }
                shop.WoodsUpdate();
                if (model.Count == 0)
                {
                    source.SaveShops();
                    return true;
                }
            }
            return false;
        }
    }
}