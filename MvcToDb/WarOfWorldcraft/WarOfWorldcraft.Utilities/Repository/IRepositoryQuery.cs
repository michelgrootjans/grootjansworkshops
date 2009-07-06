namespace WarOfWorldcraft.Utilities.Repository
{
    public interface IRepositoryQuery<T>
    {
        string QueryString { get; }
    }
}