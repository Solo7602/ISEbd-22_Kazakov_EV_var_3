using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace AbstractFactoryDatabaseImplement.Models
{
    public class EngineDetail
    {
        
        public int Id { get; set; }
        public int EngineId { get; set; }
        public int DetailId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Detail Detail { get; set; }
        public virtual Engine Engine { get; set; }

    }
}
