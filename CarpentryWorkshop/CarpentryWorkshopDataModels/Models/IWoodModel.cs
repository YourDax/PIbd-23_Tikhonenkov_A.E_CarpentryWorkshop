using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopDataModels.Models
{
    public interface IWoodModel : IId
    {
        string WoodName { get; }
        double Price { get; }
        Dictionary<int, (IComponentModel, int)> WoodComponents { get; }
    }
}
