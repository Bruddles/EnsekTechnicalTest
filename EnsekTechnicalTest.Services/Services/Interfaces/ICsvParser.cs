using EnsekTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekTechnicalTest.Services.Services.Interfaces
{
    public interface ICsvParser<T>
    {
        public CsvParserResult<T> Parse(StreamReader streamReader);
    }
}
