using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HotelProject.WebUI.Controllers
{

	public class RoleAssignController : Controller
	{
		// Kullanıcı işlemlerini yönetmek için UserManager (Identity kütüphanesinden gelir)
		private readonly UserManager<AppUser> _userManager;

		// Rol işlemlerini yönetmek için RoleManager (Identity kütüphanesinden gelir)
		private readonly RoleManager<AppRole> _roleManager;

		// Constructor (Dependency Injection ile UserManager ve RoleManager dışarıdan geliyor)
		public RoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}

		// Tüm kullanıcıları listelemek için kullanılan action
		public IActionResult Index()
		{
			// Veritabanındaki tüm kullanıcıları çek
			var values = _userManager.Users.ToList();

			// Kullanıcı listesini Index view’ine gönder
			return View(values);
		}

		// Bir kullanıcıya rol atamak için sayfayı açan GET methodu
		[HttpGet]
		public async Task<IActionResult> AssignRole(int id)
		{
			// Parametreden gelen id'ye göre ilgili kullanıcıyı bul
			var user = _userManager.Users.FirstOrDefault(x => x.Id == id);

			// Kullanıcı Id’sini geçici olarak sakla (POST aşamasında lazım olacak)
			TempData["userid"] = user.Id;

			// Tüm rollerin listesini çek (Admin, User, Editor vs.)
			var roles = _roleManager.Roles.ToList();

			// Bu kullanıcının şu anda sahip olduğu rolleri getir (ör: ["Admin", "Writer"])
			var userRoles = await _userManager.GetRolesAsync(user);

			// Rol atama ekranı için kullanılacak ViewModel listesi
			List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();

			// Tüm roller üzerinde dön
			foreach (var item in roles)
			{
				// Her rol için yeni bir ViewModel nesnesi oluştur
				RoleAssignViewModel model = new RoleAssignViewModel();

				// RoleID → veritabanındaki rolün ID’si
				model.RoleID = item.Id;

				// RoleName → rolün adı (örn: "Admin")
				model.RoleName = item.Name;

				// RoleExist → Kullanıcı bu role sahip mi? (true/false)
				model.RoleExist = userRoles.Contains(item.Name);

				// Hazırlanan modeli listeye ekle
				roleAssignViewModels.Add(model);
			}

			// Rol atama sayfasına (AssignRole.cshtml) bu listeyi gönder
			return View(roleAssignViewModels);
		}

		[HttpPost]
		public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> roleAssignViewModel)
		{
			// GET metodunda TempData içine saklanan UserId’yi geri alıyoruz
			var userid = (int)TempData["userid"];

			// Id'si alınan kullanıcıyı buluyoruz
			var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);

			// View’den gelen tüm roller üzerinde dönüyoruz
			foreach (var item in roleAssignViewModel)
			{
				// Eğer checkbox işaretlenmişse (RoleExist = true)
				if (item.RoleExist)
				{
					// Kullanıcı bu role ekleniyor
					await _userManager.AddToRoleAsync(user, item.RoleName);
				}
				else
				{
					// Checkbox işaretli değilse → kullanıcıdan o rol siliniyor
					await _userManager.RemoveFromRoleAsync(user, item.RoleName);
				}
			}

			// İşlem bitince kullanıcı listesine geri dön
			return RedirectToAction("Index");
		}
	}
}
