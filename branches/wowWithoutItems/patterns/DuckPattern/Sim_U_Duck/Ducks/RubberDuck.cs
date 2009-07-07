using System;

namespace Sim_U_Duck.Ducks
{
    public class RubberDuck : Duck
    {
        public override void Display()
        {
            Console.WriteLine("Hi there! I'm a rubber duck.");
        }

        public override void Quack( )
        {
            Console.WriteLine("Squeak");
        }
    }
}