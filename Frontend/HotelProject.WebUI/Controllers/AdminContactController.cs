﻿using HotelProject.WebUI.Dtos.ContactDto;
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

			var client2 = _httpClientFactory.CreateClient();

			var responseMessage2 = await client2.GetAsync("http://localhost:5035/api/Contact/GetContactCount");

			var client3 = _httpClientFactory.CreateClient();

			var responseMessage3 = await client3.GetAsync("http://localhost:5035/api/SendMessage/GetSendMessageCount");

			var client = _httpClientFactory.CreateClient();  
            var responseMessage = await client.GetAsync("http://localhost:5035/api/Contact");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
               var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);

				var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
				ViewBag.contactCount = jsonData2;


				var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
				ViewBag.sendMessageCount = jsonData3;


				return View(values); 
			}

			return View();  
		}
		public async Task<IActionResult> SendBox()
		{
			var client = _httpClientFactory.CreateClient();

			var responseMessage = await client.GetAsync("http://localhost:5035/api/SendMessage");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();


				var values = JsonConvert.DeserializeObject<List<ResultSendBoxDto>>(jsonData);
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
		public async Task< PartialViewResult> SideBarAdminContactPartial()
		{
			
		
			
		
			return PartialView();
		}
		
		
		public PartialViewResult SideBarAdminContactCaetgoryPartial()
		{
			return PartialView();
		}
	public async Task< IActionResult> MessageDetailsSendBox(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"http://localhost:5035/api/SendMessage/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData);
				return View(values);
			}
			return View();


		}
		public async Task<IActionResult> MessageDetailsByInbox(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"http://localhost:5035/api/Contact/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<InboxContactDto>(jsonData);
				return View(values);
			}
			return View();


		}
		
	}
}
