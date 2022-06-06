using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstructFactoryContracts.StoragesContracts
{
    public interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();
        List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model);
        MessageInfoViewModel GetElement(MessageInfoBindingModel model);
        void Insert(MessageInfoBindingModel model);

    }
}
