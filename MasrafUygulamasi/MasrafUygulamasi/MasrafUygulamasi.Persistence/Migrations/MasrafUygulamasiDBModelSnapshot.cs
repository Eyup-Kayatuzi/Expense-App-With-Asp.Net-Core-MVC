﻿// <auto-generated />
using System;
using MasrafUygulamasi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MasrafUygulamasi.Persistence.Migrations
{
    [DbContext(typeof(MasrafUygulamasiDB))]
    partial class MasrafUygulamasiDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MasrafUygulamasi.Domain.Entities.CurrencyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CurrencyName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("CurrencyTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrencyName = "TL"
                        },
                        new
                        {
                            Id = 2,
                            CurrencyName = "USD"
                        },
                        new
                        {
                            Id = 3,
                            CurrencyName = "EUR"
                        });
                });

            modelBuilder.Entity("MasrafUygulamasi.Domain.Entities.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AppIdentityUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ApprovalStateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrencyTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ExpenseTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ManagerDescription")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AppIdentityUserId");

                    b.HasIndex("ApprovalStateId");

                    b.HasIndex("CurrencyTypeId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("MasrafUygulamasi.Domain.Entities.ExpenseItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExpenseDescription")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ExpenseId")
                        .HasColumnType("int");

                    b.Property<int>("ExpenseTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseId");

                    b.HasIndex("ExpenseTypeId");

                    b.ToTable("ExpenseItems");
                });

            modelBuilder.Entity("MasrafUygulamasi.Domain.Entities.ExpenseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ExpenseName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ExpenseTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExpenseName = "Meal"
                        },
                        new
                        {
                            Id = 2,
                            ExpenseName = "Accommodation"
                        },
                        new
                        {
                            Id = 3,
                            ExpenseName = "Transport"
                        },
                        new
                        {
                            Id = 4,
                            ExpenseName = "Gasoline"
                        },
                        new
                        {
                            Id = 5,
                            ExpenseName = "Other"
                        });
                });

            modelBuilder.Entity("MasrafUygulamasi.Domain.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApprovalStateName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApprovalStateName = "Waiting"
                        },
                        new
                        {
                            Id = 2,
                            ApprovalStateName = "Approved"
                        },
                        new
                        {
                            Id = 3,
                            ApprovalStateName = "Denied"
                        },
                        new
                        {
                            Id = 4,
                            ApprovalStateName = "Paid"
                        });
                });

            modelBuilder.Entity("MasrafUygulamasi.Domain.Identity.AppIdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupervisorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f9cde21c-1623-418e-b7dd-f5a6082ea27e",
                            Department = "Product Development",
                            Email = "eyup.kayatuzi@veripark.com",
                            EmailConfirmed = true,
                            FullName = "Eyup Kayatuzi",
                            LockoutEnabled = false,
                            NormalizedEmail = "EYUP.KAYATUZI@VERIPARK.COM",
                            NormalizedUserName = "EYPKYTZ",
                            PasswordHash = "AQAAAAEAACcQAAAAECqrdx+UcVXOzBJLxQCv1ciZNcp8Lt9sv+AuRL4+XVAMSwGcvOgEA0cy6jraziL5Bg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            SupervisorId = "3",
                            TwoFactorEnabled = false,
                            UserName = "eypkytz"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d5e3ae5f-8aad-45b0-9e4e-34c3cb000885",
                            Department = "IT",
                            Email = "ali.seven@veripark.com",
                            EmailConfirmed = true,
                            FullName = "Ali Seven",
                            LockoutEnabled = false,
                            NormalizedEmail = "ALI.SEVEN@VERIPARK.COM",
                            NormalizedUserName = "ALISEVEN",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ+//7Df3UVyrizHYC0iH+pk9ETRyasRUUL1wNyJFHvOZ7LsHRi4+QlEtfmKr7vDCQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            SupervisorId = "4",
                            TwoFactorEnabled = false,
                            UserName = "aliseven"
                        },
                        new
                        {
                            Id = "3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ad96bdde-370c-41e1-a81a-be08bcb0e034",
                            Department = "Product Development",
                            Email = "mustafa.yucel@veripark.com",
                            EmailConfirmed = true,
                            FullName = "Mustafa Yucel",
                            LockoutEnabled = false,
                            NormalizedEmail = "MUSTAFA.YUCEL@VERIPARK.COM",
                            NormalizedUserName = "MUSTAFAYUCEL",
                            PasswordHash = "AQAAAAEAACcQAAAAEL7YVTR2tCrUX9prr8Ot/cJXFkcbBGuBezP85/1WPg+MFc48QQL8sqmyuOdjNkE6lw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            SupervisorId = "",
                            TwoFactorEnabled = false,
                            UserName = "mustafayucel"
                        },
                        new
                        {
                            Id = "4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "851064eb-ef84-4590-b130-02a70af80244",
                            Department = "IT",
                            Email = "kenan.tas@veripark.com",
                            EmailConfirmed = true,
                            FullName = "Kenan Tas",
                            LockoutEnabled = false,
                            NormalizedEmail = "KENAN.TAS@VERIPARK.COM",
                            NormalizedUserName = "KENANTAS",
                            PasswordHash = "AQAAAAEAACcQAAAAECoiZlfNMQUVcps6RrxQeXKjncXZgqrT7/Sv+BqH5c4n3v97/NWpDnEf8Q+DWft5GQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            SupervisorId = "",
                            TwoFactorEnabled = false,
                            UserName = "kenantas"
                        },
                        new
                        {
                            Id = "5",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "81675ad2-de93-4269-9bb6-f17b3a08125c",
                            Department = "",
                            Email = "admin@veripark.com",
                            EmailConfirmed = true,
                            FullName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@VERIPARK.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEEigi+3bS5+rqr/eMU6xeG3JXj8SaUs27+1jFCi10ICw0vfDw0kgu0T5Ml/otW2LCA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            SupervisorId = "",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4bfc6bed-1420-4b28-b012-b24719700369",
                            Department = "",
                            Email = "ahmet.uzun@veripark.com",
                            EmailConfirmed = true,
                            FullName = "Ahmet Uzun",
                            LockoutEnabled = false,
                            NormalizedEmail = "ahmet.uzun@VERIPARK.COM",
                            NormalizedUserName = "AHMETUZUN",
                            PasswordHash = "AQAAAAEAACcQAAAAELhZtRQLiYclIrvM+gf7fu9UjkHc5xJzlHVB3L1Me8CTRVa1eFne5oTxJ3WSFKbqfw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            SupervisorId = "",
                            TwoFactorEnabled = false,
                            UserName = "ahmetuzun"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "1",
                            RoleId = "1"
                        },
                        new
                        {
                            UserId = "2",
                            RoleId = "1"
                        },
                        new
                        {
                            UserId = "3",
                            RoleId = "2"
                        },
                        new
                        {
                            UserId = "4",
                            RoleId = "2"
                        },
                        new
                        {
                            UserId = "5",
                            RoleId = "4"
                        },
                        new
                        {
                            UserId = "6",
                            RoleId = "3"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MasrafUygulamasi.Domain.Identity.AppIdentityRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("AppIdentityRole");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            ConcurrencyStamp = "d64283d2-edf1-42ee-885d-2c54d49235eb",
                            Name = "personel",
                            NormalizedName = "PERSONEL",
                            Description = "Bu sirket personelidir"
                        },
                        new
                        {
                            Id = "2",
                            ConcurrencyStamp = "71d73d1c-8ded-482d-b3ca-2ac193ebc164",
                            Name = "yonetici",
                            NormalizedName = "YONETICI",
                            Description = "Bu sirket yoneticisidir"
                        },
                        new
                        {
                            Id = "3",
                            ConcurrencyStamp = "b9cb6d82-7efc-4376-92ae-3af7b4967282",
                            Name = "muhasebeci",
                            NormalizedName = "MUHASEBECI",
                            Description = "Bu sirket muhasebecisidir"
                        },
                        new
                        {
                            Id = "4",
                            ConcurrencyStamp = "c0b3b378-16fa-4975-8813-35bc89c1d44b",
                            Name = "admin",
                            NormalizedName = "ADMIN",
                            Description = "Admin"
                        });
                });

            modelBuilder.Entity("MasrafUygulamasi.Domain.Entities.Expense", b =>
                {
                    b.HasOne("MasrafUygulamasi.Domain.Identity.AppIdentityUser", "AppIdentityUser")
                        .WithMany("Expenses")
                        .HasForeignKey("AppIdentityUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasrafUygulamasi.Domain.Entities.State", "ApprovalState")
                        .WithMany("Expenses")
                        .HasForeignKey("ApprovalStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasrafUygulamasi.Domain.Entities.CurrencyType", "CurrencyType")
                        .WithMany("Expenses")
                        .HasForeignKey("CurrencyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppIdentityUser");

                    b.Navigation("ApprovalState");

                    b.Navigation("CurrencyType");
                });

            modelBuilder.Entity("MasrafUygulamasi.Domain.Entities.ExpenseItem", b =>
                {
                    b.HasOne("MasrafUygulamasi.Domain.Entities.Expense", "Expense")
                        .WithMany("ExpenseItems")
                        .HasForeignKey("ExpenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasrafUygulamasi.Domain.Entities.ExpenseType", "ExpenseType")
                        .WithMany("ExpenseItems")
                        .HasForeignKey("ExpenseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expense");

                    b.Navigation("ExpenseType");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MasrafUygulamasi.Domain.Identity.AppIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MasrafUygulamasi.Domain.Identity.AppIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasrafUygulamasi.Domain.Identity.AppIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MasrafUygulamasi.Domain.Identity.AppIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MasrafUygulamasi.Domain.Entities.CurrencyType", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("MasrafUygulamasi.Domain.Entities.Expense", b =>
                {
                    b.Navigation("ExpenseItems");
                });

            modelBuilder.Entity("MasrafUygulamasi.Domain.Entities.ExpenseType", b =>
                {
                    b.Navigation("ExpenseItems");
                });

            modelBuilder.Entity("MasrafUygulamasi.Domain.Entities.State", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("MasrafUygulamasi.Domain.Identity.AppIdentityUser", b =>
                {
                    b.Navigation("Expenses");
                });
#pragma warning restore 612, 618
        }
    }
}
