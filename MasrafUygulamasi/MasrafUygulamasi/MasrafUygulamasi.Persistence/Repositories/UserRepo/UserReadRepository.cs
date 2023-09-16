using System.Linq.Expressions;
using MasrafUygulamasi.Application.Interfaces.Repositories.UserRepo;
using MasrafUygulamasi.Domain.Identity;
using MasrafUygulamasi.Persistence.Context;
using Microsoft.AspNetCore.Identity;

namespace MasrafUygulamasi.Persistence.Repositories.UserRepo
{
	public class UserReadRepository : ReadRepository<AppIdentityUser>, IUserReadRepository
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        public UserReadRepository(MasrafUygulamasiDB context, UserManager<AppIdentityUser> userManager) : base(context)
        {
            _userManager = userManager;
        }
        public async Task<bool> UMCheckPasswordAsync(AppIdentityUser appIdentityUser, string password)
        {
            return await _userManager.CheckPasswordAsync(appIdentityUser, password);
        }

        public async Task<IdentityResult> UMConfirmEmailAsync(AppIdentityUser user, string token)
        {
            return await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task<AppIdentityUser> UMFindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public IQueryable<AppIdentityUser> UMGetAll()
        {
            return _userManager.Users;
        }

        public async Task<IList<AppIdentityUser>> UMGetAllByRoleAsync(string roleName)
        {
            return await _userManager.GetUsersInRoleAsync(roleName);
        }

        public async Task<IEnumerable<string>> UMGetAllRolesByUserAsync(AppIdentityUser appIdentityUser)
        {
            return await _userManager.GetRolesAsync(appIdentityUser);
        }
        public async Task<AppIdentityUser> UMGetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<AppIdentityUser> UMGetUserByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public IQueryable<AppIdentityUser> UMGetWhere(Expression<Func<AppIdentityUser, bool>> predicate)
        {
            return _userManager.Users.Where(predicate);
        }

        public async Task<IEnumerable<AppIdentityUser>> UMGetWhereByRoleAsync(Func<AppIdentityUser, bool> predicate, string roleName)
        {
            return (await _userManager.GetUsersInRoleAsync(roleName)).Where(predicate);
        }
    }
}
