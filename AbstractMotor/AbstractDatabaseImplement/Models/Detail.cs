using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDatabaseImplement.Models
{
    public class Detail
    {
        public int Id { get; set; }
        [Required]
        public string DetailName { get; set; }
        [ForeignKey("DetailId")]
        public virtual List<EngineDetail> EngineDetails { get; set; }
    }
}
