namespace CarpentryWorkshopDataModels.Models
{
    public interface IShopModel : IId
    {
        string ShopName { get; }
        string Address { get; }
        DateTime DateOpen { get; }
        Dictionary<int, (IWoodModel, int)> ShopWoods { get; }
        public int WoodMaxCount { get; }
    }
}
