using WarOfWorldcraft.Utilities.IoC;

namespace WarOfWorldcraft.Utilities.Mapping
{
    public static class Merge
    {
        public static Merger<From> This<From>(From from)
        {
            return new Merger<From>(from);
        }
    }

    public class Merger<From>
    {
        private readonly From from;

        public Merger(From from)
        {
            this.from = from;
        }

        public void Into<To>(To to)
        {
            var merger = Container.GetImplementationOf<IMerger<From, To>>();
            merger.Merge(from, to);
        }
    }
}