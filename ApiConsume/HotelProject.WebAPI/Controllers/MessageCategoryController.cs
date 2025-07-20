using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using HotelProject.BusinessLayer.Abstract;


namespace HotelProject.WebUI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageCategoryController : ControllerBase
	{
		private readonly IMessageCategoryService _messageCategoryService;

		public MessageCategoryController(IMessageCategoryService messageCategoryService)
		{
			_messageCategoryService = messageCategoryService;
		}

		[HttpGet]
		public IActionResult MessageCategoryList()
		{
			var values = _messageCategoryService.TGetList();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult AddMessageCategory(MessageCategory p)
		{
			_messageCategoryService.TInsert(p);

			return StatusCode(201);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteMessageCategory(int id)
		{
			var values = _messageCategoryService.TGetByID(id);
			_messageCategoryService.TDelete(values);
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateMessageCategory(MessageCategory messageCategory)
		{
			_messageCategoryService.TUpdate(messageCategory);
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult GetMessageCategory(int id)
		{
			var values = _messageCategoryService.TGetByID(id);
			return Ok(values);
		}
	}
}

