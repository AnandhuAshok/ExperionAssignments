using System;
using System.Collections.Generic;
using System.Linq;

namespace linquetest
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer { Id = 1, Name = "Customer1", Address = "Address1", Category = "Cat1", City = "Cochin" });
            customers.Add(new Customer { Id = 2, Name = "Customer2", Address = "Address2", Category = "Cat2", City = "London" });
            customers.Add(new Customer { Id = 3, Name = "Customer3", Address = "Address3", Category = "Cat3", City = "Sydney" });
            customers.Add(new Customer { Id = 4, Name = "Customer4", Address = "Address4", Category = "Cat4", City = "Trivandrum" });
            customers.Add(new Customer { Id = 5, Name = "Customer5", Address = "Address5", Category = "Cat5", City = "London" });
            customers.Add(new Customer { Id = 6, Name = "Customer6", Address = "Address6", Category = "Cat6", City = "London" });
            customers.Add(new Customer { Id = 7, Name = "Customer7", Address = "Address7", Category = "Cat7", City = "Cochin" });


            List<Loyalty> loyalties = new List<Loyalty>();
            loyalties.Add(new Loyalty { Id = 1, CustomerId = 1, Category = "SP1", LoyaltyProgram = "Premium" });
            loyalties.Add(new Loyalty { Id = 1, CustomerId = 2, Category = "SP3", LoyaltyProgram = "Normal" });
            loyalties.Add(new Loyalty { Id = 1, CustomerId = 3, Category = "SP4", LoyaltyProgram = "Normal" });
            loyalties.Add(new Loyalty { Id = 1, CustomerId = 4, Category = "SP2", LoyaltyProgram = "Premium" });
            loyalties.Add(new Loyalty { Id = 1, CustomerId = 5, Category = "SP1", LoyaltyProgram = "Premium" });


            var qryCust = customers.Where(x => x.City == "London" || x.City == "Cochin")
                          .Select(x => new { Id = x.Id, Name = x.Name, City = x.City })
                          .OrderBy(x => x.Id);


            var qryCust2 = customers.GroupBy(x => x.City)
                .OrderByDescending(x => x.Key);

            var qryjoin = customers.Join(loyalties, x => x.Id, y => y.CustomerId, (x, y) => new
            {
                Name = x.Name,
                LoyaltyProgram = y.LoyaltyProgram
            });


            foreach (var item in qryCust)
            {
                Console.WriteLine("ID : " + item.Id + "\t" + "NAME : " + item.Name + "\t" + "CITY : " + item.City);
            }
         
            foreach(var items in qryCust2)
            {
                Console.WriteLine("\n");
                Console.WriteLine("" + items.Key);
                Console.WriteLine("---------------");
                foreach(Customer c in items)

                {
                    Console.WriteLine(c.Name);
                }

            }
        }
    }
}
