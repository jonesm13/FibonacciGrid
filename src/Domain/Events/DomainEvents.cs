namespace Domain.Events
{
    using System;
    using System.Collections.Generic;

    public static class DomainEvents
    {
        static readonly Dictionary<Type, List<Delegate>> handlers;

        static DomainEvents()
        {
            handlers = new Dictionary<Type, List<Delegate>>();
        }

        public static void Register<T>(Action<T> handler)
        {
            if (!handlers.ContainsKey(typeof(T)))
            {
                handlers[typeof(T)] = new List<Delegate>();
            }

            handlers[typeof(T)].Add(handler);
        }

        public static void Raise<T>(T @event)
        {
            if (!handlers.ContainsKey(@event.GetType()))
            {
                return;
            }

            foreach (Delegate handler in handlers[@event.GetType()])
            {
                Action<T> action = (Action<T>) handler;
                action(@event);
            }
        }
    }
}