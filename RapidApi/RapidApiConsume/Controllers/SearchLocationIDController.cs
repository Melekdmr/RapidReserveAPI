using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
	public class SearchLocationIDController : Controller
	{
		public async Task<IActionResult> Index(string cityName)
		{
			if (!string.IsNullOrEmpty(cityName))
			{
				List<BookingApiLocationSerachViewModel> models = new List<BookingApiLocationSerachViewModel>();
				var client = new HttpClient();
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name={cityName}"),
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
					models = JsonConvert.DeserializeObject<List<BookingApiLocationSerachViewModel>>(body);
					return View(models.Take(1).ToList());
				}
			}
			else
			{
				List<BookingApiLocationSerachViewModel> models = new List<BookingApiLocationSerachViewModel>();
				var client = new HttpClient();
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name=Paris"),
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
					models = JsonConvert.DeserializeObject<List<BookingApiLocationSerachViewModel>>(body);
					return View(models.Take(1).ToList());
				}
			}
		
		}
	}
}

