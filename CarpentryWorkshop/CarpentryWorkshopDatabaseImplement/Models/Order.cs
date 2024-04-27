using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDataModels.Enums;
using CarpentryWorkshopDataModels.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace CarpentryWorkshopDatabaseImplement.Models
{
    public class Order : IOrderModel
    {
        public int Id { get; private set; }
        [ForeignKey("WoodId")]
        public int WoodId { get; private set; }
        [ForeignKey("ImplementerId")]
        public int? ImplementerId { get; private set; }
        [ForeignKey("ClientId")]
        [Required]
        public int ClientId { get; set; }

        [Required]
        public int Count { get; private set; }

        [Required]
        public double Sum { get; private set; }

        [Required]
        public OrderStatus Status { get; private set; } = OrderStatus.Неизвестен;

        [Required]
        public DateTime DateCreate { get; private set; } = DateTime.Now;

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