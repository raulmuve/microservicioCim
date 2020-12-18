using MongoDB.Bson.Serialization.Attributes;

namespace microserviceCim.Entity
{
	public class CimInformacioGeneral
	{
		[BsonElement ("Codi")]
		public int codi { get; set; }

		[BsonElement("Municipi")]
		public string municipi { get; set; }

		[BsonElement("Comarca")]
		public string comarca { get; set; }
	}
}
