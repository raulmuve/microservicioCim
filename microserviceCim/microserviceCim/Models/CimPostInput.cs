using System.ComponentModel.DataAnnotations;

namespace microserviceCim.Models
{
	public class CimPostInput
	{
		[Required(AllowEmptyStrings = false)]
		public string Nom { get; set; }

		[Required(AllowEmptyStrings = false)]
		public string Descripcio { get; set; }

		[Required(AllowEmptyStrings = false)]
		public CimPostInputInformacioGeneral InformacioGeneral { get; set; }

		[Required(AllowEmptyStrings = false)]
		public CimPostInputAltitud Altitud { get; set; }

		public string idRefugi { get; set; }

	}
}
