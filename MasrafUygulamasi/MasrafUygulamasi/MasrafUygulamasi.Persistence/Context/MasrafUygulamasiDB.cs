using MasrafUygulamasi.Domain.Entities;
using MasrafUygulamasi.Domain.Identity;
using MasrafUygulamasi.Persistence.Context.DummyValue;
using MasrafUygulamasi.Persistence.Context.SeedValue;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MasrafUygulamasi.Persistence.Context
{
	public class MasrafUygulamasiDB : IdentityDbContext<AppIdentityUser>
    {
        public MasrafUygulamasiDB(DbContextOptions<MasrafUygulamasiDB> options) : base(options)
        {

        }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<State> States { get; set;}
        public DbSet<CurrencyType> CurrencyTypes { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<ExpenseItem> ExpenseItems { get;set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            DummyRoles.AddDummyRoles(builder);
            DummyUser.AddDummyUser(builder);
            DummyUserRoles.AddUserRole(builder);
            SeedState.AddApprovalState(builder);
            SeedCurrencyType.AddCurrencyType(builder);
            SeedExpenseType.AddExpenseType(builder);
            base.OnModelCreating(builder);
        }

    }
}
