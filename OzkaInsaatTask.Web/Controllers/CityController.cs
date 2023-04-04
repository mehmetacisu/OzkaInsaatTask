using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OzkaInsaatTask.Web.Models.City;
using System.Text;

namespace OzkaInsaatTask.Web.Controllers
{
	public class CityController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private const string baseUrl = "http://localhost:5186/api/City";
		public CityController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[Route("")]
		public async Task<IActionResult> Index()
		{
			using (var client = _httpClientFactory.CreateClient())
			{
				using var response = await client.GetAsync(baseUrl);
				if (response.IsSuccessStatusCode)
				{
					var jsonData = await response.Content.ReadAsStringAsync();
					var cities = JsonConvert.DeserializeObject<List<CityViewModel>>(jsonData);
					return View(cities);
				}
			}
			return View();
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddCityViewModel addCityViewModel)
		{
			using (var client = _httpClientFactory.CreateClient())
			{
				var jsonData = JsonConvert.SerializeObject(addCityViewModel);
				StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
				using var response = await client.PostAsync(baseUrl, stringContent);
				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction("Index");
				}
			}
			return View();
		}
		public async Task<IActionResult> Delete(int id)
		{
			using (var client = _httpClientFactory.CreateClient())
			{

				using var response = await client.DeleteAsync($"{baseUrl}/{id}");
				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction("Index");
				}
			};
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			using (var client = _httpClientFactory.CreateClient())
			{
				using var response = await client.GetAsync($"{baseUrl}/{id}");
				if(response.IsSuccessStatusCode)
				{
					var jsonData = await response.Content.ReadAsStringAsync();
					var city = JsonConvert.DeserializeObject<UpdateCityViewModel>(jsonData);
					return View(city);
				}
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Update(UpdateCityViewModel updateCityViewModel)
		{
			using (var client = _httpClientFactory.CreateClient())
			{
				var jsonData = JsonConvert.SerializeObject(updateCityViewModel);
				StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
				using var response = await client.PutAsync(baseUrl, stringContent);
				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction("Index");
				}
			}
			return View();
		}
	}
}
