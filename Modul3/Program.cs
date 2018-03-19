using System;
using System.Collections.Generic;
using System.Linq;

namespace Modul3
{
    class Program
    {
        static void Main(string[] args)
        {
            //IfStatement();

            //While();

            //Rainbow(Console.ReadLine());

            //For();

            //ForEachWithBreak();

            //IfStatement2();

            //RandomGuess();

            Console.Write("Enter a number: ");
            //var number = int.Parse(Console.ReadLine());

            Console.WriteLine((int.Parse(Console.ReadLine()) < 20) ? $"{number} is lower than 20" : (number == 20) ? $"{number} is equal to 20" : $"{number} is higher than 20");

            Console.Write("Compare to: ");
            var compare = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;

            //Console.WriteLine((number < compare) ? $"{number} is lower than {compare}" : (number == compare) ? $"{number} is equal to {compare}" : $"{number} is higher than {compare}");
            //Console.WriteLine((number == compare) ? $"{number} is equal to {compare}" : (number < compare) ? $"{number} is lower than {compare}" : $"{number} is higher than {compare}");

            Console.WriteLine();
            Console.ResetColor();
        }

        private static void RandomGuess()
        {
            var random = new Random().Next(1, 101);

            for (int loop = 0; loop < 6; loop++)
            {
                Console.Write("Enter a number: ");
                var number = int.Parse(Console.ReadLine());

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;

                if (number < random)
                    Console.WriteLine($"{number} is lower than random number");
                else if (number == random)
                    Console.WriteLine($"{number} is equal to random number");
                else
                    Console.WriteLine($"{number} is higher than random number");

                Console.WriteLine();
                Console.ResetColor();
            }
        }

        private static void IfStatement2()
        {
            Console.Write("Enter a number: ");
            var number = int.Parse(Console.ReadLine());

            Console.Write("Compare to: ");
            var compare = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;

            if (number < compare)
                Console.WriteLine($"{number} is lower than {compare}");
            else if (number == compare)
                Console.WriteLine($"{number} is equal to {compare}");
            else
                Console.WriteLine($"{number} is higher than {compare}");

            Console.WriteLine();
            Console.ResetColor();
        }

        private static void ForEachWithBreak()
        {
            Console.Write("Enter names in a list (Like Peter, Maria, Lisa): ");
            var namesInput = Console.ReadLine();

            Console.Write("Enter their last name: ");
            var lastName = Console.ReadLine();

            var names = ToListTrimmed(namesInput);

            ListNames(lastName, names);
            ListNamesReverse(lastName, names);
        }

        private static void ListNames(string lastName, List<string> names)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;

            var count = 1;
            foreach (var item in names)
            {
                if (item.ToLower() == "zelda" && !ContainsAllowZelda(names))
                    break;
                Console.WriteLine($"[{count}] {item} {lastName}");
                count++;
            }

            Console.WriteLine();
            Console.ResetColor();
        }

        private static void ListNamesReverse(string lastName, List<string> names)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;

            var count = names.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                if (names[i].ToLower() == "zelda" && !ContainsAllowZelda(names))
                    break;
                Console.WriteLine($"[{count}] {names[i]} {lastName}");
                count--;
            }

            Console.WriteLine();
            Console.ResetColor();
        }

        private static bool ContainsAllowZelda(List<string> names) => names.Any(s => s.Equals("allowzelda", StringComparison.OrdinalIgnoreCase));


        private static List<string> ToListTrimmed(string input)
        {
            var list = new List<string>();

            var names = input.Split(",");

            foreach (var item in names)
            {
                list.Add(item.Trim());
            }
            return list;
        }

        private static void For()
        {
            Console.Write("Enter your name: ");
            var name = Console.ReadLine();

            Console.Write("Times to repeat: ");
            var repeat = int.Parse(Console.ReadLine());

            Console.Write("Times to repeat (column): ");
            var column = int.Parse(Console.ReadLine());

            Console.Write("Times to repeat (row): ");
            var row = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    for (int k = 0; k < repeat; k++)
                    {
                        Console.Write(name);
                    }
                    for (int m = 0; m < repeat; m++)
                    {
                        int count = name.Length;
                        for (int l = name.Length - 1; l >= 0; l--)
                        {
                            Console.Write(name[l]);
                        }
                    }
                    Console.Write("   ");
                }
                Console.WriteLine();
            }

            Console.ResetColor();
            Console.WriteLine();
        }

        private static void While()
        {
            Console.Write("Enter your name: ");
            var name = Console.ReadLine();

            Console.Write("Times to repeat: ");
            var repeat = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            while (repeat > 0)
            {
                Console.WriteLine($"Your name is {name}");
                repeat--;
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        private static void IfStatement()
        {
            Console.Write("When did you go to bed yesterday? ");
            var bedTime = DateTime.Parse(Console.ReadLine());

            Console.Write("When did you wake up? ");
            var wakeTime = DateTime.Parse(Console.ReadLine());

            if (bedTime > wakeTime)
                wakeTime = wakeTime.AddDays(1);

            var sleepTime = wakeTime - bedTime;
            if (sleepTime.TotalHours < 0)
                sleepTime = -sleepTime;

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            if (sleepTime >= TimeSpan.FromHours(7) && sleepTime <= TimeSpan.FromHours(9))
                Console.WriteLine($"You slept well. ({sleepTime.TotalHours} hours)");
            else if (sleepTime < TimeSpan.FromHours(7))
                Console.WriteLine($"You've only slept {sleepTime.TotalHours} hours. Go back to bed!");
            else
                Console.WriteLine($"You've slept {sleepTime.TotalHours} hours. That's a lot.");
            Console.WriteLine();

            Console.ResetColor();
        }

        static void Rainbow(string input)
        {
            var colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
            var count = 0;
            int overflow = 0;

            if (input.Length > colors.Length)
                overflow = input.Length - colors.Length;

            foreach (var item in input)
            {
                Console.ForegroundColor = colors[count];

                Console.Write(item);

                if (count == colors.Length - 1)
                    count = 0;
                else
                    count++;
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
