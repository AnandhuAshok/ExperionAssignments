using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace xmlparsing
{
    class Program
    {
        static void Main(string[] args)
        {
            int balance = 0;

            // XElement xelement = XElement.Load("Customers.xml");
            // IEnumerable<XElement> customers = xelement.Elements();
            XDocument customers = XDocument.Load("Customers.xml");
            var qryCust = customers.Descendants("Customer").OrderBy(x => x.Attribute("CustomerID").Value);




            foreach (var cust in qryCust)
            {
                //Console.WriteLine(cust);
                Console.WriteLine(cust.Attribute("CustomerID").Value + "\t" + cust.Attribute("City").Value + "\t\t" + cust.Attribute("ContactName").Value);
            }


            var qryCust2 = customers.Descendants("Customer")
                            .Where(x => x.Attribute("City").Value == "London");

            Console.WriteLine("\n" + "customer in london city" + "\n");

            foreach (var cust in qryCust2)
            {
                //Console.WriteLine(cust);
                Console.WriteLine(cust.Attribute("CustomerID").Value + "\t" + cust.Attribute("City").Value + "\t\t" + cust.Attribute("ContactName").Value);
            }

            ///
            /// Retrieve only the customers who reside in city ‘London’ using LINQ.
            ///
            var qryCust3 = customers.Descendants("Customer")
                            .Where(x => x.Attribute("City").Value == "London")
                            .OrderBy(x => x.Attribute("CustomerID").Value);

            ///
            /// Get the number of customers by their residing city using LINQ.
            ///
            var qryCust4 = customers.Descendants("Customer")
                           .GroupBy(x => x.Attribute("City").Value)
                           .Select(x => new { city = x.Key, count = x.Count() });

            Console.WriteLine("city" + "\t" + "numbe of customers");
            foreach (var cust in qryCust4)
            {
                //Console.WriteLine(cust);
                Console.WriteLine(cust.city + "\t" + cust.count);
            }

            List<Account> customer = new List<Account>();
            customer.Add(new Account { AccountNumber = 92920131323, CustomerName = " Customer-1", Status = "Active" });
            customer.Add(new Account { AccountNumber = 89234999233, CustomerName = "Customer-2", Status = "Active" });
            customer.Add(new Account { AccountNumber = 92342009022, CustomerName = "Customer-3", Status = "Active" });
            customer.Add(new Account { AccountNumber = 89989234992, CustomerName = "Customer-4", Status = "Inactive " });
            customer.Add(new Account { AccountNumber = 23900000002, CustomerName = "Customer-5", Status = "Inactive" });
            customer.Add(new Account { AccountNumber = 49398453948, CustomerName = "Customer-6", Status = "Active" });


            List<Transaction> trans = new List<Transaction>();
            trans.Add(new Transaction { TransactionID = "TX323423002", Acnumber = 92920131323, TransactionType = "Credit", Amount = 10000, Remarks = "Initial Deposit" });
            trans.Add(new Transaction { TransactionID = "TX929828222", Acnumber = 89234999233, TransactionType = "Credit", Amount = 4500, Remarks = "NEFT/3322" });
            trans.Add(new Transaction { TransactionID = "TX239892282", Acnumber = 23900000002, TransactionType = "Debit", Amount = 1000, Remarks = "ATM/3232" });
            trans.Add(new Transaction { TransactionID = "TX234234234", Acnumber = 89234999233, TransactionType = "Credit", Amount = 23560, Remarks = "Initial Deposit" });
            trans.Add(new Transaction { TransactionID = "TX455611231", Acnumber = 92342009022, TransactionType = "Credit", Amount = 2333, Remarks = "Initial Deposit" });
            trans.Add(new Transaction { TransactionID = "TX324564542", Acnumber = 89989234992, TransactionType = "Credit", Amount = 500, Remarks = "Initial Deposit" });
            trans.Add(new Transaction { TransactionID = "TX223423222", Acnumber = 23900000002, TransactionType = "Credit", Amount = 1000, Remarks = "Initial Deposit" });
            trans.Add(new Transaction { TransactionID = "TX463463454", Acnumber = 49398453948, TransactionType = "Credit", Amount = 199820, Remarks = "Initial Deposit" });
            trans.Add(new Transaction { TransactionID = "TX234235233", Acnumber = 89989234992, TransactionType = "Debit", Amount = 500, Remarks = "ATM/929392" });
            trans.Add(new Transaction { TransactionID = "TX923989392", Acnumber = 92920131323, TransactionType = "Credit", Amount = 3000, Remarks = "NEFT/23322" });
            trans.Add(new Transaction { TransactionID = "TX239482938", Acnumber = 49398453948, TransactionType = "Credit", Amount = 20000, Remarks = "NEFT/44333" });
            trans.Add(new Transaction { TransactionID = "TX212312322", Acnumber = 92920131323, TransactionType = "Debit", Amount = 1500, Remarks = "ATM/30202" });
            trans.Add(new Transaction { TransactionID = "TX929828222", Acnumber = 89234999233, TransactionType = "Credit", Amount = 4500, Remarks = "NEFT/3322" });
            trans.Add(new Transaction { TransactionID = "TX239892282", Acnumber = 23900000002, TransactionType = "Debit", Amount = 1000, Remarks = "ATM/3232" });
            trans.Add(new Transaction { TransactionID = "TX239892003", Acnumber = 49398453948, TransactionType = "Debit", Amount = 3000, Remarks = "ATM/2342" });

            ///
            /// all customer details
            ///
            var allcust = from C in customer
                        join A in trans on C.AccountNumber equals A.Acnumber

                        select new
                        {
                            name = C.CustomerName,
                            accountno = C.AccountNumber,
                            status = C.Status,
                            balnce = balance = (A.Remarks == "Initial Deposit" ? A.Amount : (A.TransactionType == "Credit" ? balance + A.Amount : balance - A.Amount))
                        };
            var details = from b in allcust
                      group b by b.accountno into g
                      select g.Last();
            Console.WriteLine("DETAILS OF ALL CUSTOMERS");
            Console.WriteLine("CUSTOMER NAME" + "\t" + "accont number" + "\t" + "balance" + "\t" + "STATUS");
            foreach (var t in details)
            {
                Console.WriteLine(t.name + "\t " + t.accountno + "\t" + t.balnce + "\t" + t.status);
            }
            ///
            /// active customer details
            ///

            var activecus = from C in customer
                        join A in trans on C.AccountNumber equals A.Acnumber
                        where C.Status == "Active"
                        select new
                        {
                            name = C.CustomerName,
                            accountno = C.AccountNumber,
                            status = C.Status,
                            balnce = balance = (A.Remarks == "Initial Deposit" ? A.Amount : (A.TransactionType == "Credit" ? balance + A.Amount : balance - A.Amount))
                        };
            var bal = from b in activecus
                      group b by b.accountno into g
                      select g.Last();
            Console.WriteLine("DETAILS OF ACTIVE CUSTOMERS");
            Console.WriteLine("CUSTOMER NAME"+"\t"+"accont number"+"\t"+"balance"+"\t"+"STATUS");
            foreach (var t in bal)
            {

                Console.WriteLine( t.name + "\t " + t.accountno + "\t" + t.balnce + "\t" + t.status);
            }

            ///
            /// customer details with minimum 10k
            ///
            var maxbal = from b in activecus
                      where b.balnce >= 10000
                      group b by b.accountno into g
                      select g.Last();

            Console.WriteLine("DETAILS OF CUSTOMERS WITH MINIMUM 10000 BALANCE");
            Console.WriteLine("CUSTOMER NAME" + "\t" + "accont number" + "\t" + "balance" + "\t" + "STATUS");
            foreach (var t in maxbal)
            {

                Console.WriteLine(t.name + "\t " + t.accountno + "\t" + t.balnce + "\t" + t.status);
            }
            ///
            ///
            var minbal = from b in allcust
                         where b.balnce < 500
                         group b by b.accountno into g
                         select g.Last();

            Console.WriteLine("DETAILS OF CUSTOMERS WITH LESS BALANCE");
            Console.WriteLine("CUSTOMER NAME" + "\t" + "accont number" + "\t" + "balance" + "\t" + "STATUS");
            foreach (var t in minbal)
            {

                Console.WriteLine(t.name + "\t " + t.accountno + "\t" + t.balnce + "\t" + t.status);
            }


        }
    }
}
