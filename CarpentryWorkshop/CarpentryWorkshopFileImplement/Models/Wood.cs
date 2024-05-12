using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarpentryWorkshopFileImplement.Models
{
    [DataContract]
    public class Wood : IWoodModel
    {
        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public string WoodName { get; private set; } = string.Empty;

        [DataMember]
        public double Price { get; private set; }
        public Dictionary<int, int> Components { get; private set; } = new();
        private Dictionary<int, (IComponentModel, int)>? _woodComponents = null;

        [DataMember]
        public Dictionary<int, (IComponentModel, int)> WoodComponents
        {
            get
            {
                if (_woodComponents == null)
                {
                    var source = DataFileSingleton.GetInstance();
                    _woodComponents = Components.ToDictionary(x => x.Key, y => ((source.Components.FirstOrDefault(z => z.Id == y.Key) as IComponentModel)!, y.Value));
                }
                return _woodComponents;
            }
        }
        public static Wood? Create(WoodBindingModel model)
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
                Components = model.WoodComponents.ToDictionary(x => x.Key, x => x.Value.Item2)
            };
        }
        public static Wood? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }
            return new Wood()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                WoodName = element.Element("WoodName")!.Value,
                Price = Convert.ToDouble(element.Element("Price")!.Value),
                Components = element.Element("WoodComponents")!.Elements("WoodComponent").ToDictionary(x => Convert.ToInt32(x.Element("Key")?.Value), x => Convert.ToInt32(x.Element("Value")?.Value))
            };
        }
        public void Update(WoodBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            WoodName = model.WoodName;
            Price = model.Price;
            Components = model.WoodComponents.ToDictionary(x => x.Key, x => x.Value.Item2);
            _woodComponents = null;
        }
        public WoodViewModel GetViewModel => new()
        {
            Id = Id,
            WoodName = WoodName,
            Price = Price,
            WoodComponents = WoodComponents
        };
        public XElement GetXElement => new("Wood",
        new XAttribute("Id", Id),
        new XElement("WoodName", WoodName),
        new XElement("Price", Price.ToString()),
        new XElement("WoodComponents", Components.Select(x => new XElement("WoodComponent",
        new XElement("Key", x.Key),
        new XElement("Value", x.Value)))
        .ToArray()));
    }
}
