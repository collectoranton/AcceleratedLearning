using System;
using System.Collections.Generic;
using System.Text;

namespace Modul2
{
    class Program
    {
        static void Main(string[] args)
        {
            //RespondToUserInput();

            //WorkingWithDifferentTypes();

            //StringCreation();
        }

        private static void StringCreation()
        {
            Console.Write("How many fruits do you want to enter? ");
            var numberOfFruits = int.Parse(Console.ReadLine());

            Console.WriteLine();

            //var fruitList = new List<string>();

            //for (int i = 0; i < numberOfFruits; i++)
            //{
            //    Console.Write("Enter fruit number " + (i + 1) + ": ");
            //    fruitList.Add(Console.ReadLine().Trim().ToLower());
            //}

            var stringBuilder = new StringBuilder();

            for (int i = 0; i < numberOfFruits; i++)
            {
                Console.Write("Enter fruit number " + (i + 1) + ": ");
                if (i == numberOfFruits - 1)
                    stringBuilder.Append(Console.ReadLine().Trim().ToLower() + "!");
                else
                    stringBuilder.Append(Console.ReadLine().Trim().ToLower() + ", ");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"\nYou added {numberOfFruits} fruits: ");



            //foreach (var item in fruitList)
            //{
            //    if (fruitList[fruitList.Count - 1].Equals(item))
            //        Console.Write("{0}!", item);
            //    else
            //        Console.Write("{0}, ", item);
            //}

            Console.WriteLine("\n");
            Console.ResetColor();
        }

        private static void WorkingWithDifferentTypes()
        {
            Console.Write("What is your name? ");
            var name = Console.ReadLine();

            var age = CheckInputForAge();

            Console.Write("What is your favorite letter? ");
            var favoriteLetter = char.Parse(Console.ReadLine());

            var yearsUntilRetirement = 67 - age;

            if (name == "Anton" && age == 30)
                Console.Beep();

            Console.WriteLine("\nThank you!\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your name is {0}\n" +
                "You have {1} years until retirement", name, yearsUntilRetirement);

            if (char.IsNumber(favoriteLetter))
                Console.WriteLine("You like numbers\n");
            else
                Console.WriteLine("You don't like numbers\n");

            Console.ResetColor();
        }

        private static int CheckInputForAge()
        {
            while (true)
            {
                Console.Write("How old are you? ");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int result)) return result;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Felaktig inmatning");
                Console.ResetColor();
            }
        }

        private static void RespondToUserInput()
        {
            Console.Write("What is your name? ");
            var name = Console.ReadLine();
            Console.Write("How old are you? ");
            var age = Console.ReadLine();
            Console.Write("What is your favorite letter? ");
            var favoriteLetter = Console.ReadLine();
            Console.Write("Where do you live? ");
            var location = Console.ReadLine();
            Console.Write("What is your favorite food? ");
            var favoriteFood = Console.ReadLine();

            Console.WriteLine("\nThank you!\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your name is {0}\n" +
                "You are {1} years old\n" +
                "Your favorite letter is {2}\n" +
                "You live in {3}\n" +
                "Your favorite food is {4}\n", name, age, favoriteLetter, location, favoriteFood);
            Console.ResetColor();

            var colors = new List<ConsoleColor>();
        }
    }
}
