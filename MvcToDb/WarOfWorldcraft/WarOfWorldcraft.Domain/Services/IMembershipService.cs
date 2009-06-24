namespace WarOfWorldcraft.Domain.Services
{
    public interface IMembershipService
    {
        bool ValidateUser(string userName, string password);
        string CurrentAccount { get; }
    }
}