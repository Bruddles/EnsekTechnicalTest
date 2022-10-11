using EnsekTechnicalTest.Database.Interfaces;
using EnsekTechnicalTest.Models;
using EnsekTechnicalTest.Models.Database;
using EnsekTechnicalTest.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekTechnicalTest.Services.Services
{
    public class MeterReadingService : IMeterReadingService
    {
        private readonly IMeterReadingRepository _meterReadingRepository;
        private readonly ICsvParser<MeterReading> _csvParser;

        public MeterReadingService(IMeterReadingRepository meterReadingRepository, ICsvParser<MeterReading> csvParser)
        {
            this._meterReadingRepository = meterReadingRepository;
            this._csvParser = csvParser;
        }

        public Task<List<MeterReading>> GetAll()
        {
            return _meterReadingRepository.GetAll();
        }

        public Task<List<MeterReading>> GetByAccountId(int accountId)
        {
            return _meterReadingRepository.GetByAccountId(accountId);
        }

        public Task Process(StreamReader stream)
        {
            var records = _csvParser.Parse(stream);

            if (records != null)
            {
                this.Save(records);
            }

            return Task.CompletedTask;
        }

        public Task Save(List<MeterReading> readings)
        {
            return _meterReadingRepository.Save(readings);
        }
    }
}
