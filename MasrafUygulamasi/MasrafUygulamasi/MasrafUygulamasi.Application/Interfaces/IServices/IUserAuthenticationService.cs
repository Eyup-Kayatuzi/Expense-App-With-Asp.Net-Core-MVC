using MasrafUygulamasi.Domain.Dtos;


namespace MasrafUygulamasi.Application.Interfaces.IServices
{
	public interface IUserAuthenticationService
	{
		Task<StatusDto> LoginStatusCheckAsync(LoginDto model);
		Task<List<string>> LoggedInUserRoles(LoginDto model);
		Task LogoutAsync();
	}
}
