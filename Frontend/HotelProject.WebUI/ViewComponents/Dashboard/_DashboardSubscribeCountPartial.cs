using HotelProject.WebUI.Dtos.FollowersDto;

using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
	public class _DashboardSubscribeCountPartial : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{

			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://instagram-scraper-20251.p.rapidapi.com/userinfo/?username_or_id=instagram"),
				Headers =
	{
		{ "x-rapidapi-key", "d9c339f828msha13543048cb994ap1327d7jsnd28779ad6013" },
		{ "x-rapidapi-host", "instagram-scraper-20251.p.rapidapi.com" },
	},

			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				ResultInstagramFollowersDto resultInstagramFollowersDto = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
				var json = JObject.Parse(body);
				ViewBag.ig1 = (int)json["data"]["follower_count"];
				ViewBag.ig2 = (int)json["data"]["following_count"];

				


			}

			var client2 = new HttpClient();
			var request2 = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://twitter-followers.p.rapidapi.com/instagram/profile"),
				Headers =
			{
				{ "x-rapidapi-key", "d9c339f828msha13543048cb994ap1327d7jsnd28779ad6013" },
				{ "x-rapidapi-host", "twitter-followers.p.rapidapi.com" },
			},
			};
			using (var response2 = await client2.SendAsync(request2))
			{
				response2.EnsureSuccessStatusCode();
				var body2 = await response2.Content.ReadAsStringAsync();
			
				Console.WriteLine("API Response: " + body2);

				ResultTwitterFollowersDto.Rootobject resultTwitterFollowersDto =
	JsonConvert.DeserializeObject<ResultTwitterFollowersDto.Rootobject>(body2);

				var json = JObject.Parse(body2);
				ViewBag.tw1 = resultTwitterFollowersDto.friendsCount;
				ViewBag.tw2 = resultTwitterFollowersDto.followersCount;

			
			}
			return View();


		} 
	}
}


