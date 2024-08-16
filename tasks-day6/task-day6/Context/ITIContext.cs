using Microsoft.EntityFrameworkCore;
using task_day6.Models;
namespace task_day6.Context
{
    public class ITIContext:DbContext
    {
        public virtual DbSet<Drug> Drugs { get; set; }
        public virtual DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TestDbDay6;Integrated Security=True;Encrypt=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drug>(entity =>
            {
                entity.HasKey(d => d.Id);
                entity.Property(d => d.Name).IsRequired().HasMaxLength(100);
                entity.Property(d => d.ManufactureDate).IsRequired();
                entity.Property(d => d.ExpirationDate).IsRequired();
                entity.Property(d => d.ImagePath).HasMaxLength(255);
                entity.HasOne(d => d.Company).WithMany(c => c.Drugs).HasForeignKey(d => d.CompanyId).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
                //entity.HasMany(d => d.Drugs).WithOne(c => c.Company).HasForeignKey(d => d.CompanyId).OnDelete(DeleteBehavior.Cascade);
            });
        }

    }
}