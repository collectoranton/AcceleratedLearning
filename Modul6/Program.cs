using System;
using System.Text.RegularExpressions;

namespace Modul6
{
    class Program
    {
        static void Main(string[] args)
        {
            var lisa = new Person("Lisa", "Larsson", DateTime.Parse("1990/06/01"), Gender.Female, Sport.Rugby);

            var olle = new Person { FavoriteSports = new Sport[] { Sport.Rugby, Sport.Tennis } };

            Console.WriteLine($"{lisa.FirstName} {lisa.LastName} {olle.FavoriteSports[0]} {lisa.Birthday.ToShortDateString()}");

            var home = new Address { Street = "Gatvägen", StreetNumber = 1 };

            Console.WriteLine($"{home.GetFullStreet()}, {home.FullStreet}");

            home.SetZipCode("123 23");
            Console.WriteLine(home.ZipCode);
        }
    }

    class Address
    {
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }

        public string GetFullStreet() => $"{Street} {StreetNumber}";
        public string FullStreet => $"{Street} {StreetNumber}";
        public void SetZipCode(string zipCode)
        {
            if (Regex.IsMatch(zipCode, @"^\d{3}\s\d{2}$"))
                ZipCode = int.Parse(Regex.Replace(zipCode, @"\s", ""));
        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public Sport FavoriteSport { get; set; }
        public Sport[] FavoriteSports { get; set; }

        public Person()
        {

        }

        public Person(string firstName, string lastName, DateTime birthday, Gender gender, Sport favoriteSport)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            Gender = gender;
            //FavoriteSport = favoriteSport;
        }
    }

    enum Sport
    {
        Tennis,
        Rugby,
        Soccer,
        Hurling,
        Squash
    }

    enum Gender
    {
        Female,
        Male,
        Other
    }
}
