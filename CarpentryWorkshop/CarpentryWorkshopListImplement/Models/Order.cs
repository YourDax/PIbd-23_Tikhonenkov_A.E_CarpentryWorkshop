using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDataModels.Enums;
using CarpentryWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopListImplement.Models
{
    public class Order : IOrderModel
    {
        public int WoodId { get; private set; }

        public int ClientId { get; private set; }

        public int Count { get; private set; }

        public double Sum { get; private set; }

        public OrderStatus Status { get; private set; } = OrderStatus.Неизвестен;

        public DateTime DateCreate { get; private set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

        public DateTime? DateImplement { get; private set; }

        public int Id { get; private set; }

        public static Order? Create(OrderBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Order()
            {
                Id = model.Id,
                WoodId = model.WoodId,
                ImplementerId = model.ImplementerId,
                ClientId = model.ClientId,
                Count = model.Count,
                Sum = model.Sum,
                Status = model.Status,
                DateCreate = model.DateCreate,
                DateImplement = model.DateImplement
            };
        }

        public void Update(OrderBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            Status = model.Status;
            DateImplement = model.DateImplement;
        }

        public OrderViewModel GetViewModel => new()
        {
            Id = Id,
            WoodId = WoodId,
            ClientId = ClientId,
            Count = Count,
            Sum = Sum,
            Status = Status,
            DateCreate = DateCreate,
            DateImplement = DateImplement,
            ImplementerId = ImplementerId
        };

        public int? ImplementerId { get; private set; }
    }
}
