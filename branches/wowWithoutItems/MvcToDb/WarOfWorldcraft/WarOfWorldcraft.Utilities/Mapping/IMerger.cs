namespace WarOfWorldcraft.Utilities.Mapping
{
    public interface IMerger<From, To>
    {
        void Merge(From from, To to);
    }
}