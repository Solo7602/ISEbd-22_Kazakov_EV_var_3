﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.ViewModels;


namespace AbstructFactoryContracts.StoragesContracts
{
    public interface IWareHouseStorage
    {
        List<WareHouseViewModel> GetFullList();
        List<WareHouseViewModel> GetFilteredList(WareHouseBindingModel model);
        WareHouseViewModel GetElement(WareHouseBindingModel model);
        void Insert(WareHouseBindingModel model);
        void Update(WareHouseBindingModel model);
        void Delete(WareHouseBindingModel model);
    }
}
