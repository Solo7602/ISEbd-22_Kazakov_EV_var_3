using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.ViewModels;


namespace AbstructFactoryContracts.BusinessLogicContracts
{
    public interface IDetailLogic
    {
        List<DetailViewModel> Read(DetailBindingModel model);
        void CreateOrUpdate(DetailBindingModel model);
        void Delete(DetailBindingModel model);
    }
}
