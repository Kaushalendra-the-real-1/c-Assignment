using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frequencyRepeatedWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Text Below...");
            string inputText = Console.ReadLine();
            Console.WriteLine("Enter the word");
            string inputWord = Console.ReadLine();
            string[] textList = inputText.Split(' ');
            string[] notApplicable = { ",", ".", "@", "and", "between" };
            int count = 0;
            foreach(string item in notApplicable)
            {
                if(inputWord == item)
                {
                    Console.WriteLine("Invalid Input");
                    break;
                }
            }
            foreach(string element in textList)
            {
                if(inputWord == element)
                {
                    count += 1;
                }
            }
            Console.WriteLine("Number of repeated word in the string are " + count);
            Console.ReadLine();
        }
    }
}