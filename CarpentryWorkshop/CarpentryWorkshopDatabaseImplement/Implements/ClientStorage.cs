using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopDatabaseImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        public ClientViewModel? Delete(ClientBindingModel model)
        {
            using var context = new CarpentryWorkshopDatabase();
            var element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Clients.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }

        public ClientViewModel? GetElement(ClientSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.Password) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new CarpentryWorkshopDatabase();
            return context.Clients.FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id) ||
                (!string.IsNullOrEmpty(model.ClientFIO) && x.ClientFIO == model.ClientFIO) ||
                (!string.IsNullOrEmpty(model.Email) && x.Email == model.Email && (string.IsNullOrEmpty(model.Password) || x.Password == model.Password)))?.GetViewModel;

        }

        public List<ClientViewModel> GetFilteredList(ClientSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ClientFIO))
            {
                return new();
            }
            using var context = new CarpentryWorkshopDatabase();
            return context.Clients.Where(x => x.ClientFIO.Contains(model.ClientFIO)).Select(x => x.GetViewModel).ToList();
        }

        public List<ClientViewModel> GetFullList()
        {
            using var context = new CarpentryWorkshopDatabase();
            return context.Clients.Select(x => x.GetViewModel).ToList();
        }

        public ClientViewModel? Insert(ClientBindingModel model)
        {
            var newComponent = Client.Create(model);
            if (newComponent == null)
            {
                return null;
            }
            using var context = new CarpentryWorkshopDatabase();
            context.Clients.Add(newComponent);
            context.SaveChanges();
            return newComponent.GetViewModel;
        }

        public ClientViewModel? Update(ClientBindingModel model)
        {
            using var context = new CarpentryWorkshopDatabase();
            var component = context.Clients.FirstOrDefault(x => x.Id == model.Id);
            if (component == null)
            {
                return null;
            }
            component.Update(model);
            context.SaveChanges();
            return component.GetViewModel;
        }
    }
}
