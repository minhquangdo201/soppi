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
            SeedUsers(builder);
            SeedUserRoles(builder);
            builder.ApplyConfiguration(new AppEntityConfiguration());
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = "1",
                    Name = "Admin",
                    ConcurrencyStamp = "1",
                    NormalizedName = "Admin"
                },
                new IdentityRole()
                {
                    Id = "2",
                    Name = "User",
                    ConcurrencyStamp = "2",
                    NormalizedName = "User"
                },
                new IdentityRole()
                {
                    Id = "3",
                    Name = "Shop",
                    ConcurrencyStamp = "3",
                    NormalizedName = "Shop"
                }
            );
        }

        private void SeedUsers(ModelBuilder builder)
        {
            ApplicationUser admin = new ApplicationUser
            {
                Id = "1",
                Name = "Admin",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMINH@GMAIL.COM",
                PhoneNumber = "0123456789",
                Address = "Hanoi"
            };
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "admin1234");
            builder.Entity<ApplicationUser>().HasData(admin);
            ApplicationUser user = new ApplicationUser
            {
                Id = "2",
                Name = "User",
                UserName = "user",
                NormalizedUserName = "USER",
                Email = "user@gmail.com",
                NormalizedEmail = "USER@GMAIL.COM",
                PhoneNumber = "0123456789",
                Address = "Hanoi"
            };
            user.PasswordHash = passwordHasher.HashPassword(user, "user1234");
            builder.Entity<ApplicationUser>().HasData(user);

            ApplicationUser user1 = new ApplicationUser
            {
                Id = "4",
                Name = "User1",
                UserName = "user1",
                NormalizedUserName = "USER1",
                Email = "user1@gmail.com",
                NormalizedEmail = "USER1@GMAIL.COM",
                PhoneNumber = "0123456789",
                Address = "Hanoi"
            };
            user1.PasswordHash = passwordHasher.HashPassword(user1, "user1234");
            builder.Entity<ApplicationUser>().HasData(user1);

            ApplicationUser shop = new ApplicationUser
            {
                Id = "3",
                Name = "Shop",
                UserName = "shop",
                NormalizedUserName = "SHOP",
                Email = "shop@gmail.com",
                NormalizedEmail = "SHOP@GMAIL.COM",
                PhoneNumber = "0123456789",
                Address = "Hanoi"
            };
            shop.PasswordHash = passwordHasher.HashPassword(shop, "shop1234");
            builder.Entity<ApplicationUser>().HasData(shop);

            ApplicationUser shop1 = new ApplicationUser
            {
                Id = "5",
                Name = "Shop1",
                UserName = "shop1",
                NormalizedUserName = "SHOP1",
                Email = "shop1@gmail.com",
                NormalizedEmail = "SHOP1@GMAIL.COM",
                PhoneNumber = "0123456789",
                Address = "Hanoi"
            };
            shop1.PasswordHash = passwordHasher.HashPassword(shop1, "shop1234");
            builder.Entity<ApplicationUser>().HasData(shop1);

        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "1",
                    UserId = "1"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2",
                    UserId = "2"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "3",
                    UserId = "3"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2",
                    UserId = "4"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "3",
                    UserId = "5"
                }
            );
        }




        public DbSet<Review> Reviews { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
