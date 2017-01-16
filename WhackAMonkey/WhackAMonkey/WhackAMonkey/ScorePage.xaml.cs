using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhackAMonkey.ViewModel;
using Xamarin.Forms;
using static WhackAMonkey.App;

namespace WhackAMonkey
{
    public partial class ScorePage : ContentPage
    {
        public ScorePage()
        {
           ListViewModel lvm = new ListViewModel();            
            BindingContext = lvm;
            InitializeComponent();
            
            lvm.LoadDataForPage(AppPages.Score).ContinueWith((t)=> {
                Debug.WriteLine("rrrrrrrrrrrrrrrrr"+t.Exception.ToString());                
            },TaskContinuationOptions.OnlyOnFaulted);
           
                        
        }
    }
}
