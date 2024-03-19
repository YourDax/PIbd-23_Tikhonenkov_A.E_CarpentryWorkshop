using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public OrderViewModel? Delete(OrderBindingModel model)
        {
            using var context = new CarpentryWorkshopDatabase();

            var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);

            if (element != null)
            {
                context.Orders.Remove(element);
                context.SaveChanges();

                return GetViewModel(element);
            }

            return null;
        }

        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }

            using var context = new CarpentryWorkshopDatabase();

            return GetViewModel(context.Orders.FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id)));
        }

        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return new();
            }

            using var context = new CarpentryWorkshopDatabase();

            return context.Orders.Where(x => x.Id == model.Id).Select(x => GetViewModel(x)).ToList();
        }

        public List<OrderViewModel> GetFullList()
        {
            using var context = new CarpentryWorkshopDatabase();

            return context.Orders.Select(x => GetViewModel(x)).ToList();
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
            return GetViewModel(newOrder);
        }

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

            return GetViewModel(order);
        }

        private static OrderViewModel GetViewModel(Order order)
        {
            var viewModel = order.GetViewModel;
            using var context = new CarpentryWorkshopDatabase();
            var element = context.Woods.FirstOrDefault(x => x.Id == order.WoodId);
            viewModel.WoodName = element.WoodName;
            return viewModel;
        }
    }
}
