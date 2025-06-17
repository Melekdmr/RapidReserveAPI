using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
	// Bu controller, Booking.com API'sinden şehir ismine göre konum bilgisi (location ID) alır
	public class SearchLocationIDController : Controller // ASP.NET Core Controller sınıfından türetiliyor
	{
		// Index action metodu (getirme işlemi). string cityName dışarıdan gelen parametre (form, query vs.)
		public async Task<IActionResult> Index(string cityName)
		{
			// Eğer kullanıcı bir şehir ismi girdiyse
			if (!string.IsNullOrEmpty(cityName))
			{
				// Booking API'den dönen verileri tutacak model listesi oluşturuluyor
				List<BookingApiLocationSerachViewModel> models = new List<BookingApiLocationSerachViewModel>();

				// HTTP istekleri için bir HttpClient nesnesi oluşturuluyor
				var client = new HttpClient();

				// RapidAPI'ye GET isteği hazırlığı yapılıyor (kullanıcının girdiği şehir ismiyle)
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get, // HTTP GET metodu kullanılacak

					// İstek atılacak URL (cityName query parametresi ile gönderiliyor)
					RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name={cityName}"),

					// RapidAPI için gerekli header bilgileri ekleniyor
					Headers =
					{
						{ "x-rapidapi-key", "d9c339f828msha13543048cb994ap1327d7jsnd28779ad6013" }, // API anahtarı
						{ "x-rapidapi-host", "booking-com.p.rapidapi.com" }, // API'nin host adı
					},
				};

				// HTTP isteği gönderiliyor ve yanıt bekleniyor (await: asenkron işlem)
				using (var response = await client.SendAsync(request))
				{
					response.EnsureSuccessStatusCode(); // Yanıtın başarılı olup olmadığını kontrol eder (aksi halde exception fırlatır)

					// API'den dönen JSON içeriği string olarak alınıyor
					var body = await response.Content.ReadAsStringAsync();

					// JSON verisi, BookingApiLocationSerachViewModel tipinde bir listeye dönüştürülüyor
					models = JsonConvert.DeserializeObject<List<BookingApiLocationSerachViewModel>>(body);

					// Sadece ilk sonuç View'a gönderiliyor (örneğin en alakalı şehir)
					return View(models.Take(1).ToList());
				}
			}
			else // Eğer kullanıcı şehir ismi girmezse (boş ise)
			{
				// Yine aynı model listesi hazırlanıyor
				List<BookingApiLocationSerachViewModel> models = new List<BookingApiLocationSerachViewModel>();

				// HTTP istemcisi oluşturuluyor
				var client = new HttpClient();

				// Bu kez sabit bir şehir ismi (Paris) ile API isteği hazırlanıyor
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get, // GET metodu
					RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name=Paris"), // Şehir ismi sabit olarak Paris

					// Aynı RapidAPI header bilgileri
					Headers =
					{
						{ "x-rapidapi-key", "d9c339f828msha13543048cb994ap1327d7jsnd28779ad6013" },
						{ "x-rapidapi-host", "booking-com.p.rapidapi.com" },
					},
				};

				// API isteği gönderiliyor
				using (var response = await client.SendAsync(request))
				{
					response.EnsureSuccessStatusCode(); // Başarılı yanıt kontrolü

					// JSON cevabı okunuyor
					var body = await response.Content.ReadAsStringAsync();

					// JSON verisi modele dönüştürülüyor
					models = JsonConvert.DeserializeObject<List<BookingApiLocationSerachViewModel>>(body);

					// Sadece ilk sonuç View'a gönderiliyor
					return View(models.Take(1).ToList());
				}
			}
		}
	}
}