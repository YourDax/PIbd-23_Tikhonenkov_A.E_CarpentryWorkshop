using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopContracts.StoragesContracts
{
    public interface IClientStorage
    {
        List<ClientViewModel> GetFullList();

        List<ClientViewModel> GetFilteredList(ClientSearchModel model);

        ClientViewModel? GetElement(ClientSearchModel model);

        ClientViewModel? Insert(ClientBindingModel model);

        ClientViewModel? Update(ClientBindingModel model);

        ClientViewModel? Delete(ClientBindingModel model);
    }
}
