﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServiceController : ControllerBase
	{

		
			private readonly IServiceService _serviceService;

		public ServiceController(IServiceService serviceService)
		{
			_serviceService = serviceService;
		}

		[HttpGet]
			public IActionResult ServiceList()
			{
				var values = _serviceService.TGetList();
				return Ok(values);
			}
			[HttpPost]
			public IActionResult AddService(Service p)
			{
				_serviceService.TInsert(p);

				return StatusCode(201);
			}

		[HttpDelete("{id}")]
		public IActionResult DeleteService(int id)
			{
				var values = _serviceService.TGetByID(id);
				_serviceService.TDelete(values);
				return Ok();
			}
			[HttpPut]
			public IActionResult UpdateService(Service service)
			{
				_serviceService.TUpdate(service);
				return Ok();
			}
			[HttpGet("{id}")]
			public IActionResult GetService(int id)
			{
				var values = _serviceService.TGetByID(id);
				return Ok(values);
			}
		}
	}



