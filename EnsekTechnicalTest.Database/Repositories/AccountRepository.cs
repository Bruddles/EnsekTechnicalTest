using EnsekTechnicalTest.Database.Context;
using EnsekTechnicalTest.Database.Interfaces;
using EnsekTechnicalTest.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekTechnicalTest.Database.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly EnsekContext _context;

        public AccountRepository(EnsekContext context)
        {
            this._context = context;
        }

        public Task<Account> Get(int id) => _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == id);

        public Task<List<Account>> GetAll() => _context.Accounts.ToListAsync();
        public Task<List<Account>> GetForIds(int[] ids) => _context.Accounts.Where(a => ids.Contains(a.AccountId)).ToListAsync();
    }
}
