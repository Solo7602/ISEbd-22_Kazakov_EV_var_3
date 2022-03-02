using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _AbstractFactoryListImplement.Models
{
    public class Engines
    {
        public int Id { get; set; }
        public string Engine{ get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> EngineDetails { get; set; }
    }
}
