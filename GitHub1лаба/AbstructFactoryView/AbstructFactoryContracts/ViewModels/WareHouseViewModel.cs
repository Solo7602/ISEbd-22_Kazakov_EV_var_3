using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstructFactoryContracts.Enums;
using System.ComponentModel;

namespace AbstructFactoryContracts.ViewModels
{
    public class WareHouseViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        public string WareHouseName { get; set; }

        [DisplayName("ФИО ответственного")]
        public string ResponsiblePersonFIO { get; set; }

        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> WareHouseComponents { get; set; }
    }
}
