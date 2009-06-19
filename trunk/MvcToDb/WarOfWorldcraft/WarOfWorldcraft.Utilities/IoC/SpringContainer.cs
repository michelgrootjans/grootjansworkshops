using System;
using Spring.Context;

namespace WarOfWorldcraft.Utilities.IoC
{
    public class SpringContainer : IContainer
    {
        private readonly IApplicationContext applicationContext;

        public SpringContainer(IApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public T GetImplementationOf<T>()
        {
            // try to find it by type
            var registeredObjects = applicationContext.GetObjectsOfType(typeof (T));
            if (registeredObjects.Count == 0)
            {
                // try to get if from XMLApplicationContext
                registeredObjects = applicationContext.ParentContext.GetObjectsOfType(typeof (T));
            }

            // evaluate what we found
            if (registeredObjects.Count > 1)
            {
                throw new ArgumentException(string.Format("More then one implementation of {0}",
                                                                       typeof (T).Name));
            }

            if (registeredObjects.Count == 0)
            {
                throw new ArgumentException(string.Format("No implementation of {0}", typeof(T).Name));
            }

            // take first element
            var implementation = default(T);
            foreach (var entry in registeredObjects.Values)
            {
                implementation = (T) entry;
                break;
            }
            return implementation;
        }
    }
}