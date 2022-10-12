using EnsekTechnicalTest.Database.Context;
using EnsekTechnicalTest.Database.Repositories;
using EnsekTechnicalTest.Models;
using EnsekTechnicalTest.Models.Database;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Data.Common;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace EnsekTechnicalTest.Database.Test
{
    public class MeterReadingRepositoryTests
    {

        private DbConnection _connection;
        private DbContextOptions<EnsekContext> _contextOptions;


        [SetUp]
        public void Setup()
        {
            // Create and open a connection. This creates the SQLite in-memory database, which will persist until the connection is closed
            // at the end of the test (see Dispose below).
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            // These options will be used by the context instances in this test suite, including the connection opened above.
            _contextOptions = new DbContextOptionsBuilder<EnsekContext>()
                .UseSqlite(_connection)
                .Options;

            // Create the schema and seed some data
            using var context = new EnsekContext(_contextOptions);

            if (context.Database.EnsureCreated())
            {
                using var viewCommand = context.Database.GetDbConnection().CreateCommand();
                viewCommand.CommandText = @"
CREATE VIEW AllResources AS
SELECT FirstName
FROM Account;";
                viewCommand.ExecuteNonQuery();
            }

            context.AddRange(
                new Account { AccountId = 1, FirstName = "Test", LastName = "Test" },
                new Account { AccountId = 2, FirstName = "Test", LastName = "Test" },
                new Account { AccountId = 3, FirstName = "Test", LastName = "Test" },

                new MeterReading()
                {
                    Id = 1,
                    AccountId = 1,
                    MeterReadingDateTime = DateTime.MinValue,
                    MeterReadValue = "01234"
                },
                new MeterReading()
                {
                    Id = 2,
                    AccountId = 1,
                    MeterReadingDateTime = DateTime.Now,
                    MeterReadValue = "01234"
                },
                new MeterReading()
                {
                    Id = 3,
                    AccountId = 2,
                    MeterReadingDateTime = DateTime.Now,
                    MeterReadValue = "04567"
                }
            );
            context.SaveChanges();
        }

        [TearDown]
        public void TearDown() {
            _connection.Dispose();
        }

        [Test]
        public async Task GetAll_ReturnsAll()
        {
            var context = new EnsekContext(_contextOptions);
            var repo = new MeterReadingRepository(context);

            var result = await repo.GetAll();

            Assert.AreEqual(3, result.Count);
        }

        [Test]
        public async Task GetByAccountId_ReturnsCorrectCount()
        {
            var context = new EnsekContext(_contextOptions);
            var repo = new MeterReadingRepository(context);

            var result = await repo.GetByAccountId(1);

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result[0].AccountId);
            Assert.AreEqual(1, result[1].AccountId);
        }


        [Test]
        public async Task GetByAccountIds_ReturnsCorrectCount_ForOneId()
        {
            var context = new EnsekContext(_contextOptions);
            var repo = new MeterReadingRepository(context);

            var result = await repo.GetByAccountIds(new int[] {1});

            Assert.AreEqual(1, result.Count());

            Assert.IsTrue(result.ContainsKey(1));
            Assert.AreEqual(2, result[1].Count());
        }

        [Test]
        public async Task GetByAccountIds_ReturnsEmpty_ForEmptyArray()
        {
            var context = new EnsekContext(_contextOptions);
            var repo = new MeterReadingRepository(context);

            var result = await repo.GetByAccountIds(new int[] { });

            Assert.AreEqual(0, result.Count());
        }

        [Test]
        public async Task GetByAccountIds_ReturnsCorrectCount_ForTwoIds()
        {
            var context = new EnsekContext(_contextOptions);
            var repo = new MeterReadingRepository(context);

            var result = await repo.GetByAccountIds(new int[] { 1, 2 });

            Assert.AreEqual(2, result.Count());

            Assert.IsTrue(result.ContainsKey(1));
            Assert.AreEqual(2, result[1].Count());
            Assert.IsTrue(result.ContainsKey(2));
            Assert.AreEqual(1, result[2].Count());
        }
    }
}