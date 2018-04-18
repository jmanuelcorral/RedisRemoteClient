using System;
using System.Threading.Tasks;

namespace LiteServer
{
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