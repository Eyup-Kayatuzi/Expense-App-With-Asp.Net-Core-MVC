using MasrafUygulamasi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasrafUygulamasi.Persistence.Context.SeedValue
{
	public class SeedCurrencyType
    {
        public static void AddCurrencyType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyType>().HasData(
               new CurrencyType
               {
                   Id = 1,
                   CurrencyName = "TL",
               },
               new CurrencyType
               {
                   Id = 2,
                   CurrencyName = "USD",
               },
               new CurrencyType
               {
                   Id = 3,
                   CurrencyName = "EUR",
               }
               );
        }
    }
}
