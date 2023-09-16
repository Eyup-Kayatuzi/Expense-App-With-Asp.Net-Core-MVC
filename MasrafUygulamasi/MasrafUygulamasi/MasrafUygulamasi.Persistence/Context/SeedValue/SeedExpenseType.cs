using MasrafUygulamasi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasrafUygulamasi.Persistence.Context.SeedValue
{
	public class SeedExpenseType
    {
        public static void AddExpenseType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpenseType>().HasData(
                new ExpenseType
                {
                    Id = 1,
                    ExpenseName = "Meal",
                },
                new ExpenseType
                {
                    Id = 2,
                    ExpenseName = "Accommodation",
                },
                new ExpenseType
                {
                    Id = 3,
                    ExpenseName = "Transport",
                },
                new ExpenseType
                {
                    Id = 4,
                    ExpenseName = "Gasoline",
                },
                new ExpenseType
                {
                    Id = 5,
                    ExpenseName = "Other",
                }
                );
        }
    }
}
