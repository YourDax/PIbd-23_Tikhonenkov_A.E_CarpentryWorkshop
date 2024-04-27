using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopListImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly DataListSingleton _source;
        public OrderStorage()
        {
            _source = DataListSingleton.GetInstance();
        }
        public OrderViewModel? Delete(OrderBindingModel model)
        {
            for (int i = 0; i < _source.Orders.Count; ++i)
            {
                if (_source.Orders[i].Id == model.Id)
                {
                    var element = _source.Orders[i];
                    _source.Orders.RemoveAt(i);
                    return element.GetViewModel;
                }
            }

            return null;
        }

        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }

            foreach (var order in _source.Orders)
            {
                if (model.Id.HasValue && order.Id == model.Id)
                {
                    return order.GetViewModel;
                }

                else if (model.ImplementerId.HasValue && model.Statuses != null &&
                    order.ImplementerId == model.ImplementerId &&
                    model.Statuses.Contains(order.Status))
                {
                    return GetViewModel(order);
                }

                else if (model.ImplementerId.HasValue &&
                    model.ImplementerId == order.ImplementerId)
                {
                    return GetViewModel(order);
                }
            }

            return null;
        }

        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            var result = new List<OrderViewModel>();

            if (model.DateFrom.HasValue)
            {
                foreach (var order in _source.Orders)
                {
                    if (order.DateCreate >= model.DateFrom && order.DateCreate <= model.DateTo)
                    {
                        result.Add(GetViewModel(order));
                    }
                }
            }
            else if (model.ClientId.HasValue && !model.Id.HasValue)
            {
                foreach (var order in _source.Orders)
                {
                    if (order.ClientId == model.ClientId)
                    {
                        result.Add(GetViewModel(order));
                    }
                }
            }
            else if (model.Id.HasValue)
            {
                foreach (var order in _source.Orders)
                {
                    if (order.Id == model.Id)
                    {
                        result.Add(GetViewModel(order));
                    }

                    else if (model.ImplementerId.HasValue && order.ImplementerId == model.ImplementerId)
                    {
                        result.Add(GetViewModel(order));
                    }

                    else if (model.Statuses != null && model.Statuses.Contains(order.Status))
                    {
                        result.Add(GetViewModel(order));
                    }
                }
            }


            return result;
        }
        private OrderViewModel GetViewModel(Order order)
        {
            var viewModel = order.GetViewModel;
            foreach (var wood in _source.Woods)
            {
                if (wood.Id == order.WoodId)
                {
                    viewModel.WoodName = wood.WoodName;
                    break;
                }
            }
            foreach (var client in _source.Clients)
            {
                if (client.Id == order.ClientId)
                {
                    viewModel.ClientFIO = client.ClientFIO;
                    break;
                }
            }
            return viewModel;
        }
        public List<OrderViewModel> GetFullList()
        {
            var result = new List<OrderViewModel>();

            foreach (var order in _source.Orders)
            {
                result.Add(order.GetViewModel);
            }

            return result;
        }

        public OrderViewModel? Insert(OrderBindingModel model)
        {
            model.Id = 1;

            foreach (var order in _source.Orders)
            {
                if (model.Id <= order.Id)
                {
                    model.Id = order.Id + 1;
                }
            }

            var newOrder = Order.Create(model);

            if (newOrder == null)
            {
                return null;
            }

            _source.Orders.Add(newOrder);

            return newOrder.GetViewModel;
        }

        public OrderViewModel? Update(OrderBindingModel model)
        {
            foreach (var order in _source.Orders)
            {
                if (order.Id == model.Id)
                {
                    order.Update(model);
                    return order.GetViewModel;
                }
            }

            return null;
        }
    }
}
