using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarpentryWorkshopDatabaseImplement.Models
{
    public class Component : IComponentModel
    {
        public int Id { get; private set; }

        [Required]
        public string ComponentName { get; private set; } = string.Empty;

        [Required]
        public double Cost { get; set; }

        [ForeignKey("ComponentId")]
        public virtual List<WoodComponent> WoodComponents { get; set; } = new();

        public static Component? Create(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Component()
            {
                Id = model.Id,
                ComponentName = model.ComponentName,
                Cost = model.Cost
            };
        }

        public static Component Create(ComponentViewModel model)
        {
            return new Component
            {
                Id = model.Id,
                ComponentName = model.ComponentName,
                Cost = model.Cost
            };
        }

        public void Update(ComponentBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            ComponentName = model.ComponentName;
            Cost = model.Cost;
        }

        public ComponentViewModel GetViewModel => new()
        {
            Id = Id,
            ComponentName = ComponentName,
            Cost = Cost
        };
    }
}