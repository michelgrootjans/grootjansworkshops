using System;

namespace Domain
{
    public class Person
    {
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public DateTime? DateOfDeath { get; private set; }

        public Person(string name, DateTime dateOfBirth) : this(name, dateOfBirth, null)
        {
        }

        public Person(string name, DateTime dateOfBirth, DateTime? dateOfDeath)
        {
            DateOfBirth = dateOfBirth;
            DateOfDeath = dateOfDeath;
            Name = name;
        }

        public TimeSpan Age
        {
            get
            {
                TimeSpan age;
                if (DateOfDeath.HasValue)
                    age = DateOfDeath.Value - DateOfBirth;
                else
                    age = DateTime.Now - DateOfBirth;

                return age;
            }
        }
    }
}