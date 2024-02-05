using CarpentryWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopContracts.BindingModels
{
    public class WoodBindingModel : IWoodModel
    {
        public int Id { get; set; }
        public string WoodName { get; set; } = string.Empty;
        public double Price { get; set; }
        public Dictionary<int, (IComponentModel, int)> WoodComponents
        {
            get;
            set;
        } = new();
    }

}
