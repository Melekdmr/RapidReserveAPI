﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
	[AllowAnonymous]
	public class ErrorPagesController : Controller
	{
		public IActionResult Error404()
		{
			return View();
		}
	}
}
