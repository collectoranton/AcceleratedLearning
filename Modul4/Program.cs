using System;
using System.Collections.Generic;
using System.Text;

namespace Modul4
{
    class Program
    {
        static void Main(string[] args)
        {
            var showErrors = GetErrorMessageSetting();
            var separator = GetSeparator(showErrors);

            var names = GetNameList(separator, showErrors);

            names = CleanUpArray(names, "aeyuioAEYUIO");

            RespondToUser(names);
        }

        private static string[] GetNameList(char separator, bool showErrors)
        {
            while (true)
            {
                Console.Write("Enter list of names: ");
                var input = GetInputFromUser();

                var names = CreateArrayFromString(input, separator);

                if (!PeopleArrayIsValid(names, showErrors))
                    continue;

                return names;

            }
        }

        private static string GetInputFromUser()
        {
            return Console.ReadLine();
        }

        private static string[] CreateArrayFromString(string stringToSplit, char separator)
        {
            return stringToSplit.Split(separator);
        }

        private static char GetSeparator(bool showErrorMessage)
        {
            while (true)
            {
                Console.Write("Which separator do you want to use? (default is comma) : ");
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    return ',';

                if (char.TryParse(input, out char separator))
                    return separator;

                if (showErrorMessage)
                    PrintColor("Invalid value", ConsoleColor.Red);
            }
        }

        private static bool GetErrorMessageSetting()
        {
            while (true)
            {
                Console.Write("Do you want to enable error messages? (default is yes) : ");
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || input.ToLower().Trim() == "yes")
                    return true;

                if (input.ToLower().Trim() == "no")
                    return false;

                PrintColor("Invalid value", ConsoleColor.Red);
            }
        }

        private static void RespondToUser(string[] peopleArray)
        {
            Console.WriteLine();
            foreach (var name in peopleArray)
                PrintColor($"***SUPER-{name.ToUpper()}***", ConsoleColor.Green);
            Console.WriteLine();
        }

        private static bool PeopleArrayIsValid(string[] array, bool showErrorMessage)
        {
            if (array.Length == 1 && string.IsNullOrWhiteSpace(array[0]))
            {
                if (showErrorMessage)
                    PrintColor("You must enter a value", ConsoleColor.Red);
                return false;
            }


            foreach (var person in array)
            {
                if (person.Length < 2 || person.Length > 9)
                {
                    if (showErrorMessage)
                        PrintColor("A name must be between 2 and 9 letters", ConsoleColor.Red);
                    return false;
                }
            }

            return true;
        }

        private static string[] CleanUpArray(string[] array, string forbiddenCharacters)
        {
            var output = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
                output[i] = CleanUpWord(array[i], forbiddenCharacters);

            return output;
        }

        private static string CleanUpWord(string word, string forbiddenCharacters)
        {
            var corrected = new StringBuilder();

            foreach (var character in word)
            {
                if (!WordContainsCharacter(forbiddenCharacters, character))
                    corrected.Append(character);
            }

            return corrected.ToString().Trim();
        }

        private static bool WordContainsCharacter(string word, char character) => word.Contains(character.ToString());

        private static void PrintColor(string input, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(input);
            Console.ResetColor();
        }
    }
}
