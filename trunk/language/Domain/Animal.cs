namespace Domain
{
    public abstract class Animal
    {
        public string Name { get; set; }
    }

    public class Cat : Animal
    {
        public int Age { get; set; }
    }

    public class Dog : Animal
    {
        public int NumberOfPostmenBitten { get; set; }
    }

    public class Dragon : Animal
    {
        public int Damage { get; set; }
        public int Defense { get; set; }
    }
}