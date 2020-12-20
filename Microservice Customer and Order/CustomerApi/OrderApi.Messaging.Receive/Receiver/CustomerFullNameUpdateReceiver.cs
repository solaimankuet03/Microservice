using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using OrderApi.Service.V1.Services;
using OrderApi.Messaging.Receive.Options.V1;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using OrderApi.Service.V1.Models;

namespace OrderApi.Messaging.Receive.Receiver
{
    public class CustomerFullNameUpdateReceiver : BackgroundService
    {
        private IModel _channel;
        private IConnection _connection;

        private readonly ICustomerNameUpdateService customerNameUpdateService;
        private readonly string _hostname;
        private readonly string _queueName;
        private readonly string _username;
        private readonly string _password;

        public CustomerFullNameUpdateReceiver(ICustomerNameUpdateService customerNameUpdateService, IOptions<RabbitMqConfiguration> options)
        {
            this.customerNameUpdateService = customerNameUpdateService;
            this._hostname = options.Value.HostName;
            this._queueName = options.Value.QueueName;
            this._username = options.Value.UserName;
            this._password = options.Value.Password;

            InitializeRabbitMqConfiguration();
        }

        private void InitializeRabbitMqConfiguration()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostname, UserName = _username, Password = _password
            };

            _connection = factory.CreateConnection();
            _connection.ConnectionShutdown += _connection_ConnectionShutdown;

            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        private void _connection_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += Consumer_Received;

            consumer.Shutdown += OnConsumerShutdown;
            consumer.Registered += OnConsumerRegistered;
            consumer.Unregistered += OnConsumerUnregistered;
            consumer.ConsumerCancelled += OnConsumerConsumerCancelled;

            _channel.BasicConsume(_queueName, false, consumer);

            return Task.CompletedTask;
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var content = Encoding.UTF8.GetString(e.Body.ToArray());
            var updateCustomerFullNameModel = JsonConvert.DeserializeObject<UpdateCustomerFullNameModel>(content);

            HandleMessage(updateCustomerFullNameModel);

            _channel.BasicAck(e.DeliveryTag, false);
        }

        private void HandleMessage(UpdateCustomerFullNameModel updateCustomerFullNameModel)
        {
            customerNameUpdateService.UpdateCustomerNameInOrders(updateCustomerFullNameModel);
        }

        private void OnConsumerConsumerCancelled(object sender, ConsumerEventArgs e)
        {
            
        }

        private void OnConsumerUnregistered(object sender, ConsumerEventArgs e)
        {
            
        }

        private void OnConsumerRegistered(object sender, ConsumerEventArgs e)
        {
            
        }

        private void OnConsumerShutdown(object sender, ShutdownEventArgs e)
        {
            
        }        

        public override void Dispose()
        {
            _channel.Dispose();
            _connection.Dispose();

            base.Dispose();
        }
    }
}
