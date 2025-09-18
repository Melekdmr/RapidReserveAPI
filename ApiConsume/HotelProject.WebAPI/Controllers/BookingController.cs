using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController : ControllerBase
	{
		private readonly IBookingService _bookingService;

		public BookingController(IBookingService bookingService)
		{
			_bookingService = bookingService;
		}

		[HttpGet]
		public IActionResult BookingList()
		{
			var values = _bookingService.TGetList();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult AddBooking(Booking p)
		{
			_bookingService.TInsert(p);

			return StatusCode(201);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteBooking(int id)
		{
			var values = _bookingService.TGetByID(id);
			_bookingService.TDelete(values);
			return Ok();
		}
		[HttpPut("{id}")]
		public IActionResult UpdateBooking(int id, Booking booking)
		{
			booking.BookingID = id; // ID'yi emin olmak için set edin
			_bookingService.TUpdate(booking);
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult GetBooking(int id)
		{
			var values = _bookingService.TGetByID(id);
			return Ok(values);
		}
		[HttpGet ("Last6Booking")]
		public IActionResult Last6Booking()
		{
			var values = _bookingService.TLast6Booking();
			return Ok(values);
		}

	}
}
	