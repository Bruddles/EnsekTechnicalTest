using CsvHelper;
using EnsekTechnicalTest.Models;
using EnsekTechnicalTest.Models.Database;
using EnsekTechnicalTest.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace EnsekTechnicalTest.Services.Services
{
    public class CsvParser<T> : ICsvParser<T>
    {
        public List<T> Parse(StreamReader streamReader)
        {
            var records = new List<T>();
            using (var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            {
                records = csv.GetRecords<T>().ToList();
            }

            return records;
        }
    }
}
