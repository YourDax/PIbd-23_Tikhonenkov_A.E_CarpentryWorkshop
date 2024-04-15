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
        private readonly DataFileSingleton _source;
        public ClientStorage()
        {
            _source = DataFileSingleton.GetInstance();
        }

        public ClientViewModel? Delete(ClientBindingModel model)
        {
            var res = _source.Clients.FirstOrDefault(x => x.Id == model.Id);
            if (res != null)
            {
                _source.Clients.Remove(res);
                _source.SaveClients();
            }
            return res?.GetViewModel;
        }

        public ClientViewModel? GetElement(ClientSearchModel model)
        {
            if (model.Id.HasValue)
                return _source.Clients.FirstOrDefault(x => x.Id == model.Id)?.GetViewModel;
            if (model.Email != null && model.Password != null)
                return _source.Clients
                    .FirstOrDefault(x => x.Email.Equals(model.Email)
                                      && x.Password.Equals(model.Password))
                    ?.GetViewModel;
            if (model.Email != null)
                return _source.Clients.FirstOrDefault(x => x.Email.Equals(model.Email))?.GetViewModel;
            return null;
        }

        public List<ClientViewModel> GetFilteredList(ClientSearchModel model)
        {
            if (model == null)
            {
                return new();
            }
            if (model.Id.HasValue)
            {
                var res = GetElement(model);
                return res != null ? new() { res } : new();
            }
            if (model.Email != null)
            {
                return _source.Clients
                    .Where(x => x.Email.Contains(model.Email))
                    .Select(x => x.GetViewModel)
                    .ToList();
            }
            return new();
        }

        public List<ClientViewModel> GetFullList()
        {
            return _source.Clients.Select(x => x.GetViewModel).ToList();
        }

        public ClientViewModel? Insert(ClientBindingModel model)
        {
            model.Id = _source.Clients.Count > 0 ? _source.Clients.Max(x => x.Id) + 1 : 1;
            var res = Client.Create(model);
            if (res != null)
            {
                _source.Clients.Add(res);
                _source.SaveClients();
            }
            return res?.GetViewModel;
        }

        public ClientViewModel? Update(ClientBindingModel model)
        {
            var res = _source.Clients.FirstOrDefault(x => x.Id == model.Id);
            if (res != null)
            {
                res.Update(model);
                _source.SaveClients();
            }
            return res?.GetViewModel;
        }
    }
}
