﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StaffController : ControllerBase
	{
		private readonly IStaffService _staffService;

		public StaffController(IStaffService staffService)
		{
			_staffService = staffService;
		}

		[HttpGet]
		public IActionResult StaffList()
		{
			var values = _staffService.TGetList();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult AddStaff(Staff p)
		{
            _staffService.TInsert(p);

			return StatusCode(201);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteStaff(int id)
		{
			var values = _staffService.TGetByID(id);
			_staffService.TDelete(values);
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateStaff(Staff staff)
		{
			_staffService.TUpdate(staff);
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult GetStaff(int id)
		{
			var values=_staffService.TGetByID(id);
			return Ok(values);
		}
	}
}
