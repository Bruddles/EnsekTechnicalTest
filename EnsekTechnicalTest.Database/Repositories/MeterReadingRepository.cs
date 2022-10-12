using EnsekTechnicalTest.Database.Context;
using EnsekTechnicalTest.Database.Interfaces;
using EnsekTechnicalTest.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekTechnicalTest.Database.Repositories
{
    public class MeterReadingRepository : IMeterReadingRepository
    {
        private readonly EnsekContext _context;

        public MeterReadingRepository(EnsekContext context)
        {
            this._context = context;
        }

        public Task<List<MeterReading>> GetAll()
        {
            return _context.MeterReadings.ToListAsync();
        }

        public Task<List<MeterReading>> GetByAccountId(int accountId)
        {
            return _context.MeterReadings.Where(mr => mr.AccountId == accountId).ToListAsync();
        }

        public async Task<int> Save(List<MeterReading> readings)
        {
            await _context.MeterReadings.AddRangeAsync(readings);
            return await _context.SaveChangesAsync();
        }


        public async Task<Dictionary<int, List<MeterReading>>> GetByAccountIds(int[] accountIds)
        {
            var result = new Dictionary<int, List<MeterReading>>();

            var readings = await _context.MeterReadings
                .Where(m => accountIds.Contains(m.AccountId)).ToListAsync();

            foreach(MeterReading m in readings)
            {
                if (result.TryGetValue(m.AccountId, out var list))
                {
                    list.Add(m);
                } else
                {
                    result.Add(m.AccountId, new List<MeterReading> { m });
                }
            }

            return result;
        }
    }
}
