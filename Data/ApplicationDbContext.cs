using Microsoft.EntityFrameworkCore;
using soppi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace soppi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public class AppEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
        {
            public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ApplicationUser> builder)
            {
                builder.Property(p => p.Name).HasMaxLength(100);
                builder.Property(p => p.Address).HasMaxLength(100);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.Entity<Product>()
            //     .HasOne(p => p.User)
            //     .WithMany(u => u.Products)
            //     .HasForeignKey(p => p.UserId)
            //     .IsRequired();

            base.OnModelCreating(builder);
            SeedRoles(builder);
            builder.ApplyConfiguration(new AppEntityConfiguration());
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Name = "Admin",
                    ConcurrencyStamp = "1",
                    NormalizedName = "Admin"
                },
                new IdentityRole()
                {
                    Name = "User",
                    ConcurrencyStamp = "2",
                    NormalizedName = "User"
                },
                new IdentityRole()
                {
                    Name = "Shop",
                    ConcurrencyStamp = "3",
                    NormalizedName = "Shop"
                }
            );
        }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
