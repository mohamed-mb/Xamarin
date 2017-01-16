using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhackAMonkey.ViewModel;
using Xamarin.Forms;

namespace WhackAMonkey
{
    public partial class MonkeyPlayground : ContentPage
    {
        public GameViewModel GameVM { get; set; }
        public MonkeyPlayground()
        {
            GameVM = App.GameViewModel;
            GameVM.Setup();
            BindingContext = GameVM;          
            InitializeComponent();
            //Creating Grid of Images
            var counter = 0;
            var row = 2;   
            for (var rowCount = 0; rowCount < 4; rowCount++)
            {
                var col = 0;
                for (var colCount = 0; colCount < 4; colCount++, col++)
                {
                    var imgBinding = new Binding();
                    imgBinding.Source = GameVM;
                    imgBinding.Path = "PlaygroundImages["+counter+"]";

                    var tapGesture = new TapGestureRecognizer();
                    tapGesture.SetBinding(TapGestureRecognizer.CommandProperty, "ImageTappedCommand");
                   
                   
                    var img = new Image()
                    {
                        Style = (Style)this.Resources["ImageStyle"],
                        
                    };                   
                    img.SetBinding(Image.SourceProperty, imgBinding);
                    tapGesture.CommandParameter =img ;
                    img.GestureRecognizers.Add(tapGesture);
                    playgroundGrid.Children.Add(img, col, row);
                   
                    counter++;
                }
                row++;
            }
            

        }       
        
    }
}
