/*
 * Created by: 
 * Created: zaterdag 24 januari 2009
 */

namespace CommonLibrary
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}