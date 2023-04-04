using AutoMapper;
using OzkaInsaatTask.Core.DTOs;
using OzkaInsaatTask.Core.Models;

namespace OzkaInsaatTask.Service.Mapping
{
	public class AutoMapperConfig : Profile
	{
		public AutoMapperConfig()
		{
			CreateMap<City, CityAddDto>().ReverseMap();
		}
	}
}
