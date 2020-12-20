using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApi.Messaging.Receive.Options.V1
{
    public class RabbitMqConfiguration
    {
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string QueueName { get; set; }
        public bool Enabled { get; set; }
    }
}
