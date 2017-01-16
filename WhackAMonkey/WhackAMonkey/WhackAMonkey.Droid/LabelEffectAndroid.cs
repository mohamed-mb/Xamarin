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
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using WhackAMonkey.Droid;

[assembly:ResolutionGroupName("Monkey")]
[assembly:ExportEffect(typeof(LabelEffectAndroid),"LabelEffect")]
namespace WhackAMonkey.Droid
{
    public class LabelEffectAndroid : PlatformEffect
    {
        Typeface oldFont;
        
        protected override void OnAttached()
        {
            if (Element is Label == false)
                return;
            var label = Control as TextView;
           
            oldFont = label.Typeface;
            var font = Typeface.CreateFromAsset(Forms.Context.Assets, "Pacifico.ttf");
            label.Typeface = font;
           
            
        }

        protected override void OnDetached()
        {
            var label = Control as TextView;
            if (oldFont!=null)
            {              
                label.Typeface = oldFont;
            }
           
        }
    }
}