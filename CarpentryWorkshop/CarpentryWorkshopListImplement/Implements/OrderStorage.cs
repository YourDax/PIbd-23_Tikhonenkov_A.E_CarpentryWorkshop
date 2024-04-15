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
        public List<OrderViewModel> GetFullList()
        {
            var result = new List<OrderViewModel>();
            foreach (var Order in _source.Orders)
            {
                result.Add(GetViewModel(Order));
            }
            return result;
        }
        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            var result = new List<OrderViewModel>();
            foreach (var order in _source.Orders)
            {
                if (order.Id == model.Id)
                {
                    return new() { GetViewModel(order) };
                }
                else if (model.DateFrom.HasValue && model.DateTo.HasValue && model.DateFrom <= order.DateCreate.Date && order.DateCreate.Date <= model.DateTo)
                {
                    result.Add(GetViewModel(order));
                }
                else if (model.ClientId.HasValue && order.ClientId == model.ClientId)
                {
                    result.Add(GetViewModel(order));
                }
            }
            return result;
        }
        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }
            foreach (var Order in _source.Orders)
            {
                if (model.Id.HasValue && Order.Id == model.Id)
                {
                    return GetViewModel(Order);
                }
            }
            return null;
        }
        public OrderViewModel? Insert(OrderBindingModel model)
        {
            model.Id = 1;
            foreach (var Order in _source.Orders)
            {
                if (model.Id <= Order.Id)
                {
                    model.Id = Order.Id + 1;
                }
            }
            var newOrder = Order.Create(model);
            if (newOrder == null)
            {
                return null;
            }
            _source.Orders.Add(newOrder);
            return GetViewModel(newOrder);
        }
        public OrderViewModel? Update(OrderBindingModel model)
        {
            foreach (var Order in _source.Orders)
            {
                if (Order.Id == model.Id)
                {
                    Order.Update(model);
                    return GetViewModel(Order);
                }
            }
            return null;
        }
        public OrderViewModel? Delete(OrderBindingModel model)
        {
            for (int i = 0; i < _source.Orders.Count; ++i)
            {
                if (_source.Orders[i].Id == model.Id)
                {
                    var element = _source.Orders[i];
                    _source.Orders.RemoveAt(i);
                    return GetViewModel(element);
                }
            }
            return null;
        }

        private OrderViewModel GetViewModel(Order order)
        {
            var viewModel = order.GetViewModel;
            foreach (var comp in _source.Woods)
            {
                if (comp.Id == order.WoodId)
                {
                    viewModel.WoodName = comp.WoodName;
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
    }
}
