using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace HTTPGoogle
{
    class Program
    {
        class HttpGoogle
        {
            private class Items
            {
                public string kind { get; set; }
                public string title { get; set; }
                public string displayLink { get; set; }
            }
            public static void ShowUrlResult()
            {
                try
                {
                    string searchQuery;
                    Console.WriteLine("Enter search query.");
                    searchQuery = Console.ReadLine();
                    string apiKey = "";
                    string cx = "";

                    WebRequest request = WebRequest.Create("https://www.googleapis.com/customsearch/v1?key=" + apiKey + "&cx=" + cx + "&q=" + searchQuery);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                    response.Close();

                    dynamic jsonData = JsonConvert.DeserializeObject(responseFromServer);
                    var results = new List<Items>();

                    if (jsonData.items.Count >= 10)
                    {
                        for (var i = 0; i < 10; i++)
                        {
                            results.Add(new Items() { kind = jsonData.items[i].kind, title = jsonData.items[i].title, displayLink = jsonData.items[i].displayLink });
                        }

                    }
                    else
                    {
                        for (var i = 0; i < jsonData.items.Count; i++)
                        {
                            results.Add(new Items() { kind = jsonData.items[i].kind, title = jsonData.items[i].title, displayLink = jsonData.items[i].displayLink });
                        }
                    }

                    Console.Write("[");
                    foreach (var i in results)
                    {
                        Console.Write("{");
                        Console.Write($"Kind:'{i.kind}',Title:'{i.title}',DisplayLink:'{i.displayLink}'");
                        Console.Write("},");
                    }
                    Console.Write("]");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

        }
        static void Main(string[] args)
        {
            HttpGoogle.ShowUrlResult();
        }
    }
}
