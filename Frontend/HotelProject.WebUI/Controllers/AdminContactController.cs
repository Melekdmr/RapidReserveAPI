using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
	public class AdminContactController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory; 

		public AdminContactController(IHttpClientFactory httpClientFactory)    
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Inbox()
		{
			var client = _httpClientFactory.CreateClient();  

			var responseMessage = await client.GetAsync("http://localhost:5035/api/Contact");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();

				
				var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
				return View(values); 
			}
			return View();  
		}
	
	
		[HttpGet]
		public IActionResult AddSendMessage()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddSendMessage(CreateSendMessageDto model)
		{
			model.SenderMail = "admin@gmail.com";
			model.SenderName = "Admin";
			model.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:5035/api/SendMessage", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("SendBox");
			}
			return View(model);

		}
		public PartialViewResult SideBarAdminContactPartial()
		{
			return PartialView();
		}
		public PartialViewResult SideBarAdminContactCaetgoryPartial()
		{
			return PartialView();
		}
	
	}
}
