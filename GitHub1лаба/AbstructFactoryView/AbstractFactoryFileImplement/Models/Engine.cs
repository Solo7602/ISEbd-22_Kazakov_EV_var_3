using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryFileImplement.Models
{
    public class Engine
    {
        public int Id { get; set; }
        public string EngineName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> EngineDetail { get; set; }
    }
}
