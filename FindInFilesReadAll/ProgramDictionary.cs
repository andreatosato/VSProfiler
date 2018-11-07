using System;
using System.Collections.Generic;
using System.IO;

namespace FindInFilesReadAll.DictionarySample
{
    class Program
    {
        private static Dictionary<string, List<CounterData>> SearchIndex { get; set; } = new Dictionary<string, List<CounterData>>();
        static void Main2(string[] args)
        {
            string searchText = string.Empty;
            do
            {
                var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "divina_commedia.txt"));
                Console.WriteLine("Cerca una parola:");
                searchText = Console.ReadLine();
                Search(lines, searchText.ToUpper());
            } while (!string.IsNullOrEmpty(searchText));
            Console.ReadLine();
        }

        static void Search(string[] lines, string searchText)
        {
            int counter = 0;
            if (SearchIndex.ContainsKey(searchText))
            {
                foreach(var line in SearchIndex.GetValueOrDefault(searchText))
                {
                    counter = Print(line.Row, line.Counter);
                }
            }
            else
            {
                SearchIndex.Add(searchText, new List<CounterData>());
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(searchText, StringComparison.CurrentCultureIgnoreCase))
                    {
                        SearchIndex.GetValueOrDefault(searchText).Add(new CounterData { Row = i, Counter = counter });
                        counter = Print(i, counter);
                    }
                }
            }
            
        }

        private static int Print(int row, int counter)
        {
            Console.WriteLine($"Line: {row}, Found: {counter}");
            return ++counter;
        }

        public class CounterData
        {
            public int Row { get; set; }
            public int Counter { get; set; }
        }
    }
}
