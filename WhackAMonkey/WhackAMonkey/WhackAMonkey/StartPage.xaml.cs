using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhackAMonkey.ViewModel;
using Xamarin.Forms;

namespace WhackAMonkey
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            var gvm = App.GameViewModel;
            BindingContext = gvm;
            InitializeComponent();
        }
      
    }
}
