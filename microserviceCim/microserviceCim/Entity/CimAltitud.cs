using MongoDB.Bson.Serialization.Attributes;
using System;

namespace microserviceCim.Entity
{
	public class CimAltitud
	{
		[BsonElement("Cota")]
		public string cota { get; set; }

		[BsonElement("X")]
		public string x { get; set; }

		[BsonElement("Y")]
		public string y { get; set; }

	}
	
}
