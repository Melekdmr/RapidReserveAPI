using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialController : ControllerBase
	{
		
			private readonly ITestimonialService _testimonialService;

		public TestimonialController(ITestimonialService testimonialService)
		{
			_testimonialService = testimonialService;
		}

		[HttpGet]
			public IActionResult TestimonialList()
			{
				var values = _testimonialService.TGetList();
				return Ok(values);
			}
			[HttpPost]
			public IActionResult AddTestimonial(Testimonial p)
			{
				_testimonialService.TInsert(p);

				return StatusCode(201);
			}

			[HttpDelete("{id}")]
			public IActionResult DeleteTestimonial(int id)
			{
				var values = _testimonialService.TGetByID(id);
				_testimonialService.TDelete(values);
				return Ok();
			}
			[HttpPut]
			public IActionResult UpdateTestimonial(Testimonial testimonial)
			{
				_testimonialService.TUpdate(testimonial);
				return Ok();
			}
			[HttpGet("{id}")]
			public IActionResult GetTestimonial(int id)
			{
				var values = _testimonialService.TGetByID(id);
				return Ok(values);
			}
		}
	}


