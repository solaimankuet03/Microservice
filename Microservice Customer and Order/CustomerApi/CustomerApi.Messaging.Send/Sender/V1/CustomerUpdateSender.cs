using CustomerApi.Domain.Entities;
using CustomerApi.Messaging.Send.Options.V1;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApi.Messaging.Send.Sender.V1
{
    public class CustomerUpdateSender : ICustomerUpdateSender
    {
        private string _hostname { get; set; }
        private string _queuename { get; set; }
        private string _username { get; set; }
        private string _password { get; set; }
        private IConnection connection { get; set; }

        public CustomerUpdateSender(IOptions<RabbitMqConfiguration> options)
        {
            _hostname = options.Value.HostName;
            _queuename = options.Value.QueueName;
            _username = options.Value.UserName;
            _password = options.Value.Password;

            CreateConnection();
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = _hostname,
                    UserName = _username,
                    Password = _password
                };

                connection = factory.CreateConnection();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Could not create connection: {ex.Message}");
            }
        }

        private bool ConnectionExists()
        {
            if(connection != null)
            {
                return true;
            }

            CreateConnection();

            return connection != null;
        }

        public void SendCustomer(Customer customer)
        {
            if (ConnectionExists())
            {
                using(var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: _queuename, durable: false, exclusive: false, autoDelete: false, arguments: null);
                    var json = JsonConvert.SerializeObject(customer);
                    var body = Encoding.UTF8.GetBytes(json);
                    channel.BasicPublish(exchange: "", routingKey: _queuename, basicProperties: null, body: body);
                }
            }
        }
    }
}
