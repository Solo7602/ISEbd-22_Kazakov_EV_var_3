using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace AbstructFactoryContracts.ViewModels
{
    public class DetailViewModel
    {
        public int Id { get; set; }
        [DisplayName("Детали")]
        public string Detail { get; set; }
    }
}
