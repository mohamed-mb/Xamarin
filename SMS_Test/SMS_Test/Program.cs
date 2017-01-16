using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Program
    {
       
        static void Main(string[] args)
        {
            String text = "You have made a Payment for Rs.85.00.Your Available Balance is Rs.450 as on Date" +
        "Transaction id:78789 Date:12/06/2016.";
           

            /*
            String[] tokens = text.Split(' ');
            for (var string_count = 0; string_count < tokens.Length; string_count++)
            {
                if (tokens[string_count].Equals("Payment", StringComparison.InvariantCultureIgnoreCase))
                {
                    payment_position = string_count;
                }
                if (tokens[string_count].Equals("Balance", StringComparison.InvariantCultureIgnoreCase))
                {
                    balance_position = string_count;
                }
            }
            
            Console.WriteLine("The Payment position is " + payment_position);
            Console.WriteLine("The Balance Position is " + balance_position);*/
            
            
        }        
    }
    class Transaction
    {
        public double Payment_Amount { get; set; }
        public double Balance_Amount { get; set; }
        public long TransactionId { get; set; }
        public DateTime Transaction_Date { get; set; }

        public override string ToString()
        {
            Console.WriteLine("Payment_amount: " + Payment_Amount +
                "\nBalance Amount: "+Balance_Amount+
                "\nTransaction Id: "+TransactionId+
                "\nTransacton Date:"+Transaction_Date.ToString("d"));
            return base.ToString();
        }
    }
}
