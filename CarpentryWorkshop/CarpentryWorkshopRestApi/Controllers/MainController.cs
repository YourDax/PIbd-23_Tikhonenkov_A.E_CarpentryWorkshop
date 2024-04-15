using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.BusinessLogicsContracts;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarpentryWorkshopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : Controller
    {
        private readonly ILogger _logger;

        private readonly IOrderLogic _order;

        private readonly IWoodLogic _Wood;

        public MainController(ILogger<MainController> logger, IOrderLogic order, IWoodLogic Wood)
        {
            _logger = logger;
            _order = order;
            _Wood = Wood;
        }

        [HttpGet]
        public List<WoodViewModel>? GetWoodList()
        {
            try
            {
                return _Wood.ReadList(null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения списка изделий");
                throw;
            }
        }

        [HttpGet]
        public WoodViewModel? GetWood(int WoodId)
        {
            try
            {
                return _Wood.ReadElement(new WoodSearchModel { Id = WoodId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения изделия по id={Id}", WoodId);
                throw;
            }
        }

        [HttpGet]
        public List<OrderViewModel>? GetOrders(int clientId)
        {
            try
            {
                return _order.ReadList(new OrderSearchModel { ClientId = clientId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения списка заказов клиента id={Id}", clientId);
                throw;
            }
        }

        [HttpPost]
        public void CreateOrder(OrderBindingModel model)
        {
            try
            {
                _order.CreateOrder(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания заказа");
                throw;
            }
        }
    }
}
