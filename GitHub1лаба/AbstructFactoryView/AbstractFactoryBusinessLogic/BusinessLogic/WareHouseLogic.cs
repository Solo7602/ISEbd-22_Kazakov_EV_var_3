using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.BusinessLogicContracts;
using AbstructFactoryContracts.Enums;
using AbstructFactoryContracts.StoragesContracts;
using AbstructFactoryContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryBusinessLogic.BusinessLogic
{
    public class WareHouseLogic : IWareHouseLogic
    {
        private readonly IWareHouseStorage _wareHouseStorage;

        private readonly IDetailStorage _componentStorage;

        public WareHouseLogic(IWareHouseStorage wareHouseStorage, IDetailStorage componentsStorage)
        {
            _wareHouseStorage = wareHouseStorage;
            _componentStorage = componentsStorage;
        }
        public List<WareHouseViewModel> Read(WareHouseBindingModel model)
        {
            if (model == null)
            {
                return _wareHouseStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<WareHouseViewModel> { _wareHouseStorage.GetElement(model) };
            }
            return _wareHouseStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(WareHouseBindingModel model)
        {
            var element = _wareHouseStorage.GetElement(new WareHouseBindingModel
            {
                WareHouseName = model.WareHouseName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            if (model.Id.HasValue)
            {
                _wareHouseStorage.Update(model);
            }
            else
            {
                _wareHouseStorage.Insert(model);
            }
        }

        public void Delete(WareHouseBindingModel model)
        {
            var element = _wareHouseStorage.GetElement(new WareHouseBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _wareHouseStorage.Delete(model);
        }

        public void Replenishment(WareHouseReplenishmentBindingModel model)
        {
            var wareHouse = _wareHouseStorage.GetElement(new WareHouseBindingModel
            {
                Id = model.WareHouseId
            });

            var component = _componentStorage.GetElement(new DetailBindingModel
            {
                Id = model.ComponentId
            });
            if (wareHouse == null)
            {
                throw new Exception("Не найден склад");
            }
            if (component == null)
            {
                throw new Exception("Не найдена комплектующая");
            }
            if (wareHouse.WareHouseComponents.ContainsKey(model.ComponentId))
            {
                wareHouse.WareHouseComponents[model.ComponentId] =
                    (component.Detail, wareHouse.WareHouseComponents[model.ComponentId].Item2 + model.Count);
            }
            else
            {
                wareHouse.WareHouseComponents.Add(component.Id, (component.Detail, model.Count));
            }
            _wareHouseStorage.Update(new WareHouseBindingModel
            {
                Id = wareHouse.Id,
                WareHouseName = wareHouse.WareHouseName,
                ResponsiblePersonFCS = wareHouse.ResponsiblePersonFIO,
                DateCreate = wareHouse.DateCreate,
                WareHouseComponents = wareHouse.WareHouseComponents
            });
        }
    }
}
