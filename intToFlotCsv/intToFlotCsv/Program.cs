using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intToFlotCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"D:\C#\intToFlotCsv\intToFlotCsv\MobilePriceList.csv";

            using (StreamReader reader = new StreamReader(File.OpenRead(path)))
            {
                var readFile = reader.ReadToEnd()
                    .Split('\n').Skip(1)
                    .SelectMany(x => x.Split(',').Skip(1))
                    .Select(i => (float)int.Parse(i))
                    .ToList();
                foreach(var ele in readFile)
                {
                    Console.WriteLine(ele);
                }
            }
            Console.ReadLine();
        }
    }
}
