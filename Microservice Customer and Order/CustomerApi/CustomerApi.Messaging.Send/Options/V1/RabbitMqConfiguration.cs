﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApi.Messaging.Send.Options.V1
{
    public class RabbitMqConfiguration
    {
        public string HostName { get; set; }
        public string QueueName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
