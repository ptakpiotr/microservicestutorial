using RabbitMQ.Client;
using System.Text;

namespace PlatformsAPI.RabbitMQ
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public EventPublisher(IConfiguration config)
        {
            var factory = new ConnectionFactory()
            {
                HostName = config["Rabbit:Host"],
                Port = int.Parse(config["Rabbit:Port"])
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare("my_exchange", ExchangeType.Fanout);
        }

        public void SendMessage(string msg)
        {
            byte[] byteArr = Encoding.UTF8.GetBytes(msg);

            _channel.BasicPublish("my_exchange", "", null, byteArr);
        }
    }
}
