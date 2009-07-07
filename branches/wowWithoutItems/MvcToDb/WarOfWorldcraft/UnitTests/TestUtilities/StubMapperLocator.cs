using System;
using System.Collections.Generic;
using Utilities.Mapping;
using WarOfWorldcraft.Utilities.Mapping;

namespace UnitTests.TestUtilities
{
    internal class StubMapperLocator : IMapperLocator
    {
        private readonly IList<object> mappers;

        public StubMapperLocator(IList<object> mappers)
        {
            this.mappers = mappers;
        }

        public IMapper<From, To> GetMapperFor<From, To>()
        {
            foreach (var mapper in mappers)
            {
                if (typeof (IMapper<From, To>).IsAssignableFrom(mapper.GetType()))
                    return (IMapper<From, To>) mapper;
            }
            throw new ArgumentException(string.Format("Could't find a mapper from {0} to {1}", typeof (From),
                                                      typeof (To)));
        }
    }
}