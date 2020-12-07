using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microserviceCim.Models
{
	public interface IRepositoryCims
	{
		Task Add(Cim cim);

		Task Update(Cim cim);

		Task Delete(string id);

		Task<Cim> GetCim(string id);

		Task<List<Cim>> GetCims();
	}
}
