using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDatabaseImplement.Models;

namespace CarpentryWorkshopDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using var context = new CarpentryWorkshopDatabase();
            return context.Orders
                    .Select(x => x.GetViewModel)
                    .ToList();
        }
        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            if (model.Id == null)
            {
                return new();
            }
            using var context = new CarpentryWorkshopDatabase();
            return context.Orders
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
            return context.Orders
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
            return newOrder.GetViewModel;
        }
        public OrderViewModel? Delete(OrderBindingModel model)
        {
            using var context = new CarpentryWorkshopDatabase();
            var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
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
            var order = context.Orders.FirstOrDefault(x => x.Id == model.Id);
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