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
            var res = context.Clients.FirstOrDefault(x => x.Id == model.Id);
            if (res != null)
            {
                context.Clients.Remove(res);
                context.SaveChanges();
            }
            return res?.GetViewModel;
        }

        public ClientViewModel? GetElement(ClientSearchModel model)
        {
            using var context = new CarpentryWorkshopDatabase();
            if (model.Id.HasValue)
                return context.Clients.FirstOrDefault(x => x.Id == model.Id)?.GetViewModel;
            if (model.Email != null && model.Password != null)
                return context.Clients
                    .FirstOrDefault(x => x.Email.Equals(model.Email)
                                      && x.Password.Equals(model.Password))
                    ?.GetViewModel;
            if (model.Email != null)
                return context.Clients.FirstOrDefault(x => x.Email.Equals(model.Email))?.GetViewModel;
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
                using var context = new CarpentryWorkshopDatabase();
                return context.Clients
                    .Where(x => x.Email.Contains(model.Email))
                    .Select(x => x.GetViewModel)
                    .ToList();
            }
            return new();
        }

        public List<ClientViewModel> GetFullList()
        {
            using var context = new CarpentryWorkshopDatabase();
            return context.Clients.Select(x => x.GetViewModel).ToList();
        }

        public ClientViewModel? Insert(ClientBindingModel model)
        {
            using var context = new CarpentryWorkshopDatabase();
            var res = Client.Create(model);
            if (res != null)
            {
                context.Clients.Add(res);
                context.SaveChanges();
            }
            return res?.GetViewModel;
        }

        public ClientViewModel? Update(ClientBindingModel model)
        {
            using var context = new CarpentryWorkshopDatabase();
            var res = context.Clients.FirstOrDefault(x => x.Id == model.Id);
            res?.Update(model);
            context.SaveChanges();
            return res?.GetViewModel;
        }
    }
}
