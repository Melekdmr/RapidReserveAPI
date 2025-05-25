using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;
using System.Net.Http.Headers;

namespace RapidApiConsume.Controllers
{
	public class ImdbController : Controller
	{

		public async Task<IActionResult> Index()
		{
			List<ApiMovieViewModel> apiMovieViewModels = new List<ApiMovieViewModel>();

			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb236.p.rapidapi.com/api/imdb/top250-tv"),
				Headers =
	{
			 { "x-rapidapi-key", "d9c339f828msha13543048cb994ap1327d7jsnd28779ad6013" }, //apiye erişim içn gerekli olan key
			 { "x-rapidapi-host", "imdb236.p.rapidapi.com" }, //apiyi sağlayan link
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				apiMovieViewModels = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);

				return View(apiMovieViewModels);
			}
		
		}
	}
}
