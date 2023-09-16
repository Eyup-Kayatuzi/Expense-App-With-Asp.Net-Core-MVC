using MasrafUygulamasi.Application.Interfaces.IServices;
using MasrafUygulamasi.Domain.Dtos;
using MasrafUygulamasi.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasrafUygulamasi.MVC.Controllers
{
	public class UserAuthenticationController : Controller
	{
		
		private readonly IUserAuthenticationService _userAuthService;
		public UserAuthenticationController(IUserService userService, IUserAuthenticationService userAuthService)
		{

			_userAuthService = userAuthService;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginVM model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			else
			{
				LoginDto loginDto = new() { UserName = model.UserName, Password = model.Password};
				var result =await _userAuthService.LoginStatusCheckAsync(loginDto);
				if (result.StatusString == "1")
				{
					var userRoles = await _userAuthService.LoggedInUserRoles(loginDto);
					if (userRoles[0] == "personel")
					{
						return RedirectToAction("HomePage", "Main", new {area = "Personnel" });
					}
					else if (userRoles[0] == "yonetici")
					{
						return RedirectToAction("HomePage", "Main", new { area = "CompanyManager" });
					}
					else if (userRoles[0] == "muhasebeci")
					{
						return RedirectToAction("HomePage", "Main", new { area = "Accountant" });
					}
					else
					{
						return RedirectToAction("HomePage", "Main", new { area = "Admin" });
					}
				}
				else
				{
					TempData["msg"] = result.Message;
					return RedirectToAction("Login");
				}
				
			}
		}
		[Authorize]
		public async Task<IActionResult> Logout()
		{
			await _userAuthService.LogoutAsync();
			return RedirectToAction("Login");
		}

	}
}
