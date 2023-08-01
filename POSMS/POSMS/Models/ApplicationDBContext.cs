using Microsoft.EntityFrameworkCore;

namespace POSMS.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {

        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Device> Devices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureRelations(modelBuilder);
        }
        private void ConfigureRelations(ModelBuilder builder)
        {
            builder.Entity<Device>().HasKey(d => d.Id);
            builder.Entity<Device>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Device>().Property(d => d.Manufacturer).IsRequired();
            builder.Entity<Device>().Property(d => d.Model).IsRequired();
            builder.Entity<Device>().HasIndex(d => d.SerialNumber).IsUnique();
            builder.Entity<Device>().Property(d => d.SerialNumber).IsRequired();
            builder.Entity<Device>().HasIndex(d => d.IMEI).IsUnique();
            builder.Entity<Device>().Property(d => d.IMEI).IsRequired();
            builder.Entity<Device>().Property(d => d.CreatedAt).HasDefaultValue(DateTime.Now);
        }
    }
}
