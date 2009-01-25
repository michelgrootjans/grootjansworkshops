using System;

namespace Sim_U_Duck.Ducks
{
    public abstract class Duck
    {
        protected Duck()
        {
            Console.WriteLine(string.Format("You see a {0}.", GetType().Name));
        }

        public void Quack()
        {
            Console.WriteLine(string.Format("The {0} quacks.", GetType().Name));
        }
    }
}