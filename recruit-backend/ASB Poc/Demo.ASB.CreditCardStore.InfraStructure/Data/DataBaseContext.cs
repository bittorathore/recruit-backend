
using Demo.ASB.CreditCardStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.ASB.CreditCardStore.InfraStructure.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<CardHolder> CardHolders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardHolder>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CardHolderName)
                .HasMaxLength(50);
            });

            modelBuilder.Entity<CreditCard>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CreditCardNumber);
                entity.Property(e => e.CVC).HasMaxLength(10);
                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            });
        }
    }
}
