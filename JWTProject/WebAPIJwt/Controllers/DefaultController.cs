using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIJwt.Models;

namespace WebAPIJwt.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DefaultController : ControllerBase
	{
		// GET api/default/test
		// Bu endpoint, yeni bir JWT token oluşturur ve döner.
		// Token oluşturma işlemi CreateToken sınıfındaki TokenCreate metoduyla yapılır.
		// Ok() ile döndürülmesi, HTTP 200 OK ve token stringi anlamına gelir.
		[HttpGet("[action]")] //"[action]": Route URL'sinde metodun adının kullanılacağını belirtir. metodun adı ile değiştirilir, yani Test veya Test2.
		public IActionResult TokenOlustur()
		{
			return Ok(new CreateToken().TokenCreate()); // Token döndürülür
		}



		[HttpGet("[action]")] 
		public IActionResult AdminTokenOlustur()
		{
			return Ok(new CreateToken().TokenCreateAdmin()); // Token döndürülür
		}



		// GET api/default/test2
		// Bu endpoint 'Bearer' tipi JWT token ile yetkilendirilmiştir.
		// Yani bu metoda erişmek için geçerli bir JWT token ile Authorization header gönderilmelidir.
		// Token doğrulanırsa "Yetkilendirme başarılı!" mesajı döner.
		[Authorize(AuthenticationSchemes = "Bearer")]
		[HttpGet("[action]")]
		public IActionResult Test2()
		{
			return Ok("Yetkilendirme başarılı!"); // Yetkilendirme başarılı ise bu cevap döner
		}



		[Authorize(AuthenticationSchemes = "Bearer" ,Roles ="Admin,Visitor")]
		[HttpGet("[action]")]
		public IActionResult Test3()  //Erişim yetkisi yoksa 403 hatası alırız
		{
			return Ok(" Rol kapsamlı Yetkilendirme başarılı!"); // Yetkilendirme başarılı ise bu cevap döner
		}
	}
}
