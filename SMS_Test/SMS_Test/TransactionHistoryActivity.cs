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

namespace SMS_Test
{
    [Activity(Label = "TransactionHistoryActivity")]
    public class TransactionHistoryActivity : Activity
    {
        private ListView transHisListView;
        private IList<TransactionData> List_transData;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TransactionHistoryLayout);
            //instantiating transactionFactory
           
            List_transData = TransactionDataFactory.List_TransactionData;
            //instantiating ListView
            transHisListView = FindViewById<ListView>(Resource.Id.listView_transactionHistory);
            transHisListView.Adapter = new SMSAdapter(List_transData);

           
           
        }
    }
    class ViewHolder : Java.Lang.Object
    {
        public TextView paymentAmount_view;
        public TextView date_view { get; set; }
    }
    class SMSAdapter : BaseAdapter<TransactionData>
    {

        IList<TransactionData> sms_list;
        public SMSAdapter(IList<TransactionData> _sms_list)
        {
            sms_list = _sms_list;
        }
        public override TransactionData this[int position]
        {
            get
            {
                return sms_list[position];
            }
        }

        public override int Count
        {
            get
            {
                return sms_list.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var inflater = LayoutInflater.FromContext(parent.Context);
            var view = convertView;
            if (view == null)
            {
                view = inflater.Inflate(Resource.Layout.SMSListLayout, parent, false);
                ViewHolder vh = new ViewHolder();
                vh.paymentAmount_view = view.FindViewById<TextView>(Resource.Id.textView_paymentAmount);
                vh.date_view = view.FindViewById<TextView>(Resource.Id.textView_date);
                view.Tag = vh;
            }
            
            ((ViewHolder)view.Tag).paymentAmount_view.Text ="Payment Made:Rs."+ sms_list[position].Payment_Amount.ToString();
            ((ViewHolder)view.Tag).date_view.Text = "Date:"+sms_list[position].Transaction_Date.ToString();
            return view;
        }
    }
}