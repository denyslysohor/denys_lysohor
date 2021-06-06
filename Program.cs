using LinqRequest;
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace LinqRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            // одни и те же айди у одинаковых людей - плохая затея, у каждого должны быть разные 
            List<Person> people = new List<Person>
        {
            new Person {Id = 1, FirstName = "Denys", LastName = "Denysov", Age = 18 },
            new Person {Id = 2, FirstName = "Oleksii", LastName = "Sharapov", Age = 43 },
            new Person {Id = 3, FirstName = "Dmitrii", LastName = "Ignaschevich", Age = 17},
            new Person {Id = 4, FirstName = "Leonid", LastName = "Ivanov", Age = 75},
            new Person {Id = 5, FirstName = "Julia", LastName = "Yanova", Age = 40 },
            new Person {Id = 6, FirstName = "Oleksandr", LastName = "Petrov", Age = 18 },
        };

            List<Address> addresses = new List<Address>
            {
                new Address { Id = 1, Country = "USA", City = "Cupertino", ZipCode = "90004", AddressLine = "One Apple Park Way" },
                new Address { Id = 2, Country = "Slovakia", City = "Bratislava", ZipCode = "353535", AddressLine = "One Apple Park Way" },
                new Address { Id = 3, Country = "Ukraine", City = "Kharkiv", ZipCode = "61000", AddressLine = "One Apple Park Way" },
                new Address { Id = 4, Country = "Germany", City = "Berlin", ZipCode = "53344", AddressLine = "One Apple Park Way" },
                new Address { Id = 5, Country = "Bulgaria", City = "Sofia", ZipCode = "2424", AddressLine = "One Apple Park Way" },
                new Address { Id = 6, Country = "Canada", City = "Cupertino", ZipCode = "345342", AddressLine = "One Apple Park Way" },
                new Address { Id = 7, Country = "USA", City = "New York", ZipCode = "10004", AddressLine = "One Apple Park Way" },
                new Address { Id = 8, Country = "Croatia", City = "Zagreb", ZipCode = "24242342", AddressLine = "One Apple Park Way" },
                new Address { Id = 9, Country = "Italy", City = "Venice", ZipCode = "90023423400", AddressLine = "One Apple Park Way" },
                new Address { Id = 10, Country = "Japan", City = "Tokyo", ZipCode = "900243200", AddressLine = "One Apple Park Way" },
                new Address { Id = 11, Country = "Mexico", City = "Mexico City", ZipCode = "234234", AddressLine = "One Apple Park Way" },
                new Address { Id = 12, Country = "France", City = "Paris", ZipCode = "1234234", AddressLine = "One Apple Park Way" },
                new Address { Id = 13, Country = "Sri-Lanka", City = "Colombo", ZipCode = "23423", AddressLine = "One Apple Park Way" },
                new Address { Id = 14, Country = "Spain", City = "Madrid", ZipCode = "2545", AddressLine = "One Apple Park Way" },
                new Address { Id = 15, Country = "UK", City = "London", ZipCode = "2342", AddressLine = "One Apple Park Way" },
                new Address { Id = 16, Country = "Russia", City = "Moscow", ZipCode = "1234", AddressLine = "One Apple Park Way" },
            };
           
            List<PeopleAddress> peopleAddresses = new List<PeopleAddress>
            {
                new PeopleAddress{ PersonId = 1, AddressId = 1 },
                new PeopleAddress{ PersonId = 1, AddressId = 4 },
                new PeopleAddress{ PersonId = 1, AddressId = 8 },
                new PeopleAddress{ PersonId = 1, AddressId = 12 },
                new PeopleAddress{ PersonId = 2, AddressId = 1 },
                new PeopleAddress{ PersonId = 2, AddressId = 13 },
                new PeopleAddress{ PersonId = 2, AddressId = 8 },
                new PeopleAddress{ PersonId = 2, AddressId = 12 },
                new PeopleAddress{ PersonId = 3, AddressId = 1 },
                new PeopleAddress{ PersonId = 3, AddressId = 4 },
                new PeopleAddress{ PersonId = 3, AddressId = 9 },
                new PeopleAddress{ PersonId = 3, AddressId = 11 },
                new PeopleAddress{ PersonId = 4, AddressId = 1 },
                new PeopleAddress{ PersonId = 4, AddressId = 3 },
                new PeopleAddress{ PersonId = 4, AddressId = 10 },
                new PeopleAddress{ PersonId = 4, AddressId = 14 },
                new PeopleAddress{ PersonId = 5, AddressId = 3 },
                new PeopleAddress{ PersonId = 5, AddressId = 2 },
                new PeopleAddress{ PersonId = 5, AddressId = 8 },
                new PeopleAddress{ PersonId = 5, AddressId = 12 },
                new PeopleAddress{ PersonId = 6, AddressId = 1 },
                new PeopleAddress{ PersonId = 6, AddressId = 4 },
                new PeopleAddress{ PersonId = 6, AddressId = 8 },
                new PeopleAddress{ PersonId = 6, AddressId = 15 },
            };

            var result = from p in people where p.Age > 18 select p;
            Console.WriteLine("Запрос номер 2:");
            foreach (var item in result)
            {
                Console.WriteLine(item.FirstName);
            }

            Console.WriteLine();

            double avg = people.Average(p => p.Age);
            Console.WriteLine("Запрос номер 4:");
            Console.WriteLine(avg);

            Console.WriteLine();

            var result1 = from p in people
                          join peopleAd in peopleAddresses on p.Id equals peopleAd.PersonId
                          join ad in addresses on peopleAd.AddressId equals ad.Id
                          select new { FirstName = p.FirstName, Country = ad.Country };
            
            Console.WriteLine("Запрос номер 1:");
            foreach (var r in result1)
            {
                Console.WriteLine(r.FirstName + "  |  " + r.Country );
            }

            var result2 = from p in people
                          join peopleAd in peopleAddresses on p.Id equals peopleAd.PersonId
                          join ad in addresses on peopleAd.AddressId equals ad.Id
                          group ad by ad.Country into g
                          select new { NameCountry = g.Key, 
                                       Addresses = from ad in addresses where ad.Country == g.Key select ad, 
                                       People = from p in people
                                                join peopleAd in peopleAddresses on p.Id equals peopleAd.PersonId
                                                join ad in addresses on peopleAd.AddressId equals ad.Id
                                                where ad.Country == g.Key
                                                select p};
            Console.WriteLine();
            Console.WriteLine("Запрос номер 3:");
            foreach (var r in result2)
            {
                Console.WriteLine();
                Console.WriteLine(r.NameCountry);
                Console.WriteLine();
                Console.Write("       ");
                Console.WriteLine("Address:");
                foreach (var a in r.Addresses)
                {
                    Console.Write("       ");
                    Console.WriteLine(a.Id +" | "+ a.City + " | " + a.ZipCode + " | " + a.AddressLine + " | " );
                }
                Console.Write("       ");
                Console.WriteLine("---------------------------");
                Console.Write("       ");
                Console.WriteLine("People:");

                foreach (var p in r.People)
                {
                    Console.Write("       ");
                    Console.WriteLine("Person: " + p.Id + " | " + p.FirstName + " | " + p.LastName + " | " + p.Age + " | ");
                }

            }
        }
    }
}
