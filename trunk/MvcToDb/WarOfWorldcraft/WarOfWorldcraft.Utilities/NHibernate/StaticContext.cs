using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;

namespace WarOfWorldcraft.Utilities.NHibernate
{
    public class StaticContext : IContext
    {
        private readonly IDictionary items;

        public StaticContext()
        {
            items = new Dictionary<object, object>();
        }

        public IDictionary Items
        {
            get { return items; }
        }

        public IPrincipal Principal
        {
            get { return Thread.CurrentPrincipal; }
        }
    }
}