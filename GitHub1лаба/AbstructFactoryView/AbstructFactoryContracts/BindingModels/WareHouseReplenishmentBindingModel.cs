﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstructFactoryContracts.BindingModels
{
    public class WareHouseReplenishmentBindingModel
    {
        public int ComponentId { get; set; }
        public int WareHouseId { get; set; }
        public int Count { get; set; }
    }
}
