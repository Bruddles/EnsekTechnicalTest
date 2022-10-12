using CsvHelper;
using CsvHelper.Configuration;
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
using static System.Net.Mime.MediaTypeNames;

namespace EnsekTechnicalTest.Services.Services
{
    public class MeterReadingCsvParser : ICsvParser<MeterReading>
    {
        internal class MeterReadingMap: ClassMap<MeterReading>
        {
            public MeterReadingMap()
            {
                Map(m => m.AccountId).Name("AccountId");
                Map(m => m.MeterReadingDateTime).Name("MeterReadingDateTime").TypeConverterOption.Format("dd/MM/yyyy HH:mm");
                Map(m => m.MeterReadValue).Name("MeterReadValue");
            }
        }

        public CsvParserResult<MeterReading> Parse(StreamReader streamReader)
        {
            var records = new List<MeterReading>();
            var failedLines = new List<string>();

            var malformedRow = false;
            var conf = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                ReadingExceptionOccurred = args =>
                {
                    malformedRow = true;
                    failedLines.Add(args.Exception.Context.Parser.RawRecord);
                    return false;
                }
            };
            using (var csv = new CsvReader(streamReader, conf))
            {
                csv.Context.RegisterClassMap<MeterReadingMap>();

                while (csv.Read())
                {
                    var record = csv.GetRecord<MeterReading>();
                    if (!malformedRow)
                    {
                        records.Add(record);
                    }

                    malformedRow = false;
                }
            }

            return new CsvParserResult<MeterReading>
            {
                FailedToParseLines = failedLines,
                ParsedLines = records
            };
        }
    }
}
