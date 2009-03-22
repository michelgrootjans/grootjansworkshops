using System;

namespace Sim_U_Duck.Ducks
{
    public abstract class Duck
    {
        public abstract void Display();

        public virtual void Quack()
        {
            Console.WriteLine("Quack!");
        }
    }
}