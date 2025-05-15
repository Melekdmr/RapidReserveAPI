using HotelProject.WebUI.Models;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
	public class StaffController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory; // Bu, HTTP istekleri yapmak için kullanılan bir servistir.
																// Bu sınıf, web API'lerine (bu örnekte Staff API'ye) HTTP istekleri göndermek için kullanılır.
																// IHttpClientFactory aracılığıyla HttpClient örnekleri oluşturulabilir.
																// Bu sınıfı, DI (Dependency Injection) ile alıyoruz.

		public StaffController(IHttpClientFactory httpClientFactory)    // Bu, StaffController sınıfının yapıcı(constructor) metodudur.
																		// Bu metod, controller oluşturulduğunda program cs.de  IHttpClientFactory'yi alır
																		// ve sınıfın bir özelliği olan _httpClientFactory değişkenine atar.
																		//Bu sayede, HTTP isteklerini yapacak bir HttpClient nesnesi oluşturulacak.
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task< IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();  //_httpClientFactory.CreateClient() ile bir HttpClient örneği oluşturuluyor. HttpClient, dış servislere (API'lere) HTTP istekleri göndermek için kullanılır.
															 //CreateClient(), DI aracılığıyla alınan IHttpClientFactory'nin bir metodudur. Bu metot, yeniden kullanılabilir HttpClient nesnesi oluşturur.

			var responseMessage = await client.GetAsync("https://localhost:7064/api/Staff");//GetAsync metodu, belirtilen URL'ye (bu örnekte https://localhost:7064/api/Staff) GET isteği gönderir. Bu API endpoint'ine bir GET isteği yapılır.
			if (responseMessage.IsSuccessStatusCode)//IsSuccessStatusCode özelliği, HTTP yanıtının başarılı olup olmadığını kontrol eder
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();//HTTP cevabının gövdesindeki içeriği string formatında okur. Bu içerik genellikle JSON formatında gelir, çünkü API genellikle JSON verisi döndürür.

				//await burada, verinin okunmasını bekler.
								var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData); // jsonData içinde gelen JSON verisi, StaffViewModel türündeki bir List'e dönüştürülür.
				return View(values); //values değişkenini, yani StaffViewModel listesine dönüştürülmüş olan personel verilerini, ilgili view'a gönderir.
			}
			return View(); //ğer API'den başarılı bir cevap alınmazsa (örneğin, IsSuccessStatusCode false dönerse), hiçbir şey gönderilmeden boş bir view döndürülür. 
		}

		[HttpGet]
		public IActionResult AddStaff()
		{
			return View();
		}
		[HttpPost]
		public async Task <IActionResult> AddStaff(AddStaffViewModel model)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7064/api/Staff",stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View(model);

		}
		public async Task<IActionResult> DeleteStaff(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7064/api/Staff/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateStaff(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7064/api/Staff/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
				return View(values);
			}
			return View();

		}
		[HttpPost]
		public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel model)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7064/api/Staff/",stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();

		}

	}
}
