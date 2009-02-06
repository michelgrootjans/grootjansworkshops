using System;

namespace Domain
{
    public class Employee : Person
    {
        public Employee(string name, DateTime dateOfBirth) : base(name, dateOfBirth)
        {
        }

        public Employee(string name, DateTime dateOfBirth, DateTime? dateOfDeath) : base(name, dateOfBirth, dateOfDeath)
        {
        }
    }
}