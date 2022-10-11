using EnsekTechnicalTest.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace EnsekTechnicalTest.Database.Context
{
    public class EnsekContext : DbContext
    {
        public EnsekContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<MeterReading> MeterReadings { get; set; }
    }
}
