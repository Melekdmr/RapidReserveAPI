﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SubscribeController : ControllerBase
	{
		private readonly ISubscribeService _subscribeService;

		public SubscribeController(ISubscribeService subscribeService)
		{
			_subscribeService = subscribeService;
		}

		[HttpGet]
		public IActionResult SubscribeList()
		{
			var values = _subscribeService.TGetList();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult AddSubscribe(Subscribe p)
		{
			_subscribeService.TInsert(p);

			return StatusCode(201);
		}

		[HttpDelete]
		public IActionResult DeleteSubscribe(int id)
		{
			var values = _subscribeService.TGetByID(id);
			_subscribeService.TDelete(values);
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateSubscribe(Subscribe subscribe)
		{
			_subscribeService.TUpdate(subscribe);
			return Ok();

			}
		[HttpGet("{id}")]
		public IActionResult GetSubscribe(int id)
		{
			var values = _subscribeService.TGetByID(id);
			return Ok(values);
		}
	}
}


