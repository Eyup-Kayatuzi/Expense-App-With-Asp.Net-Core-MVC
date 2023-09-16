using MasrafUygulamasi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasrafUygulamasi.Persistence.Context.SeedValue
{
	public class SeedState
    {
        public static void AddApprovalState(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>().HasData(

                new State
                {
                    Id = 1,
                    ApprovalStateName = "Waiting",
                }, 
                new State
                {
                    Id = 2,
                    ApprovalStateName = "Approved",
                },
                new State
                {
                    Id = 3,
                    ApprovalStateName = "Denied",
                },
                new State
                {
                    Id = 4,
                    ApprovalStateName = "Paid",
                }
                );
        }
    }
}
