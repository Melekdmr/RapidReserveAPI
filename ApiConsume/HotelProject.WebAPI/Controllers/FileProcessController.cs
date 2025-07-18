using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FileProcessController : ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> UploadFile(IFormFile file)
		{
			var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);


			var path = Path.Combine(Directory.GetCurrentDirectory(), "files", fileName);

			using (var stream = new FileStream(path, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			return Created("", file);
		}
	}
}