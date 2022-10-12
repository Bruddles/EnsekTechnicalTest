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
        private readonly IAccountRepository _accountRepository;
        private readonly ICsvParser<MeterReading> _csvParser;

        public MeterReadingService(
            IMeterReadingRepository meterReadingRepository,
            IAccountRepository accountRepository,
            ICsvParser<MeterReading> csvParser)
        {
            this._meterReadingRepository = meterReadingRepository;
            this._accountRepository = accountRepository;
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

        public async Task<int> Process(Stream stream)
        {
            var savedLinesCount = 0;
            using var reader = new StreamReader(stream);
            var result = _csvParser.Parse(reader);

            var validationResult = await this.Validate(result.ParsedLines);

            if (validationResult.Count > 0)
            {
                savedLinesCount = await this.Save(validationResult);
            }

            return savedLinesCount;
        }

        public async Task<List<MeterReading>> Validate(List<MeterReading> readings)
        {
            // Remove any meter readings not in NNNNNN
            var filtered = readings.Where(r => r.MeterReadValue <= 99999);

            // Get all accounts for readings
            var accounts = await _accountRepository.GetForIds(filtered.Select(f => f.AccountId).ToArray());

            if (accounts == null)
            {
                return new List<MeterReading>();
            }

            // Filter out readings with an invalid account
            filtered = filtered.Where(r => accounts.Any(a => a.AccountId == r.AccountId));

            // Get all readings for the accounts
            var existingReadingsDict = await _meterReadingRepository.GetByAccountIds(filtered.Select(f => f.AccountId).ToArray());

            filtered = filtered.Where(r =>
            {
                if (existingReadingsDict.TryGetValue(r.AccountId, out var existingReadings))
                {
                    // Check we are not submitting a duplicate or a record with a date behind a current record
                    return !(existingReadings.Any(er =>
                        (er.MeterReadValue == r.MeterReadValue
                            && er.MeterReadingDateTime == r.MeterReadingDateTime
                        ) || er.MeterReadingDateTime > r.MeterReadingDateTime));
                }

                return true;
            });

            return filtered.ToList();
        }

        public Task<int> Save(List<MeterReading> readings)
        {
            return _meterReadingRepository.Save(readings);
        }
    }
}
