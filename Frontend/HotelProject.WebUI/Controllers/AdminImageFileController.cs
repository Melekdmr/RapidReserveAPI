using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HotelProject.WebUI.Controllers
{
	public class AdminImageFileController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(IFormFile file)
		{
			// 1. Yeni bir MemoryStream nesnesi oluşturuluyor.Bu stream, dosyanın bellekte tutulacağı yerdir
		 
			var stream = new MemoryStream();

			// 2. Gelen dosya, memory stream'e kopyalanıyor (asenkron olarak)
			await file.CopyToAsync(stream); 

			// 3. Stream'deki veriler byte dizisine dönüştürülüyor.	API’ye gönderilecek ham veri bu byte dizisidir

			var bytes = stream.ToArray();

			// 4. Byte dizisinden ByteArrayContent nesnesi oluşturuluyor. Bu, HTTP isteğinde gönderilecek içeriktir
		
			ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);

			// 5. İçeriğin Content-Type başlığı ayarlanıyor(örneğin image/png, application/pdf gibi)
			byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

			// 6. MultipartFormDataContent oluşturuluyor. Bu, dosyanın form-data olarak gönderilmesini sağlar

			MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();

			// 7. Dosya içeriği form-data içeriğine ekleniyor. "file" burada API tarafındaki parametre adıdır
	
			multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);

			// 8. Yeni bir HttpClient nesnesi oluşturuluyor
			// API'ye istek göndermek için kullanılır
			var httpClient = new HttpClient();

			// 9. API'ye POST isteği gönderiliyor
			// Endpoint'e form-data ile dosya gönderilir
			await httpClient.PostAsync("http://localhost:5035/api/FileImage", multipartFormDataContent);

			
			return View();
		}

	}
}
