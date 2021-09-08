using System;

namespace CreateStruct.Pyrshiev
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("Fedor", "Pyrshiev", 19, Person.Genders.Male);
            Console.WriteLine(p.ToString());

            Manager m = new Manager("Fedor", "Pyrshiev", 19, Manager.Genders.Male, "8(800)535-35-35", "123b");
            Console.WriteLine(m);
        }

        class Person
        {
            public string firstName;
            public string lastName;
            public int age;
            public Genders gender;

            public Person(string _firstName, string _lastName, int _age, Genders _gender)
            {
                firstName = _firstName;
                lastName = _lastName;
                age = _age;
                gender = _gender;
            }

            public override string ToString()
            {
                return firstName + " " + lastName + " (" + gender + "), age " + age;
            }

            public enum Genders : int { Male, Female };
        }
        class Manager : Person
        {
            string phoneNumber;
            string officeLocation;

            public Manager(string _firstName, string _lastName, int _age, Genders _gender, string _phoneNumber, string _officeLocation)
                : base(_firstName, _lastName, _age, _gender)
            {
                phoneNumber = _phoneNumber;
                officeLocation = _officeLocation;
            }

            public override string ToString()
            {
                return base.ToString() + ", " + phoneNumber + ", " + officeLocation;
            }
        }
    }
}