using EnsekTechnicalTest.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekTechnicalTest.Database.Interfaces
{
    public interface IAccountRepository
    {
        public Task<Account> Get(int id);
        public Task<List<Account>> GetForIds(int[] ids);
        public Task<List<Account>> GetAll();
    }
}
