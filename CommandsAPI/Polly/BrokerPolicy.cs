using Polly;
using Polly.Retry;
using RabbitMQ.Client.Exceptions;

namespace CommandsAPI.Polly
{
    public class BrokerPolicy
    {
        public RetryPolicy BrokerUnreachableFixedDelay{ get; }

        public BrokerPolicy()
        {
            BrokerUnreachableFixedDelay = Policy.Handle<Exception>()
                .WaitAndRetry(5, retryNumber => TimeSpan.FromSeconds(1));
        }
    }
}
