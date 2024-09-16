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

            PrintHighestEarners(people);
            PrintRetirementSoon(people);
            CountHighEarners(people);
            Console.ReadKey();
        }
        static void PrintHighestEarners(List<Person> people)
        {
            int maxSalary = people.Max(p => p.Salary);
            var highestEarners = people.Where(p => p.Salary == maxSalary);

            Console.WriteLine("Legjobban kereső dolgozó:");
            foreach (var person in highestEarners)
            {
                Console.WriteLine($"Azonosító: {person.Id}, Név: {person.Name}");
            }
            
        }

        static void PrintRetirementSoon(List<Person> people)
        {
            Console.WriteLine("\nNyugdíj előtt álló dolgozók (10 éven belül):");
            var retirementSoon = people.Where(p => 65 - p.Age <= 10);

            foreach (var person in retirementSoon)
            {
                Console.WriteLine($"Név: {person.Name}, Kor: {person.Age}");
            }
        }
        static void CountHighEarners(List<Person> people)
        {
            int highEarnersCount = people.Count(p => p.Salary > 50000);
            Console.WriteLine($"\nAzoknak a száma, akik 50 000 forint felett keresnek: {highEarnersCount}");
        }

    }
}
