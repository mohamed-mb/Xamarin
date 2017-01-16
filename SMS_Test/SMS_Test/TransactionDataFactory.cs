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
using Android.Database;

using Android.Net;
using System.Text.RegularExpressions;

namespace SMS_Test
{
    public class TransactionDataFactory
    {
        public string Data { get; set; }
        string[] containers = new[] { "payment", "Balance", "Transaction id:", "\nDate:" };
        public static IList<TransactionData> List_TransactionData= new List<TransactionData>();    
       
        public void Load()
        {
            if (Data.Contains(containers[1]))
            {
                TransactionData t = new TransactionData();
                var rs_matches = Regex.Matches(Data, @"(Rs.\d+.\d+)|(Rs.\d+)");

                if (Data.Contains(containers[0]))
                {
                    var amt = Regex.Matches("" + rs_matches[0], @"(\d+.\d+)|(\d+)");
                    var amt_str = amt[0].ToString();
                    t.Payment_Amount = Convert.ToDouble(amt_str);


                }
                if (Data.Contains(containers[1]))
                {
                    var bln = Regex.Matches("" + rs_matches[1], @"(\d+.\d+)|(\d+)");
                    t.Balance_Amount = double.Parse("" + bln[0]);
                }
                var tm = Regex.Matches(Data, @"" + containers[2] + ".+\\d+");
                var transaction_matches = Regex.Matches("" + tm[0], @"\d+");
                t.TransactionId = long.Parse("" + transaction_matches[0]);
                var dm = Regex.Matches(Data, @".?" + containers[3] + ".+");
                var date_matches = Regex.Matches("" + dm[0], @"(0[1-9]|1[0-9]|2[0-9]|3[01])/(0[1-9]|1[0-2])/2[0-9]{3}.+");
                var dt = date_matches[0].Value;
                if (dt.Length ==16)                
                    dt = dt + ":00";
                if (dt.Length == 13)
                    dt = dt + ":00:00";
                if (dt.Length == 11)
                    dt = dt + "00:00:00";
                t.Transaction_Date = DateTime.ParseExact(dt,"dd/MM/yyyy hh:mm:ss", null);
                List_TransactionData.Add(t);
            }

        }
    }
}