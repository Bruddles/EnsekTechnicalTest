using EnsekTechnicalTest.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekTechnicalTest.Services.Tests
{
    public class MeterReadingCsvParserTests
    {

        [Test]
        public void Parse_ParsesGoodLine()
        {
            var parser = new MeterReadingCsvParser();

            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            using (var reader = new StreamReader(stream))
            {
                writer.WriteLine("AccountId,MeterReadingDateTime,MeterReadValue");
                writer.WriteLine("2344,22/04/2019 09:24,01002");
                writer.Flush();
                stream.Position = 0;

                var result = parser.Parse(reader);

                Assert.AreEqual(0, result.FailedToParseLines.Count);
                Assert.AreEqual(1, result.ParsedLines.Count);
            }
        }

        [Test]
        public void Parse_DoesntParseBadAccountId()
        {
            var parser = new MeterReadingCsvParser();

            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            using (var reader = new StreamReader(stream))
            {
                writer.WriteLine("AccountId,MeterReadingDateTime,MeterReadValue");
                writer.WriteLine("aaaa,22/04/2019 09:24,01002");
                writer.Flush();
                stream.Position = 0;

                var result = parser.Parse(reader);

                Assert.AreEqual(1, result.FailedToParseLines.Count);
                Assert.AreEqual(0, result.ParsedLines.Count);
            }
        }

        [Test]
        public void Parse_DoesntParseBadMeterReadingDateTime()
        {
            var parser = new MeterReadingCsvParser();

            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            using (var reader = new StreamReader(stream))
            {
                writer.WriteLine("AccountId,MeterReadingDateTime,MeterReadValue");
                writer.WriteLine("2344,22/04/201a9 09:24,01002");
                writer.Flush();
                stream.Position = 0;

                var result = parser.Parse(reader);

                Assert.AreEqual(1, result.FailedToParseLines.Count);
                Assert.AreEqual(0, result.ParsedLines.Count);
            }
        }

        [Test]
        public void Parse_DoesntParseBadMeterReadValue()
        {
            var parser = new MeterReadingCsvParser();

            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            using (var reader = new StreamReader(stream))
            {
                writer.WriteLine("AccountId,MeterReadingDateTime,MeterReadValue");
                writer.WriteLine("2344,22/04/2019 09:24,0X1002");
                writer.Flush();
                stream.Position = 0;

                var result = parser.Parse(reader);

                Assert.AreEqual(1, result.FailedToParseLines.Count);
                Assert.AreEqual(0, result.ParsedLines.Count);
            }
        }

        [Test]
        public void Parse_DoesntParseBadMeterReadValue_Over5Digits()
        {
            var parser = new MeterReadingCsvParser();

            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            using (var reader = new StreamReader(stream))
            {
                writer.WriteLine("AccountId,MeterReadingDateTime,MeterReadValue");
                writer.WriteLine("2344,22/04/2019 09:24,011002");
                writer.Flush();
                stream.Position = 0;

                var result = parser.Parse(reader);

                Assert.AreEqual(1, result.FailedToParseLines.Count);
                Assert.AreEqual(0, result.ParsedLines.Count);
            }
        }
    }
}
