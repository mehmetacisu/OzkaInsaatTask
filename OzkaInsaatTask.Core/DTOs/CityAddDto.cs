using System.ComponentModel.DataAnnotations;

namespace OzkaInsaatTask.Core.DTOs
{
	public class CityAddDto
	{
		[Required(ErrorMessage ="Lütfen Şehir Adını Giriniz!")]
		public string CityName { get; set; }
		[Required(ErrorMessage = "Lütfen Ülke Adını Giriniz!")]
		public string CountryName { get; set; }
	}
}
