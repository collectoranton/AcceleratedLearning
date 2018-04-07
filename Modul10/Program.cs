using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Modul10
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<int, string>();

            while (true)
            {
                Console.Write("Enter product-ID and name: ");
                var command = ReadLineColor(ConsoleColor.Green);

                if (command == "")
                    break;

                if (!CommandIsValid(command))
                {
                    WriteLineColor("Invalid input", ConsoleColor.Red);
                    continue;
                }

                if (DictionaryContainsIDFromCommand(command, dictionary))
                    WriteLineColor($"The product list already contains the ID {ParseCommandToID(command)}", ConsoleColor.Red);
                else
                    AddCommandToDictionary(command, dictionary);
            }

            foreach (var item in dictionary)
            {
                WriteLineColor($"Product-ID = {item.Key} and name = {item.Value}", ConsoleColor.Gray);
            }
        }

        static string[] SplitCommand(string command) => command.Split(',');

        static bool CommandIsValid(string command) => Regex.IsMatch(command, @"^(\s|)+\d+(\s|)+,(\s|)+.+(\s|)+$");

        static bool DictionaryContainsIDFromCommand(string command, Dictionary<int, string> dictionary) => (dictionary.ContainsKey(ParseCommandToID(command))) ? true : false;

        static void AddCommandToDictionary(string command, Dictionary<int, string> dictionary)
        {
            var productID = ParseCommandToID(command);
            var name = ParseCommandToName(command);

            dictionary.Add(productID, name);
        }

        static int ParseCommandToID(string command) => int.Parse(SplitCommand(command)[0].Trim());

        static string ParseCommandToName(string command) => SplitCommand(command)[1].Trim();

        public static void WriteLineColor(string writeLine, ConsoleColor color)
        {
            var initialColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(writeLine);
            Console.ForegroundColor = initialColor;
        }

        public static string ReadLineColor(ConsoleColor color)
        {
            var initialColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            var input = Console.ReadLine();
            Console.ForegroundColor = initialColor;
            return input;
        }
    }
}
