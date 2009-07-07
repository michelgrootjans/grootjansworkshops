namespace WarOfWorldcraft.Utilities.IoC
{
    public interface IContainer
    {
        T GetImplementationOf<T>();
    }
}