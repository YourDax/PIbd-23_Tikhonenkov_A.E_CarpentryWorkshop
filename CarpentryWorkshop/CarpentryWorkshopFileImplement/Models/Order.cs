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
using System.Xml.Linq;

namespace CarpentryWorkshopFileImplement.Models
{
    public class Order : IOrderModel
    {
        public int Id { get; private set; }
        public int WoodId { get; private set; }
        public string WoodName { get; private set; } = string.Empty;
        public int Count { get; private set; }
        public double Sum { get; private set; }
        public OrderStatus Status { get; private set; } = OrderStatus.Неизвестен;
        public DateTime DateCreate { get; private set; } = DateTime.Now;
        public DateTime? DateImplement { get; private set; }
        public static Order? Create(OrderBindingModel model)
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
        public static Order? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }
            return new Order()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                WoodId = Convert.ToInt32(element.Element("WoodId")!.Value),
                WoodName = element.Element("WoodName")!.Value,
                Count = Convert.ToInt32(element.Element("Count")!.Value),
                Sum = Convert.ToDouble(element.Element("Sum")!.Value),
                Status = (OrderStatus)Convert.ToInt32(element.Element("Status").Value),
                DateCreate = Convert.ToDateTime(element.Element("DateCreate").Value),
                DateImplement = String.IsNullOrEmpty(element.Element("DateImplement").Value) ? DateTime.MinValue : Convert.ToDateTime(element.Element("DateImplement").Value)
                
            };
        }
        public void Update(OrderBindingModel model)
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
            WoodName = WoodName,
            Count = Count,
            Sum = Sum,
            Status = Status,
            DateCreate = DateCreate,
            DateImplement = DateImplement,
        };
        public XElement GetXElement => new("Order",
        new XAttribute("Id", Id),
        new XElement("WoodId", WoodId),
        new XElement("WoodName", WoodName),
        new XElement("Count", Count),
        new XElement("Sum", Sum.ToString()),
        new XElement("Status", (int)Status),
        new XElement("DateCreate", DateCreate),
        new XElement("DateImplement", DateImplement));
    }
}
