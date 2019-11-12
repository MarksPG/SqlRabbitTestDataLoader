using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlRabbitTestDataLoader
{
    class Program
    {
        private static People people;
        
        public static DateTime Today { get; }

        static void Main(string[] args)
        {
            //using (var db = new PeopleContext())

            Console.WriteLine("Enter the number of entries to generate: ");
            int entriesNumber = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 1; i < entriesNumber + 1; i++)
            {
                using (var db = new PeopleContext())
                {
                    var x = db.People.Count();

                    people = new People
                    {
                        FirstName = "Per" + i,
                        LastName = "Gustafsson" + i,
                        DOB = DateTime.Now,
                        EmailAddress = "pgg.kinna" + i + "@gmail.com"
                    };

                db.People.Add(people);
                db.SaveChanges();
                Console.WriteLine("Time at entry {0}: {1}", i, DateTime.Now);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Time taken until all entries saved: {0}ms", sw.ElapsedMilliseconds);
            sw.Stop();
            Console.ReadKey();

        }
    }
}

