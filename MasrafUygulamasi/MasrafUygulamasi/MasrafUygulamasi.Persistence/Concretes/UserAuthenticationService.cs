using MasrafUygulamasi.Application.Interfaces.IServices;
using MasrafUygulamasi.Domain.Dtos;
using MasrafUygulamasi.Domain.Identity;


namespace MasrafUygulamasi.Persistence.Concretes
{
	public class UserAuthenticationService : IUserAuthenticationService
	{
		private readonly IUserService _userService;
        public UserAuthenticationService(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<StatusDto> LoginStatusCheckAsync(LoginDto model)
		{
			var status = new StatusDto();
			var user = await _userService.UMGetUserByNameAsync(model.UserName);
			if (user == null)
			{
				status.StatusString = "0";
				status.Message = "Invalid username or password";
				return status;
			}
			else
			{
				var isValidPassword = await _userService.UMCheckUserWithPasswordAsync(user, model.Password);
				if (!isValidPassword)
				{
					status.StatusString = "0";
					status.Message = "Invalid username or password";
					return status;
				}
				else
				{
					var signInResult = await _userService.SMSignInWithPasswordAsync(user, model.Password);
					if (signInResult.Succeeded)
					{
						status.StatusString = "1";
						status.Message = "Logged in successfully";
						return status;
					}
					else
					{
						status.StatusString = "0";
						status.Message = "Error occurred while signing in";
						return status;
					}
				}
			}
		}
		public async Task<List<string>> LoggedInUserRoles(LoginDto model)
		{
			AppIdentityUser loginedUser = await _userService.UMGetUserByNameAsync(model.UserName);
			List<string> roles = await _userService.UMGetAllRolesByUserAsync(loginedUser);
			return roles;
		}

		public async Task LogoutAsync()
		{
			await _userService.SMLogOffAsync();
		}
	}
}
