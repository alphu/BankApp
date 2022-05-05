using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Infra.Data
{
    public class BankDBContext : DbContext
    {
        public BankDBContext(DbContextOptions<BankDBContext> opt_Db) : base(opt_Db)
        {
        }
        //public DbSet<Customer> Customer { get; set; }
        //public DbSet<Loan> Loan { get; set; }
    }
}
