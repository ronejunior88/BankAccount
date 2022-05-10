using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Command.Context.Queues.v1
{
    public class TransferQueues
    {
        public TransferQueues()
        {}

        public void Connect(string message)
        {
            var connectRabbitMQ = new ConnectionFactory() { HostName = "localhost" };
            
            using(var connection = connectRabbitMQ.CreateConnection())
            {
                using (var channel = connection.CreateModel()) 
                {
                    channel.QueueDeclare(queue: "Tranfer",
                          durable: false,
                          exclusive: false,
                          autoDelete: false,
                          arguments: null                       
                        );
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "Tranfer",
                                         basicProperties: null,
                                         body: body);

                }
            }
        }
    }
}
