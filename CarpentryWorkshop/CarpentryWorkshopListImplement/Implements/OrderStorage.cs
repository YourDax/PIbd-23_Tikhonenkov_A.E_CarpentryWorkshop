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
            foreach (var order in _source.Orders)
            {
                result.Add(order.GetViewModel);
            }
            return result;
        }
        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            var result = new List<OrderViewModel>();
            if (model.Id == null)
            {
                return result;
            }
            foreach (var order in _source.Orders)
            {
                if (order.Id.Equals(model.Id))
                {
                    result.Add(order.GetViewModel);
                }
            }
            return result;
        }
        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (model.Id == null && !model.Id.HasValue)
            {
                return null;
            }
            foreach (var order in _source.Orders)
            {
                if ((model.Id != null && order.Id == model.Id) ||
                (model.Id.HasValue && order.Id == model.Id))
                {
                    return order.GetViewModel;
                }
            }
            return null;
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
    }
}
