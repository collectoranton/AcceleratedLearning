using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegEx
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"(\w+)\s(\d+(\d))");
            var matches = regex.Matches("jan 2018, may 2018, june 2017");

            var matchArray = matches.ToArray();

            Console.WriteLine(matchArray[0].Groups[2].Captures[0]);

            for (int i = 0; i < matchArray.Length; i++)
            {
                for (int j = 0; j < matchArray[i].Groups.Count; j++)
                {
                    Console.WriteLine($"i:{i} j:{j} : {matchArray[i].Groups[j].Value}");
                }
            }
        }
    }
}
