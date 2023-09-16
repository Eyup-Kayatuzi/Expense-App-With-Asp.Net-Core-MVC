using MasrafUygulamasi.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MasrafUygulamasi.Persistence.Context.DummyValue
{
	public class DummyUser
    {
        public static void AddDummyUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppIdentityUser>().HasData(
                new AppIdentityUser
                {
                    Id = "1",
                    UserName = "eypkytz",
                    NormalizedUserName = "EYPKYTZ",
                    Email = "eyup.kayatuzi@veripark.com",
                    NormalizedEmail = "EYUP.KAYATUZI@VERIPARK.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<AppIdentityUser>().HashPassword(null, "1234"),
                    SecurityStamp = string.Empty,
                    FullName = "Eyup Kayatuzi",
                    Department = "Product Development",
                    SupervisorId = "3",
                },
                new AppIdentityUser
                {
                    Id = "2",
                    UserName = "aliseven",
                    NormalizedUserName = "ALISEVEN",
                    Email = "ali.seven@veripark.com",
                    NormalizedEmail = "ALI.SEVEN@VERIPARK.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<AppIdentityUser>().HashPassword(null, "1234"),
                    SecurityStamp = string.Empty,
                    FullName = "Ali Seven",
                    Department = "IT",
                    SupervisorId = "4",
                },
                new AppIdentityUser
                {
                    Id = "3",
                    UserName = "mustafayucel",
                    NormalizedUserName = "MUSTAFAYUCEL",
                    Email = "mustafa.yucel@veripark.com",
                    NormalizedEmail = "MUSTAFA.YUCEL@VERIPARK.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<AppIdentityUser>().HashPassword(null, "1234"),
                    SecurityStamp = string.Empty,
                    FullName = "Mustafa Yucel",
                    Department = "Product Development",
                },
                new AppIdentityUser
                {
                    Id = "4",
                    UserName = "kenantas",
                    NormalizedUserName = "KENANTAS",
                    Email = "kenan.tas@veripark.com",
                    NormalizedEmail = "KENAN.TAS@VERIPARK.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<AppIdentityUser>().HashPassword(null, "1234"),
                    SecurityStamp = string.Empty,
                    FullName = "Kenan Tas",
                    Department = "IT",
                },
                new AppIdentityUser
                {
                    Id = "5",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@veripark.com",
                    NormalizedEmail = "ADMIN@VERIPARK.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<AppIdentityUser>().HashPassword(null, "1234"),
                    SecurityStamp = string.Empty,
                    FullName = "Admin",
                },
                new AppIdentityUser
                {
                    Id = "6",
                    UserName = "ahmetuzun",
                    NormalizedUserName = "AHMETUZUN",
                    Email = "ahmet.uzun@veripark.com",
                    NormalizedEmail = "ahmet.uzun@VERIPARK.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<AppIdentityUser>().HashPassword(null, "1234"),
                    SecurityStamp = string.Empty,
                    FullName = "Ahmet Uzun",
                }
             );
        }
    }
}
