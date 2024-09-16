using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }

        public Person(int id, string name, int age, int salary)
        {
            Id = id;
            Name = name;
            Age = age;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{Id};{Name};{Age};{Salary}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("tulajdonsagok_100sor.txt");
            List<Person> people = new List<Person>();

            foreach (string line in lines)
            {
                
                string[] parts = line.Split(';');
                if (parts.Length == 4)
                {
                    int id = int.Parse(parts[0]);
                    string name = parts[1];
                    int age = int.Parse(parts[2]);
                    int salary = int.Parse(parts[3]);

                    
                    Person person = new Person(id, name, age, salary);
                    people.Add(person);
                }
            }

            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }

        }
    }
}
