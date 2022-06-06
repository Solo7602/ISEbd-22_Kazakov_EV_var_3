using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using AbstractContracts.Attributes;

namespace AbstructFactoryContracts.ViewModels
{
    public class EngineViewModel
    {
        public int Id { get; set; }
        [Column(title: "Название двигателя", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Engine { get; set; }
        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> EngineDetails { get; set; }
    }
}
