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
		[HttpGet("[action]")]
		public IActionResult Test()
		{
			return Ok(new CreateToken().TokenCreate()); //hata vermemek için Ok
		}
		[Authorize(AuthenticationSchemes ="Bearer")]
		[HttpGet("[action]")]
		public IActionResult Test2()
		{
			return Ok("Yetkilendirme başarılı!");
		}

	}
}
