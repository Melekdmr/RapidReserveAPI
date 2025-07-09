using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SendMessageController : ControllerBase
	{
			
		private readonly ISendMessageService _sendMessageService;

		public SendMessageController(ISendMessageService sendMessageService)
		{
			_sendMessageService = sendMessageService;
		}

		[HttpGet]
		public IActionResult SendMessageList()
		{
			var values = _sendMessageService.TGetList();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult AddSendMessage(SendMessage p)
		{
			_sendMessageService.TInsert(p);

			return StatusCode(201);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteSendMessage(int id)
		{
			var values = _sendMessageService.TGetByID(id);
			_sendMessageService.TDelete(values);
			return Ok();
		}
		[HttpPut("{id}")]
		public IActionResult UpdateSendMessage(int id, SendMessage sendMessage)
		{
			sendMessage.SendMessageId = id; // ID'yi emin olmak için set edin
			_sendMessageService.TUpdate(sendMessage);
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult GetSendMessage(int id)
		{
			var values = _sendMessageService.TGetByID(id);
			return Ok(values);
		}
	}
}
	