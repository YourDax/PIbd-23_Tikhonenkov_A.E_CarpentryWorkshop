using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDataModels.Enums;
using CarpentryWorkshopDataModels.Models;
using CarpentryWorkshopDatabaseImplement.Models;
using System.ComponentModel.DataAnnotations;

namespace CarpentryWorkshopDatabaseImplement.Models
{
    public class Order : IOrderModel
    {
        public int Id { get; set; }
        [Required]
        public int WoodId { get; set; }
        [Required]
        public int ClientId { get; private set; }
        [Required]
        public string WoodName { get; set; } = string.Empty;
        [Required]
        public int Count { get; set; }
        [Required]
        public double Sum { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }
        public virtual Wood Wood { get; set; }
        public virtual Client Client { get; set; }


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
            
            Status = model.Status;
            
            DateImplement = model.DateImplement;
        }

        public OrderViewModel GetViewModel => new()
        {
            Id = Id,
            WoodId = WoodId,
            ClientId = ClientId,
            ClientFIO = Client.ClientFIO,
            Count = Count,
            Sum = Sum,
            Status = Status,
            DateCreate = DateCreate,
            DateImplement = DateImplement,
            WoodName = Wood.WoodName
        };
    }
}