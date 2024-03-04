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
    public class WoodStorage : IWoodStorage
    {
        private readonly DataFileSingleton source;
        public WoodStorage()
        {
            source = DataFileSingleton.GetInstance();
        }
        public List<WoodViewModel> GetFullList()
        {
            return source.Woods
            .Select(x => x.GetViewModel)
            .ToList();
        }
        public List<WoodViewModel> GetFilteredList(WoodSearchModel model)
        {
            if (string.IsNullOrEmpty(model.WoodName))
            {
                return new();
            }
            return source.Woods
            .Where(x => x.WoodName.Contains(model.WoodName))
            .Select(x => x.GetViewModel)
            .ToList();
        }
        public WoodViewModel? GetElement(WoodSearchModel model)
        {
            if (string.IsNullOrEmpty(model.WoodName) && !model.Id.HasValue)
            {
                return null;
            }
            return source.Woods
            .FirstOrDefault(x => (!string.IsNullOrEmpty(model.WoodName) && x.WoodName == model.WoodName) ||
            (model.Id.HasValue && x.Id == model.Id))
            ?.GetViewModel;
        }
        public WoodViewModel? Insert(WoodBindingModel model)
        {
            model.Id = source.Woods.Count > 0 ? source.Components.Max(x => x.Id) + 1 : 1;
            var newWood = Wood.Create(model); if (newWood == null)
            {
                return null;
            }
            source.Woods.Add(newWood);
            source.SaveWoods();
            return newWood.GetViewModel;
        }
        public WoodViewModel? Update(WoodBindingModel model)
        {
            var wood = source.Woods.FirstOrDefault(x => x.Id == model.Id);
            if (wood == null)
            {
                return null;
            }
            wood.Update(model);
            source.SaveWoods();
            return wood.GetViewModel;
        }
        public WoodViewModel? Delete(WoodBindingModel model)
        {
            var element = source.Woods.FirstOrDefault(x => x.Id == model.Id);
            if (element != null)
            {
                source.Woods.Remove(element);
                source.SaveWoods();
                return element.GetViewModel;
            }
            return null;
        }
    }
}
