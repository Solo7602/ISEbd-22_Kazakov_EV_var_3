using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.ViewModels;

namespace AbstructFactoryContracts.StoragesContracts
{
    public interface IEngineStorage
    {
        List<EngineViewModel> GetFullList();
        List<EngineViewModel> GetFilteredList(EngineBindingModel model);
        EngineViewModel GetElement(EngineBindingModel model);
        void Insert(EngineBindingModel model);
        void Update(EngineBindingModel model);
        void Delete(EngineBindingModel model);
    }
}
