using Microsoft.EntityFrameworkCore;
using Server_API.Models.Entity;

namespace Server_API.Context
{
    public class PSICRODbContext:DbContext
    {
        public PSICRODbContext(DbContextOptions<PSICRODbContext>options):base(options)
        {
            
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<CompanyService> CompanyServices { get; set; }
        public DbSet<PaymentBill> PaymentBills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentBill>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PaymentBill>()
                .Property(p => p.PaymentStatus)
                .HasConversion<string>();
        }
    }
}
