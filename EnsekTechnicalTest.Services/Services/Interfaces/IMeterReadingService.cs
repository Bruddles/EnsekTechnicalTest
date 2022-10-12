using EnsekTechnicalTest.Models;
using EnsekTechnicalTest.Models.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekTechnicalTest.Services.Services.Interfaces
{
    public interface IMeterReadingService
    {
        public Task<List<MeterReading>> GetByAccountId(int accountId);
        public Task<List<MeterReading>> GetAll();
        public Task<int> Save(List<MeterReading> readings);

        public Task<ProcessResponse> Process(Stream stream);
    }
}
