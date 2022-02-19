using CommandsAPI.Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace CommandsAPI.RabbitMQ
{
    public class EventSubscriber : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private string _queueName;
        private IEventProcessor _processor;

        public EventSubscriber(IConfiguration config, IEventProcessor processor, BrokerPolicy policy)
        {
            _processor = processor;

            var factory = new ConnectionFactory()
            {
                HostName = config["Rabbit:Host"],
                Port = int.Parse(config["Rabbit:Port"])
            };
            try
            {
                policy.BrokerUnreachableFixedDelay.Execute(() =>
                {
                    Console.WriteLine("RETRIED");
                    _connection = factory.CreateConnection();
                    _channel = _connection.CreateModel();
                    _channel.ExchangeDeclare("my_exchange", ExchangeType.Fanout);

                    _queueName = _channel.QueueDeclare().QueueName;
                    _channel.QueueBind(_queueName, "my_exchange", "", null);
                });
            }
            catch (Exception ex)
            {
                // retry
            }
        }


        private void _consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            string serialized = Encoding.UTF8.GetString(e.Body.ToArray());
            PlatformPublishDTO dto = JsonSerializer.Deserialize<PlatformPublishDTO>(serialized);
            _processor.AddPlatform(dto);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var _consumer = new EventingBasicConsumer(_channel);
            _consumer.Received += _consumer_Received;
            _channel.BasicConsume(_queueName, true, _consumer);
            return Task.CompletedTask;
        }
    }
}
