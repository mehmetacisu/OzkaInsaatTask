using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzkaInsaatTask.Core.Models;

namespace OzkaInsaatTask.Repository.Seeds
{
	internal class CitiesSeed : IEntityTypeConfiguration<City>
	{
		public void Configure(EntityTypeBuilder<City> builder)
		{
			builder.HasData(new City
			{
				Id = 1,
				CityName = "İstanbul",
				CountryName = "Türkiye"
			},
			new City
			{
				Id = 2,
				CityName = "Ankara",
				CountryName = "Türkiye"
			}, new City
			{
				Id = 3,
				CityName = "İzmir",
				CountryName = "Türkiye"
			},
			new City
			{
				Id = 4,
				CityName = "Bursa",
				CountryName = "Türkiye"
			}, new City
			{
				Id = 5,
				CityName = "Düzce",
				CountryName = "Türkiye"
			});
		}
	}
}
