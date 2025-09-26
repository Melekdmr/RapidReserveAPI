using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{

	public class SettingsController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public SettingsController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			UserEditViewModel userEditViewModel = new UserEditViewModel();
			userEditViewModel.Name = user.Name;
			userEditViewModel.Surname = user.SurName;
			userEditViewModel.Email = user.Email;
			userEditViewModel.UserName = user.UserName;
			return View(userEditViewModel);
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
		{
			if (userEditViewModel.Password == userEditViewModel.ConfirmPassword)
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				user.Name = userEditViewModel.Name;
				user.SurName = userEditViewModel.Surname;
				user.Email = userEditViewModel.Email;
				user.UserName = userEditViewModel.UserName;
				user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.Password);
				await _userManager.UpdateAsync(user);
				return RedirectToAction("Index", "Login");

			}
			return View();
			
		}
	}
}
