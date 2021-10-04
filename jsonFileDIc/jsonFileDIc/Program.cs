using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace jsonFileDIc
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"D:\C#\jsonFileDIc\jsonFileDIc\Folder\dummy.json";
            string jsonFile = File.ReadAllText(path);
            //stored in Dictionary..........
            Dictionary<string, object> values =JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonFile);
            foreach(KeyValuePair<string, object> ele in values)
            {
                Console.WriteLine("{0} = {1}", ele.Key, ele.Value);
            }
            Console.ReadLine();
        }
    }
    public class CarModel
    {
        public string[] color { get; set; }
        public string Make { get; set; }
        public int Price { get; set; }
    }
}
