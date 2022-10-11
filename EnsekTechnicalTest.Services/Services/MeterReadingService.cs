using EnsekTechnicalTest.Database.Interfaces;
using EnsekTechnicalTest.Models;
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

        public MeterReadingService(IMeterReadingRepository meterReadingRepository)
        {
            this._meterReadingRepository = meterReadingRepository;
        }

        public Task<List<MeterReading>> GetAll()
        {
            return _meterReadingRepository.GetAll();
        }

        public Task<List<MeterReading>> GetByAccountId(int accountId)
        {
            return _meterReadingRepository.GetByAccountId(accountId);
        }

        public Task Save(List<MeterReading> readings)
        {
            return _meterReadingRepository.Save(readings);
        }
    }
}
