using System;
using System.IO;

namespace Modul8
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter streamWriter;

            while (true)
            {
                Console.Write("Enter a file name: ");
                var path = ReadLineColor(ConsoleColor.Green);

                try
                {
                    streamWriter = new StreamWriter(path);
                    Console.WriteLine($"The file '{path}' is now created.");
                    break;
                }
                //catch (UnauthorizedAccessException e)
                //{
                //    WriteLineColor(e.Message, ConsoleColor.Red);
                //}
                //catch (DirectoryNotFoundException e)
                //{
                //    WriteLineColor(e.Message, ConsoleColor.Red);
                //}
                //catch (ArgumentException e)
                //{
                //    WriteLineColor(e.Message, ConsoleColor.Red);
                //}
                catch (Exception e)
                {
                    WriteLineColor(e.Message, ConsoleColor.Red);
                }
            }


            //streamWriter.Close();
        }

        static void WriteLineColor(string input, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(input);
            Console.ResetColor();
        }

        static string ReadLineColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            var output = Console.ReadLine();
            Console.ResetColor();
            return output;
        }
    }
}
