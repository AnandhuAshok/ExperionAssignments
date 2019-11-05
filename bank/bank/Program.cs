using System;
using System.Collections.Generic;

namespace bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("** BANK MANAGEMENT SYSTEM **");
            List<BankAccount> bankobj = new List<BankAccount>();
            while (true)
            {

                Console.WriteLine("\n"+"1.ADD ACCOUNT DETAILS" + "\n" + "2.VIEW ACCOUNT DETAILS" + "\n" + "3.DEPOSIT" + "\n" + "3.WITHDRAW" + "\n" + "5.TRANSFER AMOUNT" + "\n" + "6.EXIT"+"\n"+"enter your option :");
                int opt = int.Parse(Console.ReadLine());
                int i = 0, searchid;
                switch (opt)
                {
                    case 1:
                        char op;
                        do
                        {

                            BankAccount accntobj = new BankAccount();
                            accntobj.add();
                            bankobj.Add(accntobj);
                            Console.WriteLine("do you want to add new account details(y/n)");
                            op = char.Parse(Console.ReadLine().ToLower());
                            i += 1;

                        } while (op != 'n');
                        break;

                    case 2:
                        Console.WriteLine("Enter account details");
                        searchid = int.Parse(Console.ReadLine());
                        foreach (var accnt in bankobj)
                        {
                            if (accnt.accno == searchid)
                            {
                                accnt.view();
                                break;

                            }
                            else
                            {
                                Console.WriteLine("\n"+"NO ACCOUNT FOUND!!");
                            }

                        }

                        break;

                    case 3:
                        Console.WriteLine("Enter account details");
                        searchid = int.Parse(Console.ReadLine());
                        foreach (var accnt in bankobj)
                        {
                            if (accnt.accno == searchid)
                            {
                                Console.WriteLine("Enter amount to deposit");
                                int amount = int.Parse(Console.ReadLine());
                                accnt.deposit(amount);
                                Console.WriteLine("UPDATED ACCOUNT DETAILS");
                                accnt.view();
                                break;
                            }

                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter account details");
                        searchid = int.Parse(Console.ReadLine());
                        foreach (var accnt in bankobj)
                        {
                            if (accnt.accno == searchid)
                            {
                                Console.WriteLine("Enter amount to withdraw");
                                int amount = int.Parse(Console.ReadLine());
                                accnt.withdraw(amount);
                                break;
                                Console.WriteLine("Account updated");
                                accnt.view();
                            }

                        }
                        break;

                    case 5:
                        Console.WriteLine("ENTER FIRST ACCOUNT NUMBER");
                        int acc1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("ENTER SECOND ACCOUNT NUMBER");
                        int acc2 = int.Parse(Console.ReadLine());
                        foreach (var accnt1 in bankobj)
                        {
                            if (accnt1.accno == acc1)
                            {
                                foreach (var accnt2 in bankobj)
                                {
                                    if (accnt2.accno == acc2)
                                    {
                                        accnt1.transfer(accnt2);
                                    }
                                    else
                                    {
                                        Console.WriteLine("NO MATCHING ACCOUNT FOUND");
                                    }

                                }
                            }
                            else
                            {
                                Console.WriteLine("NO MATCHING ACCOUNT FOUND");
                            }


                        }
                        break;

                    case 6:
                        System.Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("please select a valid option");
                        break;

                }
            }
        }
    }
}
