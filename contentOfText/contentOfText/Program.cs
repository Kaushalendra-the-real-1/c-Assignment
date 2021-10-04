using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contentOfText
{
    public static class Extensions
    {
        public static string Filter(this string str, List<string> charsToRemove)
        {
            String chars = "[" + String.Concat(charsToRemove) + "]";
            return Regex.Replace(str, chars, String.Empty);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a text below");
            string str = Console.ReadLine();
            List<string> charsToRemove = new List<string>() { "@", "_", ",", "." };

            str = str.Filter(charsToRemove);
            Console.WriteLine(str);
            Console.ReadLine();
        }
    }
}
