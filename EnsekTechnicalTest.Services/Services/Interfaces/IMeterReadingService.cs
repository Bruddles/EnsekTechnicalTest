using EnsekTechnicalTest.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekTechnicalTest.Services.Services.Interfaces
{
    public interface IMeterReadingService
    {
        public Task<List<MeterReading>> GetByAccountId(int accountId);
        public Task<List<MeterReading>> GetAll();
        public Task Save(List<MeterReading> readings);

        public Task Process(StreamReader stream);
    }
}
