using System;
using System.Text;

namespace Modul9
{
    class Program
    {
        static void Main(string[] args)
        {
            AskForInputAndPrintOutput(StringToUpperCase);
            AskForInputAndPrintOutput(StringTimes3);
            AskForInputAndPrintOutput(StringWithStars);
            AskForInputAndPrintOutput(StringToPigLatin);
        }

        private static string StringToUpperCase(string input) => input.ToUpper();

        private static string StringTimes3(string input) => input + input + input;

        private static string StringWithStars(string input)
        {
            var output = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (i == input.Length - 1)
                    output += input[i];
                else
                    output += input[i] + "*";
            }

            return output;
        }

        private static string StringToPigLatin(string input)
        {
            var sb = new StringBuilder();

            foreach (var character in input)
            {
                if (!"eyuioaåäö".Contains(character.ToString().ToLower()))
                    sb.Append(character + "o" + character);
                else
                    sb.Append(character);
            }

            return sb.ToString();
        }

        public static void AskForInputAndPrintOutput(Func<string, string> method)
        {
            Console.Write("Enter a string to convert: ");
            var input = ReadLineColor(ConsoleColor.Green);
            Console.Write($"Here is the result: {method(input)}");
            Console.WriteLine("\n");
        }

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
