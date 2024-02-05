using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopListImplement.Implements
{
    public class WoodStorage : IWoodStorage
    {
        private readonly DataListSingleton _source;
        public WoodStorage()
        {
            _source = DataListSingleton.GetInstance();
        }
        public List<WoodViewModel> GetFullList()
        {
            var result = new List<WoodViewModel>();
            foreach (var wood in _source.Woods)
            {
                result.Add(wood.GetViewModel);
            }
            return result;
        }
        public List<WoodViewModel> GetFilteredList(WoodSearchModel model)
        {
            var result = new List<WoodViewModel>();
            if (string.IsNullOrEmpty(model.WoodName))
            {
                return result;
            }
            foreach (var wood in _source.Woods)
            {
                if (wood.WoodName.Contains(model.WoodName))
                {
                    result.Add(wood.GetViewModel);
                }
            }
            return result;
        }
        public WoodViewModel? GetElement(WoodSearchModel model)
        {
            if (string.IsNullOrEmpty(model.WoodName) && !model.Id.HasValue)
            {
                return null;
            }
            foreach (var wood in _source.Woods)
            {
                if ((!string.IsNullOrEmpty(model.WoodName) && wood.WoodName == model.WoodName) ||
                (model.Id.HasValue && wood.Id == model.Id))
                {
                    return wood.GetViewModel;
                }
            }
            return null;
        }
        public WoodViewModel? Insert(WoodBindingModel model)
        {
            model.Id = 1;
            foreach (var wood in _source.Woods)
            {
                if (model.Id <= wood.Id)
                {
                    model.Id = wood.Id + 1;
                }
            }
            var newWood = Wood.Create(model);
            if (newWood == null)
            {
                return null;
            }
            _source.Woods.Add(newWood);
            return newWood.GetViewModel;
        }
        public WoodViewModel? Update(WoodBindingModel model)
        {
            foreach (var wood in _source.Woods)
            {
                if (wood.Id == model.Id)
                {
                    wood.Update(model);
                    return wood.GetViewModel;
                }
            }
            return null;
        }
        public WoodViewModel? Delete(WoodBindingModel model)
        {
            for (int i = 0; i < _source.Woods.Count; ++i)
            {
                if (_source.Woods[i].Id == model.Id)
                {
                    var element = _source.Woods[i];
                    _source.Woods.RemoveAt(i);
                    return element.GetViewModel;
                }
            }
            return null;
        }
    }
}
