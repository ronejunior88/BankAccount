using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Command.Context.Rabbit.v1
{
    public class TransferQueues
    {
        
        private static IConnection _connection { get; set; }
        public TransferQueues()
        { }
        public void OpenConnection(IConfiguration _configuration , string message)
        {
            _connection =  GetConnectionFactory(_configuration).CreateConnection();
            
            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: "BankTransfer",
                      durable: false,
                      exclusive: false,
                      autoDelete: false,
                      arguments: null
                    );
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "BankTransfer",
                                     basicProperties: null,
                                     body: body);

            }
            _connection.Dispose();
        }
        private ConnectionFactory GetConnectionFactory(IConfiguration _configuration)
        {
            var _rabbitMqConfiguration = new RabbitMqConfiguration(_configuration);
            return new ConnectionFactory()
            {
                HostName = _rabbitMqConfiguration.Host,
                UserName = _rabbitMqConfiguration.UserName,
                Password = _rabbitMqConfiguration.Password,
                RequestedHeartbeat = TimeSpan.FromSeconds(_rabbitMqConfiguration.RequestHeartBeatInSeconds),
                VirtualHost = _rabbitMqConfiguration.VirtualHost,
                Port = _rabbitMqConfiguration.Port
            };
        }
    }
}
