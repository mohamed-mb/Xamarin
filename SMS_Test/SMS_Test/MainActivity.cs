using Android.App;
using Android.Widget;
using Android.OS;
using Android.Net;
using Android.Database;
using System.Collections.Generic;
using Android.Views;
using System;
using Android.Content;
using System.Linq;

namespace SMS_Test
{
    [Activity(Label = "SMS_Test", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        
        private TextView avaBalTextView;
        private Button tranHisButton;
        TransactionDataFactory transaction;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            ContentResolver cr = ContentResolver;
            //getting sms data
            Android.Net.Uri uri = Android.Net.Uri.Parse("content://sms/inbox");
            using (ICursor c = this.ContentResolver.Query(uri, null, null, null, null))
            {
                while (c.MoveToNext())
                {
                    var address = c.GetString(c.GetColumnIndexOrThrow("address")).ToString();
                    if (address.Equals("VK-IMONEY"))
                    {
                        transaction = new TransactionDataFactory();
                        var body = c.GetString(c.GetColumnIndexOrThrow("body")).ToString();
                        transaction.Data = body;
                        transaction.Load();

                    }                   // c.GetString(c.GetColumnIndexOrThrow("date")).ToString();                                                     


                }
            }
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            avaBalTextView = FindViewById<TextView>(Resource.Id.textView_availableBalance);
            avaBalTextView.Text="Your Available Balance is Rs."+TransactionDataFactory.List_TransactionData.First().Balance_Amount;
            tranHisButton = FindViewById<Button>(Resource.Id.button_transactionHistory);
            tranHisButton.Click += delegate {
                StartActivity(typeof(TransactionHistoryActivity));
            };
            

        }
    }
    class SMSDATA
    {
        public string Address { get; set; }
        public string Body { get; set; }
    }
   
    
}
