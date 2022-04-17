using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstructFactoryContracts.ViewModels
{
    public class ReportEngineDetailViewModel
    {
        public string EngineName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Details { get; set; }

    }
}
