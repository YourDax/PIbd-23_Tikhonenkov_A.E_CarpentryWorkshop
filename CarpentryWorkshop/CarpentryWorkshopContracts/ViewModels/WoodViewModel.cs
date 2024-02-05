using CarpentryWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopContracts.ViewModels
{
    public class WoodViewModel : IWoodModel
    {
        public int Id { get; set; }
        [DisplayName("Название изделия")]
        public string WoodName { get; set; } = string.Empty;
        [DisplayName("Цена")]
        public double Price { get; set; }
        public Dictionary<int, (IComponentModel, int)> WoodComponents
        {
            get;
            set;
        } = new();
    }
}
