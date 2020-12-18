using System.ComponentModel.DataAnnotations;

namespace microserviceCim.Models
{
	public class CimPostInputInformacioGeneral
	{
		[Required(AllowEmptyStrings = false)]
		public string Codi { get; set; }

		[Required(AllowEmptyStrings = false)]
		public string Municipi { get; set; }

		[Required(AllowEmptyStrings = false)]
		public string  Comarca { get; set; }
	}
}
