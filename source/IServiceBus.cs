using System;

namespace LiteServer
{
    public interface IServiceBus<T> : IDisposable where T : BaseCommand
    {
        void Publish(T message);
        void Subscribe(Action<T> actionToBePerformed);
    }
}