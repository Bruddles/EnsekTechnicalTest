using EnsekTechnicalTest.Database.Interfaces;
using EnsekTechnicalTest.Models.Database;
using EnsekTechnicalTest.Services.Services;
using EnsekTechnicalTest.Services.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekTechnicalTest.Services.Tests
{
    internal class MeterReadingServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAll_ReturnsMeterReadings()
        {
            var mockReadings = new List<MeterReading>()
            {
                new MeterReading() {
                    Id = 1,
                    AccountId = 1,
                    MeterReadingDateTime = DateTime.MinValue,
                    MeterReadValue = 1234
                },
                new MeterReading() {
                    Id = 2,
                    AccountId = 1,
                    MeterReadingDateTime = DateTime.Now,
                    MeterReadValue = 1234
                },
                new MeterReading() {
                    Id = 3,
                    AccountId = 2,
                    MeterReadingDateTime = DateTime.Now,
                    MeterReadValue = 4567
                }
            };

            var repoMock = new Mock<IMeterReadingRepository>();
            repoMock.Setup(r => r.GetAll()).ReturnsAsync(mockReadings);

            var service = new MeterReadingService(repoMock.Object);

            var readings = await service.GetAll();

            Assert.AreEqual(mockReadings.Count, readings.Count);
        }

        [Test]
        public async Task GetByAccountId_ReturnsMeterReadings()
        {
            var mockReadings = new List<MeterReading>()
            {
                new MeterReading() {
                    Id = 1,
                    AccountId = 1,
                    MeterReadingDateTime = DateTime.MinValue,
                    MeterReadValue = 1234
                },
                new MeterReading() {
                    Id = 2,
                    AccountId = 1,
                    MeterReadingDateTime = DateTime.Now,
                    MeterReadValue = 1234
                }
            };

            var repoMock = new Mock<IMeterReadingRepository>();
            repoMock.Setup(r => r.GetByAccountId(1)).ReturnsAsync(mockReadings);

            var service = new MeterReadingService(repoMock.Object);

            var readings = await service.GetByAccountId(1);

            Assert.AreEqual(mockReadings.Count, readings.Count);
        }
    }
}
