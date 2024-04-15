using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace CarpentryWorkshopDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using var context = new CarpentryWorkshopDatabase();
            return context.Orders
                    .Include(x => x.Wood)
                    .Include(x => x.Client)
                    .Select(x => x.GetViewModel)
                    .ToList();
        }
        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            if (!model.Id.HasValue && !model.DateFrom.HasValue && !model.ClientId.HasValue)
            {
                return new();
            }
            using var context = new CarpentryWorkshopDatabase();
            if (model.ClientId.HasValue)
            {
                return context.Orders
                    .Include(x => x.Wood)
                    .Include(x => x.Client)
                   .Where(x => x.ClientId == model.ClientId)
                   .Select(x => x.GetViewModel)
                   .ToList();
            }
            if (model.DateFrom.HasValue)
            {
                return context.Orders.Include(x => x.Wood)
                    .Include(x => x.Client)
                    .Where(x => (x.DateCreate >= model.DateFrom && x.DateCreate <= model.DateTo))
                    .Select(x => x.GetViewModel)
                    .ToList();
            }
            return context.Orders.Include(x => x.Wood)
                    .Include(x => x.Client)
                    .Where(x => x.Id == model.Id)
                    .Select(x => x.GetViewModel)
                    .ToList();
        }
        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (model.Id == null && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new CarpentryWorkshopDatabase();
            return context.Orders.Include(x => x.Wood).Include(x => x.Client)
                    .FirstOrDefault(x => (model.Id != null && x.Id == model.Id) || (model.Id.HasValue && x.Id == model.Id))
                    ?.GetViewModel;
        }
        public OrderViewModel? Insert(OrderBindingModel model)
        {
            var newOrder = Order.Create(model);
            if (newOrder == null)
            {
                return null;
            }
            using var context = new CarpentryWorkshopDatabase();
            context.Orders.Add(newOrder);
            context.SaveChanges();
            return context.Orders
                          .Include(x => x.Wood)
                          .Include(x => x.Client)
                          .FirstOrDefault(x => x.Id == newOrder.Id)
                          ?.GetViewModel;
        }
        public OrderViewModel? Delete(OrderBindingModel model)
        {
            using var context = new CarpentryWorkshopDatabase();
            var element = context.Orders.Include(x => x.Wood).Include(x => x.Client).FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Orders.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }


        //
        public OrderViewModel? Update(OrderBindingModel model)
        {
            using var context = new CarpentryWorkshopDatabase();
            var order = context.Orders.Include(x => x.Wood).Include(x => x.Client).FirstOrDefault(x => x.Id == model.Id);
            if (order == null)
            {
                return null;
            }
            order.Update(model);
            context.SaveChanges();
            return order.GetViewModel;
        }
    }
}