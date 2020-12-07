using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microserviceCim.Models
{
	public class RepositoryCims : IRepositoryCims
	{
		MongoDBContext db = new MongoDBContext();

		public async Task Add(Cim cim)
		{
			try
			{
				await db.Cims.InsertOneAsync(cim);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async  Task Delete(string id)
		{
			try
			{
				FilterDefinition<Cim> cim = Builders<Cim>.Filter.Eq("Id", id);
				await db.Cims.DeleteOneAsync(cim);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public Task<Cim> GetCim(string id)
		{
			try
			{
				FilterDefinition<Cim> cim = Builders<Cim>.Filter.Eq("Id", id);
				return db.Cims.Find(cim).FirstOrDefaultAsync();
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<List<Cim>> GetCims()
		{
			try
			{
				return await db.Cims.Find(_ => true).ToListAsync();
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task Update(Cim cim)
		{
			try
			{
				await db.Cims.ReplaceOneAsync(filter: g => g.id == cim.id, replacement: cim);
			}
			catch (Exception)
			{

				throw;
			}
			
		}
	}
}
