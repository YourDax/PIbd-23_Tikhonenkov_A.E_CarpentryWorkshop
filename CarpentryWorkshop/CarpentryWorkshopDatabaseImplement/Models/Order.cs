using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDataModels.Enums;
using CarpentryWorkshopDataModels.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Runtime.Serialization;

namespace CarpentryWorkshopDatabaseImplement.Models
{
    [DataContract]
    public class Order : IOrderModel
    {
        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        [Required]
        public int WoodId { get; private set; }

        [DataMember]
        public int? ImplementerId { get; private set; }

        [DataMember]
        [Required]
        public int ClientId { get; set; }

        [DataMember]
        [Required]
        public int Count { get; private set; }

        [DataMember]
        [Required]
        public double Sum { get; private set; }

        [DataMember]
        [Required]
        public OrderStatus Status { get; private set; } = OrderStatus.Неизвестен;

        [DataMember]
        [Required]
        public DateTime DateCreate { get; private set; }

        [DataMember]
        public DateTime? DateImplement { get; private set; }

        public virtual Wood Wood { get; set; }

        public Client Client { get; set; }

        public Implementer? Implementer { get; set; }

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
                ClientId = model.ClientId,
                ImplementerId = model.ImplementerId,
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
            ImplementerId = model.ImplementerId;
        }

        public OrderViewModel GetViewModel
        {
            get
            {
                using var context = new CarpentryWorkshopDatabase();
                return new OrderViewModel
                {
                    Id = Id,
                    WoodId = WoodId,
                    ClientId = ClientId,
                    ImplementerId = ImplementerId,
                    ClientFIO = context.Clients.FirstOrDefault(x => x.Id == ClientId)?.ClientFIO ?? string.Empty,
                    WoodName = context.Woods.FirstOrDefault(x => x.Id == WoodId)?.WoodName ?? string.Empty,
                    Count = Count,
                    Sum = Sum,
                    Status = Status,
                    DateCreate = DateCreate,
                    DateImplement = DateImplement,
                    ImplementerFIO = Implementer?.ImplementerFIO ?? string.Empty
                };
            }
        }
    }
}