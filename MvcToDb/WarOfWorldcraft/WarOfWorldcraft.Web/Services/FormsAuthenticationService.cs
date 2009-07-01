using System.Web.Security;
using WarOfWorldcraft.Domain.Services;

namespace WarOfWorldcraft.Web.Services
{
    public class FormsAuthenticationService : IAuthenticationService
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}