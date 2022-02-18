namespace PlatformsAPI.RabbitMQ
{
    public interface IEventPublisher
    {
        void SendMessage(string msg);
    }
}