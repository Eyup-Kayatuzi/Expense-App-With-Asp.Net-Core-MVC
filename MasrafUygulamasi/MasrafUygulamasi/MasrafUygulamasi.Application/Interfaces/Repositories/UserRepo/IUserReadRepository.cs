using System.Linq.Expressions;
using MasrafUygulamasi.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace MasrafUygulamasi.Application.Interfaces.Repositories.UserRepo
{
	public interface IUserReadRepository : IReadRepository<AppIdentityUser>
    {
        IQueryable<AppIdentityUser> UMGetAll();
        IQueryable<AppIdentityUser> UMGetWhere(Expression<Func<AppIdentityUser, bool>> predicate);
        Task<IList<AppIdentityUser>> UMGetAllByRoleAsync(string roleName);
        Task<IEnumerable<AppIdentityUser>> UMGetWhereByRoleAsync(Func<AppIdentityUser, bool> predicate, string roleName);
        Task<AppIdentityUser> UMGetUserByIdAsync(string userId);
        Task<AppIdentityUser> UMGetUserByNameAsync(string userName);
        Task<IEnumerable<string>> UMGetAllRolesByUserAsync(AppIdentityUser appIdentityUser);
        Task<bool> UMCheckPasswordAsync(AppIdentityUser appIdentityUser, string password);

        Task<AppIdentityUser> UMFindByEmailAsync(string email);
        Task<IdentityResult> UMConfirmEmailAsync(AppIdentityUser user, string token);
    }
}
