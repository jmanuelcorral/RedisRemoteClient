using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace LiteServer
{
    public class BaseCommand
    {
        public string RemoteCommand { get; set; }
        public string RemoteOutput { get; set; }
       // public string CallbackUrl { get; set; }
       // public bool CanIDispach { get; set; }
    }

    public interface IServiceBus<T> : IDisposable where T : BaseCommand
    {
        void Publish(T message);
        void Subscribe(Action<T> actionToBePerformed);
    }

    public class ServiceBus<T> : IServiceBus<T> where T : BaseCommand
    {


        private readonly ServiceBusConfiguration _configuration;
        private readonly IConnectionMultiplexer _cnMultiplexer;
        private readonly ISubscriber _subscriber;

        public ServiceBus(ServiceBusConfiguration configuration)
        {
            _configuration = configuration;
            _cnMultiplexer = ConnectionMultiplexer.Connect($"{configuration.Host}:{configuration.Port}");
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

    public class ServiceBusConfiguration
    {
        public string ChannelName { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string ClientName { get; set; }

    }


  
    class Program
    {
        public static bool KeepRunning = true;
        static void Main(string[] args)
        {
            ServiceBusConfiguration config = new ServiceBusConfiguration()
            {
                Host = "localhost",
                Port = 6379,
                ChannelName = "Channel9"
            };
            if (args.Length > 0) {
                var parameters = args[0].Split(';');
                if (parameters.Length > 2)
                {
                    config = new ServiceBusConfiguration()
                    {
                        Host = parameters[0],
                        Port = Convert.ToInt32(parameters[1]),
                        ChannelName = parameters[2]
                    };
                }
                else
                {
                    Console.WriteLine("The ConnectionString must Be like:  server;port;channelname   example:  localhost;6379;Channel9");
                }
            }
            
            ServiceBus<BaseCommand> myRedisClient = new ServiceBus<BaseCommand>(config);
            Console.WriteLine("Miniremote Command App");
            myRedisClient.Subscribe(command =>
            {
                Console.WriteLine( $"Sended: {command.RemoteCommand} with result {command.RemoteOutput}");
            });
            while (KeepRunning)
            {
                Console.WriteLine("Hit a RemoteCommand (quit) to quit App: ");
                string command = Console.ReadLine();
                if (!command.ToLowerInvariant().Contains("quit"))
                    myRedisClient.Publish(new BaseCommand() { RemoteCommand = command });
                else
                    KeepRunning = false;
            }
        }
    }
}