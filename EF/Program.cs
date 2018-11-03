using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

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
                for (int i = 0; i < 100; i++)
                {
                    db.Blogs.Add(new Blog()
                    {
                        Name = $"Prova {i}",
                        Url = $"https://atosato.it/Prova{1}"
                    });

                    db.SaveChanges();
                    Console.WriteLine($"Elementi in tabella: {db.Blogs.Count()}");

                    using (var connection = new SqlConnection(db.Database.Connection.ConnectionString))
                    {
                        connection.Open();
                        var blogs = connection.Query<Blog>("Select * FROM Blogs");
                        Console.WriteLine($"Elementi in tabella DAPPER: {blogs.Count()}");
                    }
                }
            }


            Console.ReadKey();
        }
    }
}
