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
using CarpentryWorkshopDatabaseImplement.Models;



namespace CarpentryWorkshopDatabaseImplement.Models
{
    public class Client : IClientModel
    {
        [Required]
        public string ClientFIO { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public int Id { get; set; }

        [ForeignKey("ClientId")]
        public virtual List<Order> Orders { get; set; } = new();

        public static Client? Create(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new()
            {
                Id = model.Id,
                ClientFIO = model.ClientFIO,
                Email = model.Email,
                Password = model.Password
            };
        }

        public void Update(ClientBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            ClientFIO = model.ClientFIO;
            Email = model.Email;
            Password = model.Password;
        }

        public ClientViewModel GetViewModel => new()
        {
            Id = Id,
            ClientFIO = ClientFIO,
            Email = Email,
            Password = Password,
        };
    }
}
