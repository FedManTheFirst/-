using System;

namespace CreateStruct.Pyrshiev
{
    class Program
    {
        static void Main()
        {
            Person p = new Person("Fedor", "Pyrshiev", 19);
            Console.WriteLine(p);
        }
        struct Person
        {
            public string firstName;
            public string lastName;
            public int age;
            public Person(string _firstName, string _lastName, int _age)
            {
                firstName = _firstName;
                lastName = _lastName;
                age = _age;
            }
            public override string ToString()
            {
                return firstName + " " + lastName + ", age " + age;
            }

        }
    }
}