using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopFileImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        private readonly DataFileSingleton source;

        public ClientStorage()
        {
            source = DataFileSingleton.GetInstance();
        }

        public List<ClientViewModel> GetFullList()
        {
            return source.Clients
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public List<ClientViewModel> GetFilteredList(ClientSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ClientFIO) && string.IsNullOrEmpty(model.Email))
            {
                return new();
            }
            return source.Clients
                    .Where(x => (!string.IsNullOrEmpty(model.ClientFIO) && x.ClientFIO.Contains(model.ClientFIO)) ||
                        (!string.IsNullOrEmpty(model.Email) && x.ClientFIO.Contains(model.Email)))
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public ClientViewModel? GetElement(ClientSearchModel model)
        {
            if (!model.Id.HasValue && string.IsNullOrEmpty(model.ClientFIO) && string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.Password))
            {
                return null;
            }
            return source.Clients
                    .FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id) ||
                        (!string.IsNullOrEmpty(model.ClientFIO) && x.ClientFIO == model.ClientFIO) ||
                        (!string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.Password) && x.Email == model.Email && x.Password == model.Password))
                    ?.GetViewModel;
        }

        public ClientViewModel? Insert(ClientBindingModel model)
        {
            model.Id = source.Components.Count > 0 ? source.Components.Max(x => x.Id) + 1 : 1;
            var newClient = Client.Create(model);
            if (newClient == null)
            {
                return null;
            }
            source.Clients.Add(newClient);
            source.SaveClients();
            return newClient.GetViewModel;
        }

        public ClientViewModel? Update(ClientBindingModel model)
        {
            var client = source.Clients.FirstOrDefault(x => x.Id == model.Id);
            if (client == null)
            {
                return null;
            }
            client.Update(model);
            source.SaveClients();
            return client.GetViewModel;
        }

        public ClientViewModel? Delete(ClientBindingModel model)
        {
            var element = source.Clients.FirstOrDefault(x => x.Id == model.Id);
            if (element != null)
            {
                source.Clients.Remove(element);
                source.SaveClients();
                return element.GetViewModel;
            }
            return null;
        }
    }
}
