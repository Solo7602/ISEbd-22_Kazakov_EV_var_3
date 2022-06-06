using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.ViewModels;

namespace AbstructFactoryContracts.BusinessLogicContracts
{
    public interface IEngineLogic
    {
        List<EngineViewModel> Read(EngineBindingModel model);
        void CreateOrUpdate(EngineBindingModel model);
        void Delete(EngineBindingModel model);
    }
}
