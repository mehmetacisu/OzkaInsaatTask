using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OzkaInsaatTask.Core.DTOs;
using OzkaInsaatTask.Core.Models;
using OzkaInsaatTask.Core.Services;

namespace OzkaInsaatTask.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CityController : ControllerBase
	{
		private readonly IService<City> _cityService;
		private readonly IMapper _mapper;
		public CityController(IService<City> cityService,IMapper mapper)
		{
			_cityService = cityService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			var cities = await _cityService.GetAllAsync();
			return Ok(cities);
		}

		[HttpPost]
		public async Task<IActionResult> Add(CityAddDto cityAddDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var city = await _cityService.AddAsync(_mapper.Map<City>(cityAddDto));
			var cityDto = _mapper.Map<CityAddDto>(cityAddDto);
			return Created(nameof(All), cityDto);
		}

		[HttpPut]
		public async Task<IActionResult> Update(City city)
		{
			await _cityService.UpdateAsync(city);
			return NoContent();
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCity(int id)
		{
			var city = await _cityService.GetByIdAsync(id);
			return Ok(city);

		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Remove(int id)
		{
			var city = await _cityService.GetByIdAsync(id);
			if (city == null)
			{
				return NotFound("Girilen id'ye ait şehir bulunamadı.");
			}
			await _cityService.RemoveAsync(city);
			return NoContent();
		}
	}
}
