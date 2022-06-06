using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.ViewModels;

namespace AbstructFactoryContracts.StoragesContracts
{
    public interface IDetailStorage
    {
        List<DetailViewModel> GetFullList();
        List<DetailViewModel> GetFilteredList(DetailBindingModel model);
        DetailViewModel GetElement(DetailBindingModel model);
        void Insert(DetailBindingModel model);
        void Update(DetailBindingModel model);
        void Delete(DetailBindingModel model);
    }
}

