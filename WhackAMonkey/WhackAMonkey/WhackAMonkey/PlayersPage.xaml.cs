using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhackAMonkey.Model;
using WhackAMonkey.ViewModel;
using Xamarin.Forms;

namespace WhackAMonkey
{
    public partial class PlayersPage : ContentPage
    {
        public ListViewModel lvm { get; set; }
        public PlayersPage()
        {
            lvm = new ListViewModel(); 
            BindingContext = lvm;            
            InitializeComponent();
            lvm.LoadDataForPage(App.AppPages.Player).ContinueWith((t) => {
                Debug.WriteLine("rrrrrrrrrrrrrrrrr" + t.Exception.ToString());
            }, TaskContinuationOptions.OnlyOnFaulted); ;
            
            
        }
       
    }
}
