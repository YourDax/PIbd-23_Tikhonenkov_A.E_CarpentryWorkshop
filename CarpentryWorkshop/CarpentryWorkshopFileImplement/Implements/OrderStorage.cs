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
    public class OrderStorage : IOrderStorage
    {
        private readonly DataFileSingleton source;
        public OrderStorage()
        {
            source = DataFileSingleton.GetInstance();
        }
        public List<OrderViewModel> GetFullList()
        {
            return source.Orders
            .Select(x => x.GetViewModel)
            .ToList();
        }
        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            if (!model.Id.HasValue && !model.DateFrom.HasValue)
            {
                return new();
            }
            if (model.DateFrom.HasValue)
            {
                return source.Orders
                    .Where(x => x.DateCreate >= model.DateFrom && x.DateCreate <= model.DateTo)
                    .Select(x => x.GetViewModel)
                    .ToList();
            }
            return source.Orders
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
            return source.Orders
            .FirstOrDefault(x => (model.Id != null && x.Id == model.Id) ||
            (model.Id.HasValue && x.Id == model.Id))
            ?.GetViewModel;
        }
        public OrderViewModel? Insert(OrderBindingModel model)
        {
            model.Id = source.Orders.Count > 0 ? source.Orders.Max(x => x.Id) + 1 : 1;
            var newOrder = Order.Create(model); if (newOrder == null)
            {
                return null;
            }
            source.Orders.Add(newOrder);
            source.SaveOrders();
            return newOrder.GetViewModel;
        }
        public OrderViewModel? Update(OrderBindingModel model)
        {
            var order = source.Orders.FirstOrDefault(x => x.Id == model.Id);
            if (order == null)
            {
                return null;
            }
            order.Update(model);
            source.SaveOrders();
            return order.GetViewModel;
        }
        public OrderViewModel? Delete(OrderBindingModel model)
        {
            var element = source.Orders.FirstOrDefault(x => x.Id == model.Id);
            if (element != null)
            {
                source.Orders.Remove(element);
                source.SaveOrders();
                return element.GetViewModel;
            }
            return null;
        }
    }
}
