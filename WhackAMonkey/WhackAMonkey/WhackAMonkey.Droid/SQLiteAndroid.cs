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
using SQLite;
using WhackAMonkey.Interfaces;
using System.IO;
using WhackAMonkey.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteAndroid))]
namespace WhackAMonkey.Droid
{
    public class SQLiteAndroid: IFilePathInterface
    {
        public string GetFilePath(string dbName)
        {
            string docPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string filePath = Path.Combine(docPath, dbName);            
            return filePath;
        }
    }
}