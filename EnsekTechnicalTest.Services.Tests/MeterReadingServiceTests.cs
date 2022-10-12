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

            var mrRepoMock = new Mock<IMeterReadingRepository>();
            mrRepoMock.Setup(r => r.GetAll()).ReturnsAsync(mockReadings);
            var parserMock = new Mock<ICsvParser<MeterReading>>();
            var aRepoMock = new Mock<IAccountRepository>();

            var service = new MeterReadingService(mrRepoMock.Object,aRepoMock.Object, parserMock.Object);

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

            var mrRepoMock = new Mock<IMeterReadingRepository>();
            mrRepoMock.Setup(r => r.GetByAccountId(1)).ReturnsAsync(mockReadings);
            var parserMock = new Mock<ICsvParser<MeterReading>>();
            var aRepoMock = new Mock<IAccountRepository>();

            var service = new MeterReadingService(mrRepoMock.Object, aRepoMock.Object, parserMock.Object);

            var readings = await service.GetByAccountId(1);

            Assert.AreEqual(mockReadings.Count, readings.Count);
        }


        [Test]
        public async Task Validate_ReturnsValidMeterReading_WhenNoExistingReadings()
        {
            var mockAccount = new Account
            {
                AccountId = 1,
                FirstName = "Test",
                LastName = "Test"
            };

            var mockReadings = new List<MeterReading>(){};

            var mockReadingsDict = new Dictionary<int, List<MeterReading>>{};

            var mrRepoMock = new Mock<IMeterReadingRepository>();
            mrRepoMock.Setup(r => r.GetByAccountIds(new int[] { 1 })).ReturnsAsync(mockReadingsDict); 
            var parserMock = new Mock<ICsvParser<MeterReading>>();
            var aRepoMock = new Mock<IAccountRepository>();
            aRepoMock.Setup(r => r.GetForIds(new int[] { 1 })).ReturnsAsync(new List<Account> { mockAccount });

            var service = new MeterReadingService(mrRepoMock.Object, aRepoMock.Object, parserMock.Object);

            var newReadings = new List<MeterReading>()
            {
                new MeterReading() {
                    AccountId = 1,
                    MeterReadingDateTime = DateTime.Now,
                    MeterReadValue = 888
                }
            };

            var readings = await service.Validate(newReadings);

            Assert.AreEqual(newReadings.Count, readings.Count);
        }

        [Test]
        public async Task Validate_ReturnsValidMeterReading_WhenExistingReadings()
        {
            var mockAccount = new Account
            {
                AccountId = 1,
                FirstName = "Test",
                LastName = "Test"
            };

            var mockReadings = new List<MeterReading>()
            {
                new MeterReading() {
                    Id = 1,
                    AccountId = 1,
                    MeterReadingDateTime = DateTime.MinValue,
                    MeterReadValue = 1234
                }
            };

            var mockReadingsDict = new Dictionary<int, List<MeterReading>>
            {
                {1, mockReadings },
            };

            var mrRepoMock = new Mock<IMeterReadingRepository>();
            mrRepoMock.Setup(r => r.GetByAccountIds(new int[] { 1 })).ReturnsAsync(mockReadingsDict);
            var parserMock = new Mock<ICsvParser<MeterReading>>();
            var aRepoMock = new Mock<IAccountRepository>();
            aRepoMock.Setup(r => r.GetForIds(new int[] { 1 })).ReturnsAsync(new List<Account> { mockAccount });

            var service = new MeterReadingService(mrRepoMock.Object, aRepoMock.Object, parserMock.Object);

            var newReadings = new List<MeterReading>()
            {
                new MeterReading() {
                    AccountId = 1,
                    MeterReadingDateTime = DateTime.Now,
                    MeterReadValue = 888
                }
            };

            var readings = await service.Validate(newReadings);

            Assert.AreEqual(newReadings.Count, readings.Count);
        }

        [Test]
        public async Task Validate_ReturnsNoMeterReading_WhenNoMatchingAccount()
        {
            var mockAccount = new Account
            {
                AccountId = 1,
                FirstName = "Test",
                LastName = "Test"
            };

            var mockReadings = new List<MeterReading>()
            {
                new MeterReading() {
                    Id = 1,
                    AccountId = 1,
                    MeterReadingDateTime = DateTime.MinValue,
                    MeterReadValue = 1234
                }
            };

            var mockReadingsDict = new Dictionary<int, List<MeterReading>>
            {
                {1, mockReadings },
            };

            var mrRepoMock = new Mock<IMeterReadingRepository>();
            mrRepoMock.Setup(r => r.GetByAccountIds(new int[] { 1 })).ReturnsAsync(mockReadingsDict);
            var parserMock = new Mock<ICsvParser<MeterReading>>();
            var aRepoMock = new Mock<IAccountRepository>();
            aRepoMock.Setup(r => r.GetForIds(new int[] { 1, 2 })).ReturnsAsync(new List<Account> { mockAccount });

            var service = new MeterReadingService(mrRepoMock.Object, aRepoMock.Object, parserMock.Object);

            var newReadings = new List<MeterReading>()
            {
                new MeterReading() {
                    AccountId = 2,
                    MeterReadingDateTime = DateTime.Now,
                    MeterReadValue = 888
                }
            };

            var readings = await service.Validate(newReadings);

            Assert.AreEqual(0, readings.Count);
        }

        [Test]
        public async Task Validate_ReturnsNoMeterReading_WhenAddingDuplicateReading()
        {
            var mockAccount = new Account
            {
                AccountId = 1,
                FirstName = "Test",
                LastName = "Test"
            };

            var mockReadings = new List<MeterReading>()
            {
                new MeterReading() {
                    Id = 1,
                    AccountId = 1,
                    MeterReadingDateTime = DateTime.MinValue,
                    MeterReadValue = 1234
                }
            };

            var mockReadingsDict = new Dictionary<int, List<MeterReading>>
            {
                {1, mockReadings },
            };

            var mrRepoMock = new Mock<IMeterReadingRepository>();
            mrRepoMock.Setup(r => r.GetByAccountIds(new int[] { 1 })).ReturnsAsync(mockReadingsDict);
            var parserMock = new Mock<ICsvParser<MeterReading>>();
            var aRepoMock = new Mock<IAccountRepository>();
            aRepoMock.Setup(r => r.GetForIds(new int[] { 1, 2 })).ReturnsAsync(new List<Account> { mockAccount });

            var service = new MeterReadingService(mrRepoMock.Object, aRepoMock.Object, parserMock.Object);

            var newReadings = new List<MeterReading>()
            {
                new MeterReading() {
                    AccountId = 1,
                    MeterReadingDateTime = DateTime.MinValue,
                    MeterReadValue = 1234
                }
            };

            var readings = await service.Validate(newReadings);

            Assert.AreEqual(0, readings.Count);
        }

        [Test]
        public async Task Validate_ReturnsNoMeterReading_WhenAddingEarlierReading()
        {
            var mockAccount = new Account
            {
                AccountId = 1,
                FirstName = "Test",
                LastName = "Test"
            };

            var mockReadings = new List<MeterReading>()
            {
                new MeterReading() {
                    Id = 1,
                    AccountId = 1,
                    MeterReadingDateTime = DateTime.MaxValue,
                    MeterReadValue = 1234
                }
            };

            var mockReadingsDict = new Dictionary<int, List<MeterReading>>
            {
                {1, mockReadings },
            };

            var mrRepoMock = new Mock<IMeterReadingRepository>();
            mrRepoMock.Setup(r => r.GetByAccountIds(new int[] { 1 })).ReturnsAsync(mockReadingsDict);
            var parserMock = new Mock<ICsvParser<MeterReading>>();
            var aRepoMock = new Mock<IAccountRepository>();
            aRepoMock.Setup(r => r.GetForIds(new int[] { 1, 2 })).ReturnsAsync(new List<Account> { mockAccount });

            var service = new MeterReadingService(mrRepoMock.Object, aRepoMock.Object, parserMock.Object);

            var newReadings = new List<MeterReading>()
            {
                new MeterReading() {
                    AccountId = 1,
                    MeterReadingDateTime = DateTime.MinValue,
                    MeterReadValue = 1234
                }
            };

            var readings = await service.Validate(newReadings);

            Assert.AreEqual(0, readings.Count);
        }
    }
}
