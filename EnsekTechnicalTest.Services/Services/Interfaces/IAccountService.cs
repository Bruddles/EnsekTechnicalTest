using EnsekTechnicalTest.Services.Models;
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
        public Account GetAccount(string accountId);
        public IEnumerable<Account> GetAccounts();
    }
}
