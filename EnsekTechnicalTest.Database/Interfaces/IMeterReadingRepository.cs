using EnsekTechnicalTest.Models.Database;

namespace EnsekTechnicalTest.Database.Interfaces
{
    public interface IMeterReadingRepository
    {
        public Task<List<MeterReading>> GetByAccountId(int accountId);
        public Task<List<MeterReading>> GetAll();
        public Task<int> Save(List<MeterReading> readings);
    }
}
