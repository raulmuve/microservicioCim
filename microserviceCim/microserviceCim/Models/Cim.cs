﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace microserviceCim.Models{

	public class Cim
	{
		[BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
		public ObjectId id { get; set; }

		[BsonElement("Id_Cim")]
		public int id_Cim { get; set; }

		[BsonElement("Nom")]
		public string nom { get; set; }

		[BsonElement("Descripcio")]
		public string descripcio { get; set; }

		[BsonElement("InformacioGeneral")]
		public CimInformacioGeneral informacioGeneral { get; set; }

		[BsonElement("Altitud")]
		public CimAltitud altitud { get; set; }

		[BsonElement("Actiu")]
		public bool actiu { get; set; }

		[BsonElement("DataCreacio")]
		public DateTime dataCreacio { get; set; }

		[BsonElement("DataModificacio")]
		public DateTime dataModificacio { get; set; }

		[BsonElement("NumRefugis")]
		public int numRefugis { get; set; }

		[BsonElement("NumRutes")]
		public int numRutes { get; set; }

		[BsonElement("NumeroConsultes")]
		public int numeroConsultes { get; set; }

	}

}