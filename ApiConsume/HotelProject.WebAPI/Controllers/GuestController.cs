using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GuestController : ControllerBase
	{

		private readonly IGuestService _guestService;

		public GuestController(IGuestService guestService)
		{
			_guestService = guestService;
		}

		[HttpGet]
		public IActionResult GuestList()
		{
			var values = _guestService.TGetList();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult AddGuest(Guest p)
		{
			_guestService.TInsert(p);

			return StatusCode(201);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteGuest(int id)
		{
			var values = _guestService.TGetByID(id);
			_guestService.TDelete(values);
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateGuest(Guest guest)
		{
			_guestService.TUpdate(guest);
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult GetGuest(int id)
		{
			var values = _guestService.TGetByID(id);
			return Ok(values);
		}
	}
}



