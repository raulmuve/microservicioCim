
using System.ComponentModel.DataAnnotations;

namespace microserviceCim.Models
{
	public class CimPostInputAltitud
	{
		[Required(AllowEmptyStrings = false)]
		public string Cota { get; set; }

		[Required(AllowEmptyStrings = false)]
		public string X { get; set; }

		[Required(AllowEmptyStrings = false)]
		public string Y { get; set; }
	}
}
