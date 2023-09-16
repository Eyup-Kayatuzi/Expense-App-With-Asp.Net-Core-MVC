using System.Linq.Expressions;
using MasrafUygulamasi.Application.Interfaces;
using MasrafUygulamasi.Application.Interfaces.IServices;
using MasrafUygulamasi.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MasrafUygulamasi.Persistence.Concretes
{
	public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> SaveDataBaseAsync()
        {
            return await _unitOfWork.UserWrite.SaveAsync() > 0; 
        }

        public async Task SMLogOffAsync()
        {
            await _unitOfWork.UserWrite.SMLogoutAsync();
        }

        public async Task<SignInResult> SMSignInWithPasswordAsync(AppIdentityUser appIdentityUser, string password)
        {
            return await _unitOfWork.UserWrite.SMPasswordSignInAsync(appIdentityUser, password);
        }

        public async Task<IdentityResult> UMAddToRoleAsync(AppIdentityUser user, string role)
        {
            return await _unitOfWork.UserWrite.AddToRoleAsync(user, role);
        }

        public async Task<bool> UMCheckUserWithPasswordAsync(AppIdentityUser appIdentityUser, string password)
        {
            return await _unitOfWork.UserRead.UMCheckPasswordAsync(appIdentityUser, password);
        }

        public async Task<IdentityResult> UMConfirmEmailAsync(AppIdentityUser user, string token)
        {
            return await _unitOfWork.UserRead.UMConfirmEmailAsync(user, token);
        }

        public async Task<IdentityResult> UMCreateAsync(AppIdentityUser user, string password)
        {
            return await _unitOfWork.UserWrite.CreateAsync(user, password);
        }

        public async Task<AppIdentityUser> UMFindUserByEmailAsync(string email)
        {
            return await _unitOfWork.UserRead.UMFindByEmailAsync(email);
        }

        public async Task<List<string>> UMGetAllRolesByUserAsync(AppIdentityUser appIdentityUser)
        {
            return (await _unitOfWork.UserRead.UMGetAllRolesByUserAsync(appIdentityUser)).ToList();
        }

        public List<AppIdentityUser> UMGetAllUsers()
        {
            return _unitOfWork.UserRead.UMGetAll().ToList();
        }

        public async Task<List<AppIdentityUser>> UMGetAllUsersAsync()
        {
            return await _unitOfWork.UserRead.UMGetAll().ToListAsync();
        }

        public async Task<List<AppIdentityUser>> UMGetAllUsersByRoleAsync(string roleName)
        {
            return (await _unitOfWork.UserRead.UMGetAllByRoleAsync(roleName)).ToList();
        }

        public async Task<AppIdentityUser> UMGetUserByIdAsync(string id)
        {
            return await _unitOfWork.UserRead.UMGetUserByIdAsync(id);
        }

        public async Task<AppIdentityUser> UMGetUserByNameAsync(string userName)
        {
            return await _unitOfWork.UserRead.UMGetUserByNameAsync(userName);
        }

        public async Task<List<AppIdentityUser>> UMGetUsersWhereAsync(Expression<Func<AppIdentityUser, bool>> predicate)
        {
            return await _unitOfWork.UserRead.UMGetWhere(predicate).ToListAsync();
        }

        public async Task<List<AppIdentityUser>> UMGetWhereByRoleAsync(Func<AppIdentityUser, bool> predicate, string roleName)
        {
            return (await _unitOfWork.UserRead.UMGetWhereByRoleAsync(predicate, roleName)).ToList();
        }

        public async Task<IdentityResult> UMUpdateAsync(AppIdentityUser loginedUser)
        {
            return await _unitOfWork.UserWrite.UpdateAsync(loginedUser);
        }
    }
}
