using CarpentryWorkshopDataModels.Models;
using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CarpentryWorkshopFileImplement;

namespace CarpentryWorkshopFileImplement.Models
{
    public class Shop : IShopModel
    {
        public int Id { get; private set; }
        public string ShopName { get; private set; }
        public string Address { get; private set; }
        public DateTime DateOpen { get; private set; }
        public Dictionary<int, int> Woods { get; private set; } = new();
        public int WoodMaxCount { get; private set; }

        private Dictionary<int, (IWoodModel, int)>? _shopWoods = null;

        public Dictionary<int, (IWoodModel, int)> ShopWoods
        {
            get
            {
                if (_shopWoods == null)
                {
                    var source = DataFileSingleton.GetInstance();
                    _shopWoods = Woods.ToDictionary(x => x.Key, y => ((source.Woods.FirstOrDefault(z => z.Id == y.Key) as IWoodModel)!, y.Value));
                }
                return _shopWoods;
            }
        }


        public static Shop? Create(ShopBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Shop()
            {
                Id = model.Id,
                ShopName = model.ShopName,
                Address = model.Address,
                DateOpen = model.DateOpen,
                Woods = model.ShopWoods.ToDictionary(x => x.Key, x => x.Value.Item2),
                WoodMaxCount = model.WoodMaxCount
            };
        }

        public static Shop? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }
            return new()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                ShopName = element.Element("ShopName")!.Value,
                Address = element.Element("Address")!.Value,
                DateOpen = Convert.ToDateTime(element.Element("DateOpen")!.Value),
                Woods = element.Element("ShopWoods")!.Elements("ShopWood")!.ToDictionary(x => Convert.ToInt32(x.Element("Key")?.Value),
                x => Convert.ToInt32(x.Element("Value")?.Value)),
                WoodMaxCount = Convert.ToInt32(element.Element("WoodMaxCount")!.Value)
            };
        }

        public void Update(ShopBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            ShopName = model.ShopName;
            Address = model.Address;
            DateOpen = model.DateOpen;
            WoodMaxCount = model.WoodMaxCount;
            Woods = model.ShopWoods.ToDictionary(x => x.Key, x => x.Value.Item2);
            _shopWoods = null;
        }

        public ShopViewModel GetViewModel => new()
        {
            Id = Id,
            ShopName = ShopName,
            Address = Address,
            DateOpen = DateOpen,
            ShopWoods = ShopWoods,
            WoodMaxCount = WoodMaxCount
        };

        public XElement GetXElement => new("Shop",
            new XAttribute("Id", Id),
            new XElement("ShopName", ShopName),
            new XElement("Address", Address),
            new XElement("DateOpen", DateOpen.ToString()),
            new XElement("ShopWoods", Woods.Select(
                x => new XElement("ShopWood", new XElement("Key", x.Key), new XElement("Value", x.Value))).ToArray()),
            new XElement("WoodMaxCount", WoodMaxCount.ToString())
            );

        public void WoodsUpdate()
        {
            _shopWoods = null;
        }
    }
}