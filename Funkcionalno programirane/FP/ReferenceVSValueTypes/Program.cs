using System;
using System.Collections.Generic;
using System.Linq;

namespace ReferenceVSValueTypes
{
    internal class Program
    {
        static void Main()
        {
            #region ValueTypeDemo
            char a = '5';
            char b = a;
            b = 'Q';
            Console.WriteLine(a); //5
            Console.WriteLine(b); //Q
            DrawDelimiter();
            #endregion
            #region ReferenceTypeDemo0
            Person c = new Person("Maria", 20);
            Person d = c;
            c.Name = "Silvia";
            Console.WriteLine(c.Name); //Silvia
            Console.WriteLine(d.Name); //Silvia
            #endregion
            #region ReferenceTypeDemo1
            int[] m1 = new int[] { 1, 3, 5, 7, 9, 11, 13, 15 };
            int[] copy = m1;//Тук копирам горният масив и той е същия.

            copy[1] = 100;

            var num = copy[2];
            num = 100000;

            //Двата реда принтират еднакви елементи (елемент с индекс 1 е 100)
            //Защото copy и m1 имат една и съща референция но данните са само 1ни)
            Console.WriteLine(String.Join(", ", m1));
            Console.WriteLine(String.Join(", ", copy));

            DrawDelimiter();
            //ToАrray връща чисто нов масив с нова референция, и от тук нататък m1 и copy 
            //имат самостоятелно поведение при промяна.
            m1 = m1.ToArray();

            copy[1] = 300;
            Console.WriteLine(String.Join(", ", m1));
            Console.WriteLine(String.Join(", ", copy));
            DrawDelimiter();
            #endregion

            #region ReferenceTypeDemo2
            List<Person> people = new List<Person>()
            {
            new Person("Genadi",21),
            new Person("Krasimir",18),
            new Person("Djani",18),
            new Person("Neli",18),
            };

            Person copyP1 = people.First();
            Person lastP = people.Last();
            copyP1.Name = "Gosho";

            foreach (var person in people)
            {
                Console.WriteLine(person.Name);
            }
            DrawDelimiter();
            Console.WriteLine(GetInfoOfPerson(people.Last()));

            #endregion
        }

        private static string GetInfoOfPerson(Person person)
        {
            Person temporary =
                new Person(person.Name, person.Age);

            //Това Ще промени подаденият person.
            person.Name += 1;
            person.Age = 0;

            //Това няма да промени подаденият person.
            temporary.Name += 1;
            temporary.Age = 0;
            return $"I am {temporary.Name}!";
        }


        private static void DrawDelimiter()
        {
            Console.WriteLine(new String('=', 20));
        }

        public class Person
        {
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
