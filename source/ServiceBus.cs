using System;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace LiteServer
{
    public class ServiceBus<T> : IServiceBus<T> where T : BaseCommand
    {


        private readonly ServiceBusConfiguration _configuration;
        private readonly IConnectionMultiplexer _cnMultiplexer;
        private readonly ISubscriber _subscriber;

        public ServiceBus(ServiceBusConfiguration configuration)
        {
            _configuration = configuration;
            var options = ConfigurationOptions.Parse($"{configuration.Host}:{configuration.Port}");
            options.SyncTimeout = 5000;
            options.AbortOnConnectFail = false;
            _cnMultiplexer = ConnectionMultiplexer.Connect(options);
            _cnMultiplexer.PreserveAsyncOrder = false;
            _subscriber = _cnMultiplexer.GetSubscriber();
        }

        public void Publish(T message)
        {
            Console.WriteLine($"publish Action Launch, message: {JsonConvert.SerializeObject(message)}");
            _subscriber.Publish(_configuration.ChannelName, JsonConvert.SerializeObject(message));
            
        }

        public void Subscribe(Action<T> actionToBePerformed)
        {
            _subscriber.Subscribe(_configuration.ChannelName, (channel, message) => {
                Console.WriteLine($"subscribe Action Launch, message: {message}");
                actionToBePerformed.Invoke(JsonConvert.DeserializeObject<T>(message));
            });
        }

        public void Dispose()
        {
            _cnMultiplexer.Dispose();

        }
    }
}