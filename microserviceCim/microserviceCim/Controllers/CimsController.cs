using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microserviceCim.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CimsController : ControllerBase
	{
		// GET: api/<CimsController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<CimsController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<CimsController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<CimsController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<CimsController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
