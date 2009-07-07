using System.Threading;
using WarOfWorldcraft.Domain.Services;

namespace WarOfWorldcraft.Web.Services
{
    public class HardcodedMembershipService : IMembershipService
    {
        public bool ValidateUser(string userName, string password)
        {
            return true;
        }

        public string CurrentAccount
        {
            get { return Thread.CurrentPrincipal.Identity.Name; }
        }
    }
}