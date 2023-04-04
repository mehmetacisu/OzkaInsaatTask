using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzkaInsaatTask.Core.Models;

namespace OzkaInsaatTask.Repository.Configurations
{
	internal class CityConfiguration : IEntityTypeConfiguration<City>
	{
		public void Configure(EntityTypeBuilder<City> builder)
		{
			builder.Property(x => x.CityName).IsRequired().HasMaxLength(200);
			builder.Property(x => x.CountryName).IsRequired().HasMaxLength(75);
			builder.ToTable("City");
		}
	}
}
