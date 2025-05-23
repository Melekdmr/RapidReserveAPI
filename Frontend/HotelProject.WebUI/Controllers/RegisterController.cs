using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using HotelProject.WebUI.Dtos.RegisterDto;


namespace HotelProject.WebUI.Controllers
{
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;


		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateNewUserDto createNewUserDto)
		{
			if (!ModelState.IsValid)  return View(); 
			var appUser = new AppUser()
			{
				Name = createNewUserDto.Name,
				SurName = createNewUserDto.SurName,
				Email = createNewUserDto.Mail,
				UserName = createNewUserDto.UserName,
			};
			var result = await _userManager.CreateAsync(appUser, createNewUserDto.Password);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Login");
			}
			return View();
		}
	}
}
