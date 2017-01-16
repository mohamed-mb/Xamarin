using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using WhackAMonkey.ViewModel;
using Xamarin.Forms;

namespace WhackAMonkey
{
    public class MainNavigationPage : NavigationPage
    {
        
        public MainNavigationPage(Page root):base(root)
        {
            App.GameViewModel.GameEngine.Problems += (s, e) =>
            {
                this.DisplayAlert("Error", "Database not updated", "OK");
            };
        }
        public MainNavigationPage():base()
        {
                
        }
    }
}
