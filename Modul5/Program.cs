using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace Modul5
{
    class Program
    {
        static void Main(string[] args)
        {
            //WorkWithObjects();

            Console.WriteLine("GitTest");

            var point = new Point(3, 4);
            Console.WriteLine(point);
            SetPoint(point, 999, 888);
            Console.WriteLine(point);

            Console.WriteLine();

            var stringBuilder = new StringBuilder("Let's go dancing. ");
            Console.WriteLine(stringBuilder);
            ChangeStringBuilder(stringBuilder);
            Console.WriteLine(stringBuilder);

            Console.WriteLine();

            var point2 = new PointStruct(3, 4);
            Console.WriteLine(point2);
            SetPointStruct(point2, 999, 888);
            Console.WriteLine(point2);

            Console.WriteLine(point + " " + point2);

            var dateTime = DateTime.Now;

            Console.WriteLine(dateTime);
            ChangeDate(dateTime);
            Console.WriteLine(dateTime);
            dateTime = dateTime.AddDays(1);
            Console.WriteLine(dateTime);

            Console.WriteLine();
        }

        void ChangeFruit(string fruit)
        {

        }

        void ChangeAge(int age)
        {

        }

        static void ChangeDate(DateTime date)
        {
            date.AddDays(1);
        }

        public static void SetPoint(Point point, int x, int y)
        {
            point.X = x;
            point.Y = y;
        }

        public static void SetPointStruct(PointStruct point, int x, int y)
        {
            point.X = x;
            point.Y = y;
        }

        private static void ChangeStringBuilder(StringBuilder stringBuilder) => stringBuilder.Append("Yes that would be great!");

        private static void WorkWithObjects()
        {
            var repeatMe = "Tennis anyone? ";

            var TimedStringList = new List<TimedString>();
            TimedStringList.Add(new TimedString(repeatMe, 0, false));
            TimedStringList.Add(new TimedString(repeatMe, 5, false));
            TimedStringList.Add(new TimedString(repeatMe, 50, false));
            TimedStringList.Add(new TimedString(repeatMe, 500, false));
            TimedStringList.Add(new TimedString(repeatMe, 5000, false));
            //TimedStringList.Add(new TimedString(repeatMe, 50000, false));

            var TimedStringBuilderList = new List<TimedString>();
            TimedStringBuilderList.Add(new TimedString(repeatMe, 0, true));
            TimedStringBuilderList.Add(new TimedString(repeatMe, 5, true));
            TimedStringBuilderList.Add(new TimedString(repeatMe, 50, true));
            TimedStringBuilderList.Add(new TimedString(repeatMe, 500, true));
            TimedStringBuilderList.Add(new TimedString(repeatMe, 5000, true));
            TimedStringBuilderList.Add(new TimedString(repeatMe, 50000, true));

            PrintList(TimedStringList, "STRING TEST");
            PrintList(TimedStringBuilderList, "STRINGBUILDER TEST");
            Console.WriteLine();
        }

        private static void PrintList(List<TimedString> list, string headline)
        {
            PrintColor($"\n{headline}\n", ConsoleColor.Green);

            int row = Console.CursorTop;

            Console.SetCursorPosition(0, row);
            PrintColor("Cycles", ConsoleColor.DarkGray);
            Console.SetCursorPosition(30, row);
            PrintColor("Length of string", ConsoleColor.DarkGray);
            Console.SetCursorPosition(60, row);
            PrintColor("Time", ConsoleColor.DarkGray);

            foreach (var element in list)
            {
                row++;
                Console.SetCursorPosition(0, row);
                Console.WriteLine(element.Cycles);
                Console.SetCursorPosition(30, row);
                Console.WriteLine(element.Length);
                Console.SetCursorPosition(60, row);
                Console.WriteLine(element.ExecutionTime.TotalMilliseconds + "ms");
            }
        }

        private static void PrintColor(string input, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(input);
            Console.ResetColor();
        }
    }

    struct PointStruct
    {
        public int X;
        public int Y;

        public PointStruct(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void SetPoint(PointStruct point)
        {
            X = point.X;
            Y = point.Y;
        }

        public override string ToString() => string.Format($"point=({X}, {Y})");
    }

    class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => string.Format($"point=({X}, {Y})");
    }

    class TimedString
    {
        private string repeatedString;
        public string StringToRepeat;
        public int Length;
        public int Cycles;
        public TimeSpan ExecutionTime;

        public TimedString(string stringToRepeat, int cycles, bool useStringBuilder)
        {
            StringToRepeat = stringToRepeat;
            Cycles = cycles;

            var stopwatch = new Stopwatch();

            if (useStringBuilder)
            {
                stopwatch.Start();
                repeatedString = GenerateStringBuilder(stringToRepeat, cycles);
                stopwatch.Stop();
            }
            else
            {
                stopwatch.Start();
                repeatedString = GenerateString(stringToRepeat, cycles);
                stopwatch.Stop();
            }

            ExecutionTime = stopwatch.Elapsed;
            Length = repeatedString.Length;
        }

        private static string GenerateString(string repeatMe, int cycles)
        {
            string result = "";

            for (int i = 0; i < cycles; i++)
                result += repeatMe;

            return result;
        }

        private static string GenerateStringBuilder(string repeatMe, int cycles)
        {
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < cycles; i++)
                stringBuilder.Append(repeatMe);

            return stringBuilder.ToString();
        }
    }
}
