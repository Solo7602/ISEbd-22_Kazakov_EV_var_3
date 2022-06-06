using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDatabaseImplement.Models
{
    public class Engine
    {
        public int Id { get; set; }
        [Required]
        public string EngineName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("EngineId")]
        public virtual List<EngineDetail> EngineDetails { get; set; }
        [ForeignKey("EngineId")]
        public virtual List<Order> Orders { get; set; }

    }
}
