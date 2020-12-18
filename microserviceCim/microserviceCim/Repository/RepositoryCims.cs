using microserviceCim.Entity;
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
				cim.dataCreacio = DateTime.Now;
				cim.dataModificacio = DateTime.Now;
				cim.actiu = true;
				await db.Cims.InsertOneAsync(cim);
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
				FilterDefinition<Cim> cim = Builders<Cim>.Filter.Eq("id", id);
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
				var sortDefinition = Builders<Cim>.Sort.Ascending(a => a.nom);
				return await db.Cims.Find(a => a.actiu == true).Sort(sortDefinition).ToListAsync();

			}
			catch (Exception)
			{

				throw;
			}
		}


		public async Task<Cim> Update(Cim cimInput)
		{
			try
			{
				cimInput.dataModificacio = DateTime.Now;
				cimInput.actiu = true;
				await db.Cims.ReplaceOneAsync(filter: g => g.id == cimInput.id, replacement: cimInput);
			}
			catch (Exception)
			{

				throw;
			}

			return cimInput;
		}

		public async Task<Cim> Delete(Cim cimInput)
		{
			try
			{
				cimInput.dataModificacio = DateTime.Now;
				cimInput.actiu = false;
				await db.Cims.ReplaceOneAsync(filter: g => g.id == cimInput.id, replacement: cimInput);
			}
			catch (Exception)
			{

				throw;
			}

			return cimInput;
		}

		public async Task<List<Cim>> Top10()
		{
			try
			{
				var sortDefinition = Builders<Cim>.Sort.Descending(cim => cim.numConsultes);
				return await db.Cims.Find(cim => cim.actiu  == true).Sort(sortDefinition).Limit(10).ToListAsync();

			}
			catch (Exception)
			{

				throw;
			}
		}


		public async void addRuta(Cim cim)
		{
			cim.numRutes += 1;

			await Update(cim);
		}

		public async void deleteRuta(Cim cim)
		{
			cim.numRutes -= 1;
			await Update(cim);
		}

		public async void addRefugis(Cim cim)
		{
			cim.numRefugis += 1;
			await Update(cim);
		}

		public async void deleteRefugis(Cim cim)
		{
			cim.numRefugis -= 1;

			await Update(cim);
		}

	}
}
