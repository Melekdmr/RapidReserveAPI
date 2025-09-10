using HotelProject.WebUI.Dtos.WorkLocationDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
	public class WorkLocationController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public WorkLocationController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			try
			{
				var client = _httpClientFactory.CreateClient();
				var responseMessage = await client.GetAsync("http://localhost:5035/api/WorkLocation");

				if (responseMessage.IsSuccessStatusCode)
				{
					var jsonData = await responseMessage.Content.ReadAsStringAsync();
					var values = JsonConvert.DeserializeObject<List<ResultWorkLocationDto>>(jsonData);
					return View(values ?? new List<ResultWorkLocationDto>());
				}

				// Hata durumunda boş liste göster
				return View(new List<ResultWorkLocationDto>());
			}
			catch (Exception ex)
			{
				// Log the exception
				Console.WriteLine($"Index Error: {ex.Message}");
				return View(new List<ResultWorkLocationDto>());
			}
		}

		[HttpGet]
		public IActionResult AddWorkLocation()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddWorkLocation(CreateWorkLocationDto model)
		{
			try
			{
				// Debug: Model değerlerini kontrol et
				Console.WriteLine($"Debug - Model: {JsonConvert.SerializeObject(model)}");

				if (!ModelState.IsValid)
				{
					Console.WriteLine("ModelState is not valid");
					foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
					{
						Console.WriteLine($"Validation Error: {error.ErrorMessage}");
					}
					return View(model);
				}

				var client = _httpClientFactory.CreateClient();
				var jsonData = JsonConvert.SerializeObject(model);

				// Debug: JSON data'yı kontrol et
				Console.WriteLine($"Debug - JSON Data: {jsonData}");

				StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

				var responseMessage = await client.PostAsync("http://localhost:5035/api/WorkLocation", stringContent);

				// Debug: Response'u kontrol et
				Console.WriteLine($"Debug - Status Code: {responseMessage.StatusCode}");
				Console.WriteLine($"Debug - Response Content: {await responseMessage.Content.ReadAsStringAsync()}");

				if (responseMessage.IsSuccessStatusCode)
				{
					Console.WriteLine("Success! Redirecting to Index...");
					return RedirectToAction("Index");
				}
				else
				{
					var errorContent = await responseMessage.Content.ReadAsStringAsync();
					Console.WriteLine($"API Error: {errorContent}");
					ModelState.AddModelError("", $"API Hatası: {responseMessage.StatusCode} - {errorContent}");
					return View(model);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"AddWorkLocation Error: {ex.Message}");
				Console.WriteLine($"Stack Trace: {ex.StackTrace}");
				ModelState.AddModelError("", $"Bir hata oluştu: {ex.Message}");
				return View(model);
			}
		}

		public async Task<IActionResult> DeleteWorkLocation(int id)
		{
			try
			{
				var client = _httpClientFactory.CreateClient();
				var responseMessage = await client.DeleteAsync($"http://localhost:5035/api/WorkLocation/{id}");

				if (responseMessage.IsSuccessStatusCode)
				{
					return RedirectToAction("Index");
				}

				return View();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"DeleteWorkLocation Error: {ex.Message}");
				return View();
			}
		}

		[HttpGet]
		public async Task<IActionResult> UpdateWorkLocation(int id)
		{
			try
			{
				var client = _httpClientFactory.CreateClient();
				var responseMessage = await client.GetAsync($"http://localhost:5035/api/WorkLocation/{id}");

				if (responseMessage.IsSuccessStatusCode)
				{
					var jsonData = await responseMessage.Content.ReadAsStringAsync();
					var values = JsonConvert.DeserializeObject<UpdateWorkLocationDto>(jsonData);
					return View(values);
				}
				return View();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"UpdateWorkLocation GET Error: {ex.Message}");
				return View();
			}
		}

		[HttpPost]
		public async Task<IActionResult> UpdateWorkLocation(UpdateWorkLocationDto model)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return View(model);
				}

				var client = _httpClientFactory.CreateClient();
				var jsonData = JsonConvert.SerializeObject(model);
				StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
				var responseMessage = await client.PutAsync("http://localhost:5035/api/WorkLocation/", stringContent);

				if (responseMessage.IsSuccessStatusCode)
				{
					return RedirectToAction("Index");
				}

				ModelState.AddModelError("", "Oda güncellenirken bir hata oluştu.");
				return View(model);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"UpdateWorkLocation POST Error: {ex.Message}");
				ModelState.AddModelError("", $"Bir hata oluştu: {ex.Message}");
				return View(model);
			}
		}
	}
}
