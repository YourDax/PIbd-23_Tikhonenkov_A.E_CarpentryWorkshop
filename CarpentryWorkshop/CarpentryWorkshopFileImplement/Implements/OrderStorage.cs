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

        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (model.ImplementerId.HasValue && model.Statuses != null)
            {
                return source.Orders
                    .FirstOrDefault(x => x.ImplementerId == model.ImplementerId &&
                                         model.Statuses.Contains(x.Status))
                    ?.GetViewModel;
            }

            if (model.ImplementerId.HasValue)
            {
                return source.Orders
                    .FirstOrDefault(x => x.ImplementerId == model.ImplementerId)
                    ?.GetViewModel;
            }

            if (!model.Id.HasValue)
            {
                return null;
            }

            return source.Orders
                .FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id))
                ?.GetViewModel;
        }
        private OrderViewModel GetViewModel(Order order)
        {
            var viewModel = order.GetViewModel;

            var wood = source
                .Woods.FirstOrDefault(x => x.Id == order.WoodId);

            var client = source
                .Clients.FirstOrDefault(x => x.Id == order.ClientId);

            if (wood != null)
                viewModel.WoodName = wood.WoodName;

            if (client != null)
                viewModel.ClientFIO = client.ClientFIO;

            return viewModel;
        }
        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            if (model.DateFrom.HasValue)
                return source.Orders
                    .Where(x => x.DateCreate >= model.DateFrom && x.DateCreate <= model.DateTo)
                    .Select(x => GetViewModel(x))
                    .ToList();

            if (model.ClientId.HasValue && !model.Id.HasValue)
                return source.Orders
                    .Where(x => x.ClientId == model.ClientId)
                    .Select(x => x.GetViewModel)
                    .ToList();

            if (model.Id.HasValue)
                return source.Orders
                    .Where(x => x.Id.Equals(model.Id))
                    .Select(x => GetViewModel(x))
                    .ToList();

            return new();
        }

        public List<OrderViewModel> GetFullList()
        {
            return source.Orders.Select(x => x.GetViewModel).ToList();
        }

        public OrderViewModel? Insert(OrderBindingModel model)
        {
            model.Id = source.Orders.Count > 0 ? source.Orders.Max(x => x.Id) + 1 : 1;
            var newOrder = Order.Create(model);

            if (newOrder == null)
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
    }
}
