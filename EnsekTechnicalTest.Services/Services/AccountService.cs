using EnsekTechnicalTest.Database.Interfaces;
using EnsekTechnicalTest.Models;
using EnsekTechnicalTest.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekTechnicalTest.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }

        public Task<Account> GetAccount(int accountId)
        {
            return _accountRepository.Get(accountId);
        }

        public Task<List<Account>> GetAccounts()
        {
            return _accountRepository.GetAll();
        }
    }
}
