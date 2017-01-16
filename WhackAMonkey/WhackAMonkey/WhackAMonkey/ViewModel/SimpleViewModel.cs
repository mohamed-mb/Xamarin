using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WhackAMonkey.ViewModel
{
    public class SimpleViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged=delegate { };

        public void RaiseOnPropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
        }
    }
}
