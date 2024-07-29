using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillLibrary.Modal
{
    public class BillDBContext : DbContext
    {
        public BillDBContext()
        {
            
        }
        public BillDBContext(DbContextOptions<BillDBContext> options) : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; } //Table names
        public virtual DbSet<Items> Items{ get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        //Assign the location where the DB should be created.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB; database=BillDB; integrated security=true");
        }
    }
}
