namespace CommandsAPI.RabbitMQ
{
    public interface IEventProcessor
    {
        void AddPlatform(PlatformPublishDTO pm);
    }
}