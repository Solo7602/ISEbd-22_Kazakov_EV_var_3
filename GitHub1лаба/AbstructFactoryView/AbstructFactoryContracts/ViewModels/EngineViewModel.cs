using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace AbstructFactoryContracts.ViewModels
{
    public class EngineViewModel
    {
        public int Id { get; set; }
        [DisplayName("Двигатели")]
        public string Engine { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> EngineDetails { get; set; }
    }
}
