using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopListImplement.Models
{
    public class Wood : IWoodModel
    {
        public int Id { get; private set; }
        public string WoodName { get; private set; } = string.Empty;
        public double Price { get; private set; }
        public Dictionary<int, (IComponentModel, int)> WoodComponents { get; private set; } = new Dictionary<int, (IComponentModel, int)>();
        public static Wood? Create(WoodBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Wood()
            {
                Id = model.Id,
                WoodName = model.WoodName,
                Price = model.Price,
                WoodComponents = model.WoodComponents
            };
        }
        public void Update(WoodBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            WoodName = model.WoodName;
            Price = model.Price;
            WoodComponents = model.WoodComponents;
        }
        public WoodViewModel GetViewModel => new()
        {
            Id = Id,
            WoodName = WoodName,
            Price = Price,
            WoodComponents = WoodComponents
        };
    }
}
