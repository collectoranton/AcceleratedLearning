using System;
using System.Collections.Generic;

namespace Modul12
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rockstarsArray = new string[] { "Jim Morrison", "Ozzy Osborne", "David Bowie", "Freddie Mercury" };
            List<string> rockstarsList = new List<string> { "Jim Morrison", "Ozzy Osborne", "David Bowie", "Freddie Mercury" };

            DisplayRockstars(rockstarsArray);

            Console.WriteLine();

            DisplayRockstars(rockstarsList);
        }

        static void DisplayRockstars(IEnumerable<string> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine($"* {item}");
            }
        }
    }
}
