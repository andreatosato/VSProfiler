using System;
using System.IO;

namespace FindInFilesReadAll
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "divina_commedia.txt"));
            string searchText = string.Empty;
            do
            {
                //var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "divina_commedia.txt"));
                searchText = Console.ReadLine();
                Search(lines, searchText);
            } while (!string.IsNullOrEmpty(searchText));
            Console.ReadLine();
        }

        static void Search(string[] lines, string searchText)
        {
            int counter = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(searchText, StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine($"Line: {i}, Found: {counter}");
                    counter++;
                }
            }
        }
    }
}
