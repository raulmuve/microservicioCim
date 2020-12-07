using microserviceCim.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace microserviceCim.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CimsController : ControllerBase
	{
		private readonly IRepositoryCims _repositoryCims;

		public CimsController(IRepositoryCims repositoryCims)
		{
			_repositoryCims = repositoryCims;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<IEnumerable<Cim>>> GetCims()
		{
			var lista = await _repositoryCims.GetCims();

			if (lista == null)
			{
				return NotFound();
			}
			return Ok(lista);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<Cim>> GetCim(string id)
		{
			var libro = await _repositoryCims.GetCim(id);

			if (libro == null)
			{
				return NotFound();
			}
			return Ok(libro);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<ActionResult> PostCim(Cim cim)
		{
			try
			{
				await _repositoryCims.Add(cim);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}

			return CreatedAtAction("GetCim", new { id = cim.id }, cim);
		}
	}
}
