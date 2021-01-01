using microserviceCim.Entity;
using microserviceCim.Models;
using Microsoft.AspNetCore.Components;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace microserviceCim.Rabbit
{
	public class Consumer
	{
		public void ConsumerStart()
		{
			Boolean connected = false;
			String cola = "MicroserveiCims";
			var factory = new ConnectionFactory() { HostName = "localhost" };

			RepositoryCims repo = new RepositoryCims();
			while (!connected)
			{
				try
				{
					using (var connection = factory.CreateConnection())
					{
						connected = true;
						if (connected)
						{
							Console.WriteLine("Rabbit Connected");
							connected = true;
						}
						using (var channel = connection.CreateModel())
						{
							channel.QueueDeclare(cola, false, false, false, null);

							var consumer = new EventingBasicConsumer(channel);

							consumer.Received += async (model, ea) =>
							{
								var message = Encoding.UTF8.GetString(ea.Body.ToArray());

								RepositoryCims repo = new RepositoryCims();

								string idCim = message.Split(";")[1];

								Cim cim = await repo.GetCim(idCim);

								switch (message.Split(";")[0])
								{
									case "addRuta":
										repo.addRuta(cim);
										break;
									case "deleteRuta":
										repo.deleteRuta(cim);
										break;
									case "addRefugi":
										repo.addRefugis(cim);
										break;
									case "deleteRefugi":
										repo.deleteRefugis(cim);
										break;
								}
							};

							channel.BasicConsume(queue: cola, autoAck: true, consumer: consumer);

							while (true) { }
						}
					}
				}
				catch (Exception)
				{
					Console.WriteLine("Rabbit Not connected");
					System.Threading.Thread.Sleep(10000);

				}
			}
		}
	}
}
