using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.BusinessLogicContracts;
using AbstructFactoryContracts.StoragesContracts;
using AbstructFactoryContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryBusinessLogic.BusinessLogic
{
    public class EngineLogic : IEngineLogic
    {
        private readonly IEngineStorage _engineStorage;
        public EngineLogic(IEngineStorage engineStorage)
        {
            _engineStorage = engineStorage;
        }
        public List<EngineViewModel> Read(EngineBindingModel model)
        {
            if (model == null)
            {
                return _engineStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<EngineViewModel> { _engineStorage.GetElement(model)
                };
            }
            return _engineStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(EngineBindingModel model)
        {
            var element = _engineStorage.GetElement(new EngineBindingModel
            {
                Engine = model.Engine
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть пакет с таким названием");
            }
            if (model.Id.HasValue)
            {
                _engineStorage.Update(model);
            }
            else
            {
                _engineStorage.Insert(model);
            }
        }

        public void Delete(EngineBindingModel model)
        {
            var element = _engineStorage.GetElement(new EngineBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Пакет не найден");
            }
            _engineStorage.Delete(model);
        }
    }
}
