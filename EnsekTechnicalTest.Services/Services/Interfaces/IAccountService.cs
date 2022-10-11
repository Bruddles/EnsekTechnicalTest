using EnsekTechnicalTest.Models.Database;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekTechnicalTest.Services.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<Account> GetAccount(int accountId);
        public Task<List<Account>> GetAccounts();
    }
}
