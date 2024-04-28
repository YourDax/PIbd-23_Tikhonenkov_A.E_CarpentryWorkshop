using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopDatabaseImplement.Models
{
    public class Client : IClientModel
    {
        public int Id { get; set; }

        [Required]
        public string ClientFIO { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [ForeignKey("ClientId")]
        public virtual List<Order> ClientOrders { get; set; } = new();

        [ForeignKey("ClientId")]
        public virtual List<MessageInfo> ClientMessages { get; set; } = new();

        public ClientViewModel GetViewModel => new()
        {
            Id = Id,
            ClientFIO = ClientFIO,
            Email = Email,
            Password = Password
        };

        public static Client Create(ClientBindingModel model)
        {
            return new Client()
            {
                Id = model.Id,
                ClientFIO = model.ClientFIO,
                Email = model.Email,
                Password = model.Password,
            };
        }

        public void Update(ClientBindingModel model)
        {
            ClientFIO = model.ClientFIO;
            Email = model.Email;
            Password = model.Password;
        }
    }
}
