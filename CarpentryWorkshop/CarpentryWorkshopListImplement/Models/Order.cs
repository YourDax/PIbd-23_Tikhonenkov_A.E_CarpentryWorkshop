using CarpentryWorkshopContracts.BindingModels;
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
        public int Id { get; set; }
        public int WoodId { get; set; }
        public string WoodName { get; set; } = string.Empty;
        public int Count { get; set; }
        public double Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
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
                WoodName = model.WoodName,
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
            WoodId = model.WoodId;
            WoodName = model.WoodName;
            Count = model.Count;
            Sum = model.Sum;
            Status = model.Status;
            DateCreate = model.DateCreate;
            DateImplement = model.DateImplement;
        }
        public OrderViewModel GetViewModel => new()
        {
            Id = Id,
            WoodId = WoodId,
            WoodName = WoodName,
            Count = Count,
            Sum = Sum,
            Status = Status,
            DateCreate = DateCreate,
            DateImplement = DateImplement
        };
    }
}
