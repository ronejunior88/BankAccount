using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Infrastructure.Data.Command.Context.Queues.v1
{
    public class RabbitMqConfiguration
    {
        public string Host { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public int Port { get; private set; }
        public ushort RequestHeartBeatInSeconds { get; private set; }
        public string VirtualHost { get; private set; }
        public string Exchange { get; private set; }
        public string Queue { get; private set; }

        public RabbitMqConfiguration(IConfiguration _configuration)
        {
             
            Host = _configuration.GetSection("RabbitMqJsonConfiguration").GetSection("Host").Value;
            UserName = _configuration.GetSection("RabbitMqJsonConfiguration").GetSection("UserName").Value;
            Password = _configuration.GetSection("RabbitMqJsonConfiguration").GetSection("Password").Value;
            Port = Convert.ToInt32(_configuration.GetSection("RabbitMqJsonConfiguration").GetSection("Port").Value);
            RequestHeartBeatInSeconds = Convert.ToUInt16(_configuration.GetSection("RabbitMqJsonConfiguration").GetSection("RequestHeartBeatInSeconds").Value);
            VirtualHost = _configuration.GetSection("RabbitMqJsonConfiguration").GetSection("VirtualHost").Value;
            Exchange = _configuration.GetSection("RabbitMqJsonConfiguration").GetSection("Exchange").Value;
            Queue = _configuration.GetSection("RabbitMqJsonConfiguration").GetSection("Queue").Value;
        }
    }
}
