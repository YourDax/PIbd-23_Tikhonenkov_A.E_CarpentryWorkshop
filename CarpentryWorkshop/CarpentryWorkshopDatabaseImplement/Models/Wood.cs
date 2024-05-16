using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarpentryWorkshopDatabaseImplement.Models
{
    public class Wood : IWoodModel
    {
        public int Id { get; set; }
        [Required]
        public string WoodName { get; set; } = string.Empty;
        [Required]
        public double Price { get; set; }
        private Dictionary<int, (IComponentModel, int)>? _woodComponents = null;
        [NotMapped]
        public Dictionary<int, (IComponentModel, int)> WoodComponents
        {
            get
            {
                if (_woodComponents == null)
                {
                    _woodComponents = Components
                    .ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component as IComponentModel, recPC.Count));
                }
                return _woodComponents;
            }
        }
        [ForeignKey("WoodId")]
        public virtual List<WoodComponent> Components { get; set; } = new();
        [ForeignKey("WoodId")]
        public virtual List<Order> Orders { get; set; } = new();
        [ForeignKey("WoodId")]
        public virtual List<ShopWood> ShopWoods { get; set; } = new();
        public static Wood Create(CarpentryWorkshopDatabase context, WoodBindingModel model)
        {
            return new Wood()
            {
                Id = model.Id,
                WoodName = model.WoodName,
                Price = model.Price,
                Components = model.WoodComponents.Select(x => new
               WoodComponent
                {
                    Component = context.Components.First(y => y.Id == x.Key),
                    Count = x.Value.Item2
                }).ToList()
            };
        }
        public void Update(WoodBindingModel model)
        {
            WoodName = model.WoodName;
            Price = model.Price;
        }
        public WoodViewModel GetViewModel => new()
        {
            Id = Id,
            WoodName = WoodName,
            Price = Price,
            WoodComponents = WoodComponents
        };
        public void UpdateComponents(CarpentryWorkshopDatabase context, WoodBindingModel model)
        {
            var woodComponents = context.WoodComponents.Where(rec => rec.WoodId == model.Id).ToList();
            if (woodComponents != null && woodComponents.Count > 0)
            { // удалили те, которых нет в модели
                context.WoodComponents.RemoveRange(woodComponents.Where(rec => !model.WoodComponents.ContainsKey(rec.ComponentId)));
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in woodComponents)
                {
                    updateComponent.Count = model.WoodComponents[updateComponent.ComponentId].Item2;
                    model.WoodComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            var wood = context.Woods.First(x => x.Id == Id);
            foreach (var pc in model.WoodComponents)
            {
                context.WoodComponents.Add(new WoodComponent
                {
                    Wood = wood,
                    Component = context.Components.First(x => x.Id == pc.Key),
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            _woodComponents = null;
        }
    }
}