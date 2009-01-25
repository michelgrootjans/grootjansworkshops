using System;

namespace Sim_U_Duck.Ducks
{
    public abstract class Duck
    {
        public void Quack()
        {
            Console.WriteLine(string.Format("{0} quacks.", GetType().Name));
        }
    }
}