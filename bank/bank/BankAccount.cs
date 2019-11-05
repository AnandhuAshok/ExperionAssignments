using System;
using System.Collections.Generic;
using System.Text;

namespace bank
{
    class BankAccount
    {
        public int accno;
        private string name;
        private int balance;

        public void add()
        {
            Console.WriteLine("Enter account number");
            accno=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter account holder name");
            name=Console.ReadLine();
            Console.WriteLine("Enter initial account balance");
            balance=int.Parse(Console.ReadLine());

        }

        public void view()
        {
            Console.WriteLine("account number :"+"\t"+accno+"\n"+"account name : "+"\t"+name+"\n"+"balance : "+"\t"+balance);
        }
        public void deposit(int amount)
        {
            
            this.balance += amount;
            Console.WriteLine("TRANSACTION COMPLETED...AMOUNT DEPOSITED!!"+"\n");

        }

        public void withdraw(int amount)
        {

            int newamnt = this.balance - amount;
            if(newamnt<=500)
            {
                balance = newamnt;
                Console.WriteLine("Transaction sucessfull.....AMOUNT WITHDRAW");
            }
            else
            {
                Console.WriteLine("transaction canelled due to insufficient amount in account");
            }

        }

        public void transfer(BankAccount accnt2)
        {
            Console.WriteLine("enter amount to transfer");
            int newamnt = int.Parse(Console.ReadLine());
            this.withdraw(newamnt);
            accnt2.deposit(newamnt);
            Console.WriteLine("first account details"+"\n");
            this.view();
            Console.WriteLine("second account details"+"\n");
            accnt2.view();
        }

    }
}
