using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.BusinessLogicContracts;
using AbstructFactoryContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AbstractFactoryRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientLogic _logic;
        private readonly IMessageInfoLogic _logicM;
        public ClientController(IClientLogic logic, IMessageInfoLogic logicM)
        {
            _logicM= logicM;
            _logic = logic;
        }
        [HttpGet]
        public ClientViewModel Login(string login, string password)
        {
            var list = _logic.Read(new ClientBindingModel
            {
                Email = login,
                Password = password
            });
            return (list != null && list.Count > 0) ? list[0] : null;
        }
        [HttpGet]
        public List<MessageInfoViewModel> GetMessages(int clientId) => _logicM.Read(new MessageInfoBindingModel { ClientId = clientId });
        [HttpPost]
        public void Register(ClientBindingModel model) =>
        _logic.CreateOrUpdate(model);
        [HttpPost]
        public void UpdateData(ClientBindingModel model) =>
        _logic.CreateOrUpdate(model);
    }
}
