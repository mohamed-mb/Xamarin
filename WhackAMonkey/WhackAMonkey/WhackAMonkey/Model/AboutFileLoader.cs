using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WhackAMonkey.Model
{
    public class AboutFileLoader
    {
        public string About { get; set; }
        public AboutFileLoader()
        {
            var assembly= typeof(AboutFileLoader).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("WhackAMonkey.About.txt");
            using (var reader = new System.IO.StreamReader(stream))
            {
                About = reader.ReadToEnd();
            }
        }
    }
}
