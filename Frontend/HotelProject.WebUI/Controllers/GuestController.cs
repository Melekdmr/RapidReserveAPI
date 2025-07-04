using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
	public class GuestController : Controller
	{


		private readonly IHttpClientFactory _httpClientFactory; // Bu, HTTP istekleri yapmak için kullanılan bir servistir.
																// Bu sınıf, web API'lerine (bu örnekte Guest API'ye) HTTP istekleri göndermek için kullanılır.
																// IHttpClientFactory aracılığıyla HttpClient örnekleri oluşturulabilir.
																// Bu sınıfı, DI (Dependency Injection) ile alıyoruz.

		public GuestController(IHttpClientFactory httpClientFactory)    // Bu, GuestController sınıfının yapıcı(constructor) metodudur.
																		// Bu metod, controller oluşturulduğunda program cs.de  IHttpClientFactory'yi alır
																		// ve sınıfın bir özelliği olan _httpClientFactory değişkenine atar.
																		//Bu sayede, HTTP isteklerini yapacak bir HttpClient nesnesi oluşturulacak.
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();  //_httpClientFactory.CreateClient() ile bir HttpClient örneği oluşturuluyor. HttpClient, dış servislere (API'lere) HTTP istekleri göndermek için kullanılır.
															 //CreateClient(), DI aracılığıyla alınan IHttpClientFactory'nin bir metodudur. Bu metot, yeniden kullanılabilir HttpClient nesnesi oluşturur.

			var responseMessage = await client.GetAsync("http://localhost:5035/api/Guest");//GetAsync metodu, belirtilen URL'ye bu örnekte    GET isteği gönderir. Bu API endpoint'ine bir GET isteği yapılır.
			if (responseMessage.IsSuccessStatusCode)//IsSuccessStatusCode özelliği, HTTP yanıtının başarılı olup olmadığını kontrol eder
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();//HTTP cevabının gövdesindeki içeriği string formatında okur. Bu içerik genellikle JSON formatında gelir, çünkü API genellikle JSON verisi döndürür.

				//await burada, verinin okunmasını bekler.
				var values = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData); // jsonData içinde gelen JSON verisi, GuestViewModel türündeki bir List'e dönüştürülür.
				return View(values); //values değişkenini, yani GuestViewModel listesine dönüştürülmüş olan personel verilerini, ilgili view'a gönderir.
			}
			return View(); //Eğer API'den başarılı bir cevap alınmazsa (örneğin, IsSuccessStatusCode false dönerse), hiçbir şey gönderilmeden boş bir view döndürülür. 
		}

		[HttpGet]
		public IActionResult AddGuest()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddGuest(CreateGuestDto model)
		{
			if (ModelState.IsValid)
			{
				var client = _httpClientFactory.CreateClient();
				var jsonData = JsonConvert.SerializeObject(model);
				StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
				var responseMessage = await client.PostAsync("http://localhost:5035/api/Guest", stringContent);
				if (responseMessage.IsSuccessStatusCode)
				{
					TempData["Success"] = "Başarıyla eklendi.";
					return RedirectToAction("Index");
				}
				else
				{
					var error = await responseMessage.Content.ReadAsStringAsync();
					TempData["Error"] = $"API başarısız: {responseMessage.StatusCode} - {error}";
					return View(model);
				}


			}
			else return View();


		}
		public async Task<IActionResult> DeleteGuest(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"http://localhost:5035/api/Guest/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateGuest(int id)
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"http://localhost:5035/api/Guest/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateGuestDto>(jsonData);
				return View(values);
			}
			return View();

		}
		[HttpPost]
		public async Task<IActionResult> UpdateGuest(UpdateGuestDto model)
		{
			if (ModelState.IsValid)
			{
				var client = _httpClientFactory.CreateClient();
				var jsonData = JsonConvert.SerializeObject(model);
				StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
				var responseMessage = await client.PutAsync("http://localhost:5035/api/Guest/", stringContent);
				if (responseMessage.IsSuccessStatusCode)
				{
					return RedirectToAction("Index");
				}

				return View();

			}
			return View();

		}
	}
}


