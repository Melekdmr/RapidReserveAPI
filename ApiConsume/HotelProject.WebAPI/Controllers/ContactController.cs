using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;



namespace HotelProject.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}
		[HttpPost]
		public IActionResult AddContect(Contact p)
		{
			p.Date = Convert.ToDateTime(DateTime.Now.ToString());
			_contactService.TInsert(p);

			return StatusCode(201);
		}

	}
}
