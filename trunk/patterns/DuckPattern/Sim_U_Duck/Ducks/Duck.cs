using System;

namespace Sim_U_Duck.Ducks
{
    public abstract class Duck
    {
        public virtual void Quack()
        {
            Console.WriteLine("Quack!");
        }

        public abstract void Display();
    }
}