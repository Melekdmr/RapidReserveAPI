using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
	public class BookingAdminController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BookingAdminController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:5035/api/Booking");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
				return View(values);
			}
			return View();
		}



		public async Task<IActionResult> ApprovedReservation2(int id)
		{

			// Mevcut rezervasyonu getir
			var client = _httpClientFactory.CreateClient();

			
			
			var responseMessage = await client.GetAsync($"http://localhost:5035/api/Booking/BookingApproved?id={id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}



			return View();
		}
		public async Task<IActionResult> ReservationCancel(int id)
		{

		
			var client = _httpClientFactory.CreateClient();



			var responseMessage = await client.GetAsync($"http://localhost:5035/api/Booking/BookingCancel?id={id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}



			return View();
		}

		public async Task<IActionResult> ReservationWaiting(int id)
		{


			var client = _httpClientFactory.CreateClient();



			var responseMessage = await client.GetAsync($"http://localhost:5035/api/Booking/BookingWaiting?id={id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}



			return View();
		}
		public async Task<IActionResult> ApprovedReservation(ResultBookingDto resultBookingDto)
		{

			// Mevcut rezervasyonu getir
			var client = _httpClientFactory.CreateClient();

			var JsonData = JsonConvert.SerializeObject(resultBookingDto);
			StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync($"http://localhost:5035/api/Booking/", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}



			return View();
		}



		

		

	}
}

