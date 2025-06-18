using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
	public class BookingByCityController : Controller
	{
		public async Task<IActionResult> Index(string cityId)
		{
			if (!string.IsNullOrEmpty(cityId))
			{
				var client = new HttpClient();
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?children_number=2&adults_number=2&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&children_ages=5%2C0&checkout_date=2025-10-15&dest_type=city&page_number=0&units=metric&order_by=popularity&room_number=1&checkin_date=2025-10-14&filter_by_currency=AED&dest_id={cityId}&locale=en-gb&include_adjacency=true"),
					Headers =
	{
		{ "x-rapidapi-key", "d9c339f828msha13543048cb994ap1327d7jsnd28779ad6013" },
		{ "x-rapidapi-host", "booking-com.p.rapidapi.com" },
	},
				};
				
				using (var response = await client.SendAsync(request))
				{
					response.EnsureSuccessStatusCode();
					var body = await response.Content.ReadAsStringAsync();
					var values = JsonConvert.DeserializeObject<BookingApiModel>(body);
					return View(values.results.ToList());


				}

			}
			else
			{
				var client = new HttpClient();
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?children_number=2&adults_number=2&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&children_ages=5%2C0&checkout_date=2025-10-15&dest_type=city&page_number=0&units=metric&order_by=popularity&room_number=1&checkin_date=2025-10-14&filter_by_currency=AED&dest_id=-1456928&locale=en-gb&include_adjacency=true"),
					Headers =
	{
		{ "x-rapidapi-key", "d9c339f828msha13543048cb994ap1327d7jsnd28779ad6013" },
		{ "x-rapidapi-host", "booking-com.p.rapidapi.com" },
	},
				};
				using (var response = await client.SendAsync(request))
				{
					response.EnsureSuccessStatusCode();
					var body = await response.Content.ReadAsStringAsync();
					var values = JsonConvert.DeserializeObject<BookingApiModel>(body);
					return View(values.results.ToList());


				}
			}

		}
	}
}


