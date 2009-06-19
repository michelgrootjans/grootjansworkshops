namespace Utilities.Mapping
{
    public interface IMapper<From, To>
    {
        To Map(From from);
    }
}