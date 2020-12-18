using microserviceCim.Entity;
using microserviceCim.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace microserviceCim.Controllers
{
	[Route("[controller]")]
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
		public async Task<ActionResult<Cim>> Search(string id)
		{
			var cim = await _repositoryCims.GetCim(id);

			if (cim == null)
			{
				return NotFound();
			}

			cim.numConsultes += 1;

			await _repositoryCims.Update(cim);

			return Ok(cim);
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

			return CreatedAtAction("Search", new { id = cim.id }, cim);
		}

		[HttpPost("modify")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status202Accepted)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult> Modify(Cim cimInput)
		{
			Cim cim = null;
			try
			{
				cim = await _repositoryCims.Update(cimInput);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}

			if (cimInput.idRefugi != null)
			{
				SendMessageToMicroServeiRefugis("addCim", cimInput.idRefugi, cimInput.id);
			}


			return CreatedAtAction("Search", new { id = cimInput.id }, cim);
		}

		[HttpPost("delete")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status202Accepted)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult> Delete(Cim cimInput)
		{
			Cim cim = null;
			try
			{
				cim = await _repositoryCims.Delete(cimInput);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}

			return CreatedAtAction("Search", new { id = cimInput.id }, cim);
		}

		[HttpGet("top10")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<Cim>> Top10()
		{
			var cim = await _repositoryCims.Top10();

			if (cim == null)
			{
				return NotFound();
			}
			return Ok(cim);
		}

		private void SendMessageToMicroServeiRefugis(String Operacio, String idRefugi, String idRuta)
		{
			var factory = new ConnectionFactory() { HostName = "localhost" };
			using (var connection = factory.CreateConnection())
			{
				using (var channel = connection.CreateModel())
				{
					String cola = "MicroserveiRefugis";
					channel.QueueDeclare(cola, false, false, false, null);
					String message = string.Format("{0};{1};{2}", Operacio, idRefugi, idRuta);

					var body = Encoding.UTF8.GetBytes(message);

					channel.BasicPublish("", cola, null, body);
				}
			}
		}
	}
}
