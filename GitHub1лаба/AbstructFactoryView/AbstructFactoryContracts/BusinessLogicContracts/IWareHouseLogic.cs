using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.ViewModels;

namespace AbstructFactoryContracts.BusinessLogicContracts
{
    public interface IWareHouseLogic
    {
        public List<WareHouseViewModel> Read(WareHouseBindingModel model);
        void CreateOrUpdate(WareHouseBindingModel model);
        void Delete(WareHouseBindingModel model);
        void Replenishment(WareHouseReplenishmentBindingModel model);
    }
}
