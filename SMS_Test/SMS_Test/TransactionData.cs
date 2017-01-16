using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SMS_Test
{
     public class TransactionData
    {
        public DateTime Transaction_Date { get; set; }
        public string Transaction_Type { get; set; }
        public double Payment_Amount { get; set; }
        public double Balance_Amount { get; set; }
        public long TransactionId { get; set; }
        public void SetValues(String body)
        {
            string pat = @"payment (\w) RS.";
        }
        public override string ToString()
        {
            Console.WriteLine("Payment_amount: " + Payment_Amount +
                "\nBalance Amount: " + Balance_Amount +
                "\nTransaction Id: " + TransactionId +
                "\nTransacton Date:" + Transaction_Date.ToString("d"));
            return base.ToString();
        }

    }
}