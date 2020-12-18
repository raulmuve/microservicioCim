using microserviceCim.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microserviceCim.Models
{
	public interface IRepositoryCims
	{
		Task Add(Cim cim);

		Task<Cim> Update(Cim cim);

		Task<Cim> Delete(Cim cim);

		Task<Cim> GetCim(string id);

		Task<List<Cim>> GetCims();

		Task<List<Cim>> Top10();

		void addRuta(Cim cim);

		void deleteRuta(Cim cim);

		void addRefugis(Cim cim);

		void deleteRefugis(Cim cim);
		
	}
}
