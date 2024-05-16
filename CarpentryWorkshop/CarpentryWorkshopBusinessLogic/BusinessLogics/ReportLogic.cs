using CarpentryWorkshopBusinessLogic.OfficePackage;
using CarpentryWorkshopBusinessLogic.OfficePackage.HelperModels;
using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.BusinessLogicsContracts;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopContracts.ViewModels;

namespace CarpentryWorkshopBusinessLogic.BusinessLogics
{
    public class ReportLogic : IReportLogic
    {
        private readonly IComponentStorage _componentStorage;

        private readonly IWoodStorage _woodStorage;

        private readonly IOrderStorage _orderStorage;

        private readonly IShopStorage _shopStorage;

        private readonly AbstractSaveToExcel _saveToExcel;

        private readonly AbstractSaveToWord _saveToWord;

        private readonly AbstractSaveToPdf _saveToPdf;

        public ReportLogic(IWoodStorage woodStorage, IComponentStorage componentStorage, IOrderStorage orderStorage, IShopStorage shopStorage,
            AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord, AbstractSaveToPdf saveToPdf)
        {
            _woodStorage = woodStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
            _shopStorage = shopStorage;

            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }

        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportWoodComponentViewModel> GetWoodComponent()
        {

            var woods = _woodStorage.GetFullList();

            var list = new List<ReportWoodComponentViewModel>();

            foreach (var wood in woods)
            {
                var record = new ReportWoodComponentViewModel
                {
                    WoodName = wood.WoodName,
                    Components = new List<(string, int)>(),
                    TotalCount = 0
                };
                foreach (var component in wood.WoodComponents)
                {
                    record.Components.Add(new (component.Value.Item1.ComponentName, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }

                list.Add(record);
            }

            return list;
        }

        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderSearchModel { DateFrom = model.DateFrom, DateTo = model.DateTo })
                    .Select(x => new ReportOrdersViewModel
                    {
                        Id = x.Id,
                        DateCreate = x.DateCreate,
                        WoodName = x.WoodName,
                        Status = x.Status.ToString(),
                        Sum = x.Sum
                    })
                    .ToList();
        }

        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveComponentsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                Woods = _woodStorage.GetFullList()
            });
        }

        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveWoodComponentToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                WoodComponents = GetWoodComponent()
            });
        }

        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom!.Value,
                DateTo = model.DateTo!.Value,
                Orders = GetOrders(model)
            });
        }
        public List<ReportShopsViewModel> GetShops()
        {
            return _shopStorage.GetFullList().Select(x => new ReportShopsViewModel
            {
                ShopName = x.ShopName,
                Woods = x.ShopWoods.Select(x => (x.Value.Item1.WoodName, x.Value.Item2)).ToList(),
                TotalCount = x.ShopWoods.Select(x => x.Value.Item2).Sum()
            }).ToList();
        }

        public List<ReportGroupOrdersViewModel> GetGroupedOrders()
        {
            return _orderStorage.GetFullList().GroupBy(x => x.DateCreate.Date).Select(x => new ReportGroupOrdersViewModel
            {
                Date = x.Key,
                OrdersCount = x.Count(),
                OrdersSum = x.Select(y => y.Sum).Sum()
            }).ToList();
        }

        public void SaveShopsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateShopsDoc(new WordShopInfo
            {
                FileName = model.FileName,
                Title = "Список магазинов",
                Shops = _shopStorage.GetFullList()
            });
        }

        public void SaveShopsToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateShopWoodsReport(new ExcelShop
            {
                FileName = model.FileName,
                Title = "Наполненость магазинов",
                ShopWoods = GetShops()
            });
        }

        public void SaveGroupedOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateGroupedOrdersDoc(new PdfGroupedOrdersInfo
            {
                FileName = model.FileName,
                Title = "Список заказов сгруппированных по дате заказов",
                GroupedOrders = GetGroupedOrders()
            });
        }
    }
}