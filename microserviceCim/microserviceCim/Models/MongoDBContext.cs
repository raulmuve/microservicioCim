﻿
using MongoDB.Driver;

namespace microserviceCim.Models
{
	public class MongoDBContext
	{
		//Definicio constants
		private const string ConnectionString = "mongodb://localhost:27017/";
		private const string Database = "serveiCims";
		private const string ColeccioCims = "Cims";
		
		private readonly IMongoDatabase _mongoDB;

		public MongoDBContext()
		{
			var client = new MongoClient(ConnectionString);
			_mongoDB = client.GetDatabase(Database);
		}

		public IMongoCollection<Cim> Cims
		{
			get
			{
				return _mongoDB.GetCollection<Cim>(ColeccioCims);
			}
		}
	}
}
