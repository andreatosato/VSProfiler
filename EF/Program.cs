using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            using (var db = new PerformanceContext())
            {
                db.Database.CreateIfNotExists();
                for (int i = 0; i < 10; i++)
                {
                    db.Blogs.Add(new Blog()
                    {
                        Name = $"Prova {i}",
                        Url = $"https://atosato.it/Prova{1}"
                    });
                    db.SaveChanges();
                }

                Console.WriteLine($"Elementi in tabella: {db.Blogs.Count()}");
            }


            Console.ReadKey();
        }
    }
}
