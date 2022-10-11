using EnsekTechnicalTest.Database.Interfaces;
using EnsekTechnicalTest.Models;
using EnsekTechnicalTest.Services.Services;
using Moq;

namespace EnsekTechnicalTest.Services.Tests
{
    public class AccountServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Get_ReturnsAccount()
        {
            var mockAccount = new Account {
                AccountId = 1,
                FirstName = "Test",
                LastName= "Test"
            };

            var repoMock = new Mock<IAccountRepository>();
            repoMock.Setup(r => r.Get(mockAccount.AccountId)).ReturnsAsync(mockAccount);

            var service = new AccountService(repoMock.Object);

            var account = await service.GetAccount(mockAccount.AccountId);

            Assert.IsNotNull(account);
            Assert.AreEqual(mockAccount.AccountId, account.AccountId);
        }

        [Test]
        public async Task GetAll_ReturnsAccounts()
        {
            var mockAccounts = new List<Account>() {
                new Account {
                    AccountId = 1,
                    FirstName = "Test",
                    LastName = "Test"
                }, new Account
                {
                    AccountId = 2,
                    FirstName = "Test",
                    LastName = "Test"
                }, new Account
                {
                    AccountId = 3,
                    FirstName = "Test",
                    LastName = "Test"
                }
            };

            var repoMock = new Mock<IAccountRepository>();
            repoMock.Setup(r => r.GetAll()).ReturnsAsync(mockAccounts);

            var service = new AccountService(repoMock.Object);

            var accounts = await service.GetAccounts();

            Assert.AreEqual(mockAccounts.Count, accounts.Count);
        }
    }
}