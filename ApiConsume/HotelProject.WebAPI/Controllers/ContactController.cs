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


		[HttpGet]
		public IActionResult ContactInboxList()
		{
			var values = _contactService.TGetList();
			return Ok(values);
		}

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

		[HttpGet("{id}")]
		public IActionResult GetSendMessage(int id)
		{
			var values = _contactService.TGetByID(id);
			return Ok(values);
		}
		[HttpGet("GetContactCount")]
		public IActionResult GetContactCount()
		{
			return Ok(_contactService.TGetContactCount());
		}


	}
}
