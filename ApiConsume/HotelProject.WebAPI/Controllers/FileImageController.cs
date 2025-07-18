using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FileImageController : ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> UploadImage(IFormFile file)
		{
			var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);


			var path = Path.Combine(Directory.GetCurrentDirectory(), "images", fileName);

			using (var stream = new FileStream(path, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			return Created("", file);
			/* Dosya kilitlenme hatasını önlemek için FileStream'i 'using' bloğu ile açıyoruz.
            'using' bloğu, işlem tamamlandığında dosya akışını otomatik kapatarak
             başka işlemlerin dosyaya erişmesini sağlar.
             Eğer dosya başka bir yerde açık kalırsa, "Dosya başka işlem tarafından kullanılıyor" hatası alınır.*/


		}
	}
}
