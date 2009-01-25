using Sim_U_Duck.Ducks;

namespace Sim_U_Duck
{
    public class DuckTest
    {
        public static void Main(string[] args)
        {
            Duck mallard = new MallardDuck();
            Duck redhead = new RedHeadDuck();

            mallard.Quack();
            redhead.Quack();
        }
    }
}