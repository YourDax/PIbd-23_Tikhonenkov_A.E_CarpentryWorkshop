using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDatabaseImplement.Models;
using CarpentryWorkshopDataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopDatabaseImplement.Implements
{
    public class ShopStorage : IShopStorage
    {
        public ShopViewModel? Delete(ShopBindingModel model)
        {
            using var context = new CarpentryWorkshopDatabase();
            var element = context.Shops.FirstOrDefault(x => x.Id == model.Id);
            if (element != null)
            {
                context.Shops.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }

        public ShopViewModel? GetElement(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new CarpentryWorkshopDatabase();
            return context.Shops
                .Include(x => x.Woods)
                .ThenInclude(x => x.Wood)
                .FirstOrDefault(x => model.Id.HasValue && x.Id == model.Id)
                ?.GetViewModel;
        }

        public List<ShopViewModel> GetFilteredList(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName))
            {
                return new();
            }
            using var context = new CarpentryWorkshopDatabase();
            return context.Shops
                .Include(x => x.Woods)
                .ThenInclude(x => x.Wood)
                .Select(x => x.GetViewModel)
                .Where(x => x.ShopName.Contains(model.ShopName ?? string.Empty))
                .ToList();
        }

        public List<ShopViewModel> GetFullList()
        {
            using var context = new CarpentryWorkshopDatabase();
            return context.Shops
            .Include(x => x.Woods)
                .ThenInclude(x => x.Wood)
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public ShopViewModel? Insert(ShopBindingModel model)
        {
            using var context = new CarpentryWorkshopDatabase();
            try
            {
                var newShop = Shop.Create(context, model);
                if (newShop == null)
                {
                    return null;
                }
                if (context.Shops.Any(x => x.ShopName == newShop.ShopName))
                {
                    throw new Exception("Не должно быть два магазина с одним названием");
                }
                context.Shops.Add(newShop);
                context.SaveChanges();
                return newShop.GetViewModel;
            }
            catch
            {
                throw;
            }
        }

        public ShopViewModel? Update(ShopBindingModel model)
        {
            using var context = new CarpentryWorkshopDatabase();
            var shop = context.Shops.FirstOrDefault(x => x.Id == model.Id);
            if (shop == null)
            {
                return null;
            }
            try
            {
                if (context.Shops.Any(x => (x.ShopName == model.ShopName && x.Id != model.Id)))
                {
                    throw new Exception("Не должно быть два магазина с одним названием");
                }
                shop.Update(model);
                shop.UpdateWoods(context, model);
                context.SaveChanges();
                return shop.GetViewModel;
            }
            catch
            {
                throw;
            }
        }
        public bool RestockingShops(SupplyBindingModel model)
        {
            using var context = new CarpentryWorkshopDatabase();
            var transaction = context.Database.BeginTransaction();
            var Shops = context.Shops.Include(x => x.Woods).ThenInclude(x => x.Wood).ToList().
                Where(x => x.WoodMaxCount > x.ShopWoods.Select(x => x.Value.Item2).Sum()).ToList();
            if (model == null)
            {
                return false;
            }
            try
            {
                foreach (Shop shop in Shops)
                {
                    int difference = shop.WoodMaxCount - shop.ShopWoods.Select(x => x.Value.Item2).Sum();
                    int refill = Math.Min(difference, model.Count);
                    model.Count -= refill;
                    if (shop.ShopWoods.ContainsKey(model.WoodId))
                    {
                        var datePair = shop.ShopWoods[model.WoodId];
                        datePair.Item2 += refill;
                        shop.ShopWoods[model.WoodId] = datePair;
                    }
                    else
                    {
                        var Wood = context.Woods.First(x => x.Id == model.WoodId);
                        shop.ShopWoods.Add(model.WoodId, (Wood, refill));
                    }
                    shop.WoodsDictionatyUpdate(context);
                    if (model.Count == 0)
                    {
                        transaction.Commit();
                        return true;
                    }
                }
                transaction.Rollback();
                return false;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public bool Sale(SupplySearchModel model)
        {
            using var context = new CarpentryWorkshopDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                var shops = context.Shops.Include(x => x.Woods).ThenInclude(x => x.Wood).ToList().
                    Where(x => x.ShopWoods.ContainsKey(model.WoodId.Value)).OrderByDescending(x => x.ShopWoods[model.WoodId.Value].Item2).ToList();

                foreach (var shop in shops)
                {
                    int residue = model.Count.Value - shop.ShopWoods[model.WoodId.Value].Item2;
                    if (residue > 0)
                    {
                        shop.ShopWoods.Remove(model.WoodId.Value);
                        shop.WoodsDictionatyUpdate(context);
                        context.SaveChanges();
                        model.Count = residue;

                    }
                    else
                    {
                        if (residue == 0)
                            shop.ShopWoods.Remove(model.WoodId.Value);
                        else
                        {
                            var dataPair = shop.ShopWoods[model.WoodId.Value];
                            dataPair.Item2 = -residue;
                            shop.ShopWoods[model.WoodId.Value] = dataPair;
                        }

                        shop.WoodsDictionatyUpdate(context);
                        transaction.Commit();
                        return true;
                    }
                }
                transaction.Rollback();
                return false;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
