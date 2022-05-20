using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
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
        public void Send(IConfiguration _configuration , string message)
        {
            _connection =  GetConnectionFactory(_configuration).CreateConnection();
            
            using (var channel = _connection.CreateModel())
            {
                Queue(channel);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "BankTransfer",
                                     basicProperties: null,
                                     body: body);

            }
            _connection.Dispose();
        }

        public string Read(IConfiguration _configuration) 
        {
            _connection = GetConnectionFactory(_configuration).CreateConnection();
            using (var channel = _connection.CreateModel()) 
            {
                Queue(channel);
                
               var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                 {
                     var body = ea.Body.ToArray();
                     var message = Encoding.UTF8.GetString(body);

                 };

                var responser = channel.BasicConsume(queue: "BankTransfer",
                                     autoAck: true,
                                     consumer: consumer
                                    );
                _connection.Dispose();
                return responser;
            }
        }
        public void Queue(IModel channel)
        {
            channel.QueueDeclare(queue: "BankTransfer",
                      durable: false,
                      exclusive: false,
                      autoDelete: false,
                      arguments: null
                    );
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
