using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Dtos.StaffDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
	public class _DashboardLast4StaffPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory; 

		public _DashboardLast4StaffPartial(IHttpClientFactory httpClientFactory)    
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task< IViewComponentResult> InvokeAsync()
		{

			var client = _httpClientFactory.CreateClient();

			var responseMessage = await client.GetAsync("http://localhost:5035/api/Staff/Last4Staff");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();


				var values = JsonConvert.DeserializeObject<List<ResultLast4Staff>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
	}

