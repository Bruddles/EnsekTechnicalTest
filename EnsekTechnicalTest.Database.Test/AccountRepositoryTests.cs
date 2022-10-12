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
    public class AccountRepositoryTests
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
                new Account { AccountId = 3, FirstName = "Test", LastName = "Test" }
            );
            context.SaveChanges();
        }

        [TearDown]
        public void TearDown() {
            _connection.Dispose();
        }

        [Test]
        public async Task Get_ReturnsAccount()
        {
            var context = new EnsekContext(_contextOptions);
            var repo = new AccountRepository(context);

            var account = await repo.Get(1);

            Assert.AreEqual(1, account.AccountId);
            Assert.AreEqual("Test", account.FirstName);
            Assert.AreEqual("Test", account.LastName);
        }

        [Test]
        public async Task GetAll_ReturnsAccounts()
        {
            var context = new EnsekContext(_contextOptions);
            var repo = new AccountRepository(context);

            var accounts = await repo.GetAll();

            // Seed data is run in to db, so count is 27 + the 3 set up here
            Assert.AreEqual(30, accounts.Count);
        }


        [Test]
        public async Task GetForIds_ReturnsAccounts()
        {
            var context = new EnsekContext(_contextOptions);
            var repo = new AccountRepository(context);

            var accounts = await repo.GetForIds(new int[] {1,2});

            // Seed data is run in to db, so count is 27 + the 3 set up here
            Assert.AreEqual(2, accounts.Count);
        }

    }
}