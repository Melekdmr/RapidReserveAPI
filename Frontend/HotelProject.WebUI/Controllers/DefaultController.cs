﻿using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
	[AllowAnonymous]
	public class DefaultController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public DefaultController (IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult _SubscribePartial()
		{
			return PartialView();
		}
		[HttpPost]
		public async Task< IActionResult>_SubscribePartial(CreateSubscribeDto createSubscribeDto)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createSubscribeDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:5035/api/Subscribe", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
