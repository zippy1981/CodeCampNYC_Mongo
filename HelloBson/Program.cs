using System;
using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Bson.IO;

namespace HelloBson
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var settings = new JsonWriterSettings {Indent = true};

            var foo = new
                          {
                              Name = "Justin Dearing",
                              Profession = "N/A",
                              IsConsultant = true,
                              Languages = new[]
                                              {
                                                  "C#", "PHP", "Javascript", "PowerShell"
                                              }
                          };

            Console.Write("BSON: ");
            Console.WriteLine(foo.ToBson().ToJson());
            Console.WriteLine();

            Console.Write("JSON: ");
            Console.WriteLine(foo.ToJson(settings));
            Console.WriteLine();

            // Collection time
            var collection = new Dictionary<string, Dictionary<int, string>>
                                 {
                                     {
                                         "Numbers", new Dictionary<int, string>
                                                        {
                                                            {1, "One"},
                                                            {2, "Two"},
                                                            {3, "Three"},
                                                            {4, "Four"},
                                                            {5, "Five"}
                                                        }
                                         },
                                     {
                                         "Letters", new Dictionary<int, string>
                                                        {
                                                            {1, "A"},
                                                            {2, "B"},
                                                            {3, "C"},
                                                            {4, "D"},
                                                            {5, "E"}
                                                        }
                                         }
                                 };
            Console.Write("Crazy generics: ");
            Console.WriteLine(collection.ToJson(settings));
            Console.WriteLine();

            Console.WriteLine("Press Any Key To Continue . . .");
            Console.ReadKey(true);
        }
    }
}
