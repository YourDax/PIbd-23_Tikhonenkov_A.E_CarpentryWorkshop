using CarpentryWorkshopContracts.Attributes;
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
        [Column(visible: false)]
        public int Id { get; set; }

        [Column(title: "Название изделия", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string WoodName { get; set; } = string.Empty;

        [Column(title: "Цена", width: 70)]
        public double Price { get; set; }

        [Column(visible: false)]
        public Dictionary<int, (IComponentModel, int)> WoodComponents
        {
            get;
            set;
        } = new();
    }
}
