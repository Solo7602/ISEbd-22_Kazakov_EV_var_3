using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.BusinessLogicContracts;
using AbstructFactoryContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AbstractFactoryRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IEngineLogic _product;
        public MainController(IOrderLogic order, IEngineLogic product)
        {
            _order = order;
            _product = product;
        }
        [HttpGet]
        public List<EngineViewModel> GetProductList() => _product.Read(null)?.ToList();
        [HttpGet]
        public EngineViewModel GetProduct(int productId) => _product.Read(new
       EngineBindingModel
        { Id = productId })?[0];
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new
       OrderBindingModel
        { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
       _order.CreateOrder(model);
    }
}
