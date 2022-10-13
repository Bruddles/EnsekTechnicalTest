using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekTechnicalTest.Models
{
    public class ProcessResult
    {
        public int LinesSaved { get; set; }
        public int LinesFailed { get; set; }
        public int TotalLines { get; set; }
    }
}
