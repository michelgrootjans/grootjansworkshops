namespace WarOfWorldcraft.Web.Models
{
    public class AuthenticateDto
    {
        public string User { get; set; }
        public string Pwd { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}