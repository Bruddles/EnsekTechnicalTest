using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekTechnicalTest.Models
{
    public class CsvParserResult<T>
    {
        public List<string> FailedToParseLines { get; set; }
        public List<T> ParsedLines { get; set; }

    }
}
