using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhackAMonkey.ViewModel;
using Xamarin.Forms;

namespace WhackAMonkey
{
    public partial class AboutPage : ContentPage
    {
        public GameViewModel GVM { get; set; }
        public AboutPage()
        {
            GVM = App.GameViewModel;
            BindingContext = GVM;
            InitializeComponent();
        }
    }
}
