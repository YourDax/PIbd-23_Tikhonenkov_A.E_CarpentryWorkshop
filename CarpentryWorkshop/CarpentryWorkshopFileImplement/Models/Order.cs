using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDataModels.Enums;
using CarpentryWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Runtime.Serialization;

namespace CarpentryWorkshopFileImplement.Models
{
    [DataContract]
    public class Order : IOrderModel
    {
        [DataMember]
        public int WoodId { get; private set; }

        [DataMember]
        public int? ImplementerId { get; set; }

        [DataMember]
        public int ClientId { get; private set; }

        [DataMember]
        public int Count { get; private set; }

        [DataMember]
        public double Sum { get; private set; }

        [DataMember]
        public OrderStatus Status { get; private set; } = OrderStatus.Неизвестен;

        [DataMember]
        public DateTime DateCreate { get; private set; } = DateTime.Now;

        [DataMember]
        public DateTime? DateImplement { get; private set; }

        [DataMember]
        public int Id { get; private set; }

        public static Order? Create(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Order()
            {
                Id = model.Id,
                ImplementerId = model.ImplementerId,
                WoodId = model.WoodId,
                ClientId = model.ClientId,
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

            var order = new Order()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                ImplementerId = Convert.ToInt32(element.Element("ImplementerId")!.Value),
                WoodId = Convert.ToInt32(element.Element("WoodId")!.Value),
                ClientId = Convert.ToInt32(element.Element("ClientId")!.Value),
                Count = Convert.ToInt32(element.Element("Count")!.Value),
                Sum = Convert.ToDouble(element.Element("Sum")!.Value),
                Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), element.Element("Status")!.Value),
                DateCreate = DateTime.ParseExact(element.Element("DateCreate")!.Value, "G", null)
            };

            DateTime.TryParse(element.Element("DateImplement")!.Value, out DateTime dateImpl);
            order.DateImplement = dateImpl;

            return order;
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
            ImplementerId = ImplementerId,
            WoodId = WoodId,
            ClientId = ClientId,
            Count = Count,
            Sum = Sum,
            Status = Status,
            DateCreate = DateCreate,
            DateImplement = DateImplement
        };

        public XElement GetXElement => new("Order",
            new XAttribute("Id", Id),
            new XElement("WoodId", WoodId.ToString()),
            new XElement("ClientId", ClientId.ToString()),
            new XElement("ImplementerId", ImplementerId.ToString()),
            new XElement("Count", Count.ToString()),
            new XElement("Sum", Sum.ToString()),
            new XElement("Status", Status.ToString()),
            new XElement("DateCreate", DateCreate.ToString()),
            new XElement("DateImplement", DateImplement.ToString()));
    }
}
