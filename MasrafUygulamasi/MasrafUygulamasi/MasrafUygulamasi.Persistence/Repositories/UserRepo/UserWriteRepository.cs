using MasrafUygulamasi.Application.Interfaces.Repositories.UserRepo;
using MasrafUygulamasi.Domain.Identity;
using MasrafUygulamasi.Persistence.Context;
using Microsoft.AspNetCore.Identity;

namespace MasrafUygulamasi.Persistence.Repositories.UserRepo
{
	public class UserWriteRepository : WriteRepository<AppIdentityUser>, IUserWriteRepository
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly SignInManager<AppIdentityUser> _signInManager;
        public UserWriteRepository(MasrafUygulamasiDB context, UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager) : base(context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task SMLogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<SignInResult> SMPasswordSignInAsync(AppIdentityUser appIdentityUser, string password)
        {
            return await _signInManager.PasswordSignInAsync(appIdentityUser, password, false, true);
        }

        public async Task<IdentityResult> UpdateAsync(AppIdentityUser loginedUser)
        {
            return await _userManager.UpdateAsync(loginedUser);
        }
        public async Task<IdentityResult> CreateAsync(AppIdentityUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }
        public async Task<IdentityResult> AddToRoleAsync(AppIdentityUser user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
        }
    }
}
