using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstructFactoryContracts.BindingModels
{
    public class EngineBindingModel
    {
        public int? Id { get; set; }
        public string Engine { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> EngineDetails { get; set; }
    }
}
