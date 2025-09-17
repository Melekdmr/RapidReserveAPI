using HotelProject.WebUI.Dtos.AppUserDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
	public class AdminUserListWithWorkLocaitonController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AdminUserListWithWorkLocaitonController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		
			public async Task<IActionResult> UserList()
		{
			try
			{
				var client = _httpClientFactory.CreateClient();
				var responseMessage = await client.GetAsync("http://localhost:5035/api/AppUserWorkLocation");

				if (responseMessage.IsSuccessStatusCode)
				{
					var jsonData = await responseMessage.Content.ReadAsStringAsync();
					var values = JsonConvert.DeserializeObject<List<ResultAppUserWithWorkLocationDto>>(jsonData);
					return View(values ?? new List<ResultAppUserWithWorkLocationDto>());
				}

				// Hata durumunda boş liste göster
				return View(new List<ResultAppUserWithWorkLocationDto>());
			}
			catch (Exception ex)
			{
				// Log the exception
				Console.WriteLine($"Index Error: {ex.Message}");
				return View(new List<ResultAppUserWithWorkLocationDto>());
			}
		}

	}
}
