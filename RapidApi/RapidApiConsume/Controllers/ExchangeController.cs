using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
	public class ExchangeController : Controller
	{
		public async Task<IActionResult> Index()
		{

	
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
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
				var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
				return View(values.exchange_rates.ToList());
			
			}

		}
	}
}
