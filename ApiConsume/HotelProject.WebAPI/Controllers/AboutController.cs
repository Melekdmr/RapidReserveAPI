using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutController : ControllerBase
	{

		private readonly IAboutService _aboutService;

		public AboutController(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		[HttpGet]
		public IActionResult AboutList()
		{
			var values = _aboutService.TGetList();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult AddAbout(About p)
		{
			_aboutService.TInsert(p);

			return StatusCode(201);
		}

		[HttpDelete]
		public IActionResult DeleteAbout(int id)
		{
			var values = _aboutService.TGetByID(id);
			_aboutService.TDelete(values);
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateAbout(About about)
		{
			_aboutService.TUpdate(about);
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult GetAbout(int id)
		{
			var values = _aboutService.TGetByID(id);
			return Ok(values);
		}
	}
}


