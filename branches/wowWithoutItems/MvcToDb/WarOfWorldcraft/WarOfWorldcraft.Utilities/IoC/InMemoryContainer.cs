using System;
using System.Collections.Generic;

namespace WarOfWorldcraft.Utilities.IoC
{
    public class InMemoryContainer : IContainer
    {
        private readonly Dictionary<Type, object> components;

        public InMemoryContainer(Dictionary<Type, object> implementations)
        {
            components = implementations;
        }

        public void Register<T>(T t)
        {
            components.Add(typeof(T), t);
        }

        public T GetImplementationOf<T>()
        {
            if (components.ContainsKey(typeof (T)))
                return (T) components[typeof (T)];

            //Component not found
            foreach (var implementation in components.Values)
            {
                if (typeof(T).IsAssignableFrom(implementation.GetType()))
                    return (T) implementation;
            }

            throw new ArgumentException(string.Format("Couldn't find an implementation of {0} in the container.", typeof(T)));
        }
    }
}