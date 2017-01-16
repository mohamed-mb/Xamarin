using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using WhackAMonkey.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ResolutionGroupName("Monkey")]
[assembly: ExportEffect(typeof(LabelEffectiOS), "LabelEffect")]
namespace WhackAMonkey.iOS
{
    public class LabelEffectiOS : PlatformEffect
    {
        UIFont oldFont;
        protected override void OnAttached()
        {
            if (Element is Label == false)
                return;
            var label = Control as UILabel;
            oldFont = label.Font;
            label.Font = UIFont.FromName("Pacifico", label.Font.PointSize);
        }

        protected override void OnDetached()
        {
            if (oldFont != null)
            {
                var label = Control as UILabel;
                label.Font = oldFont;
            }
        }
    }
}
