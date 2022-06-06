using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using AbstractContracts.Attributes;

namespace AbstructFactoryContracts.ViewModels
{
    public class DetailViewModel
    {
        public int Id { get; set; }
        [Column(title: "Название компонента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Detail { get; set; }
    }
}
