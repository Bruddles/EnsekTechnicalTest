using EnsekTechnicalTest.Database.Context;
using EnsekTechnicalTest.Database.Repositories;
using EnsekTechnicalTest.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace EnsekTechnicalTest.Database.Test
{
    public class AccountRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        //[Test]
        // Get error: System.NotSupportedException : Unsupported expression: m => m.Accounts
        //Non-overridable members(here: EnsekContext.get_Accounts) may not be used in setup / verification expressions.

        // followed guide here:https://learn.microsoft.com/en-us/ef/ef6/fundamentals/testing/mocking?redirectedfrom=MSDN
        // but it wouldnt accept the mock
        public async Task Get_ReturnsAccount()
        {
            var data = new List<Account>
            {
                new Account { AccountId = 1, FirstName = "Test", LastName = "Test"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Account>>();
            mockSet.As<IQueryable<Account>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Account>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Account>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Account>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<EnsekContext>();
            mockContext.Setup(m => m.Accounts).Returns(mockSet.Object);

            var repo = new AccountRepository(mockContext.Object);

            var account = await repo.Get(1);

            Assert.AreEqual(1, account.AccountId);
            Assert.AreEqual("Test", account.FirstName);
            Assert.AreEqual("Test", account.LastName);
        }

        [Test]
        public async Task GetAll_ReturnsAccounts()
        {
            var data = new List<Account>
            {
                new Account { AccountId = 1, FirstName = "Test", LastName = "Test"},
                new Account { AccountId = 2, FirstName = "Test", LastName = "Test"},
                new Account { AccountId = 3, FirstName = "Test", LastName = "Test"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Account>>();
            mockSet.As<IQueryable<Account>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Account>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Account>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Account>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<EnsekContext>();
            mockContext.Setup(m => m.Accounts).Returns(mockSet.Object);

            var repo = new AccountRepository(mockContext.Object);

            var accounts = await repo.GetAll();

            Assert.AreEqual(3, accounts.Count);
        }
    }
}