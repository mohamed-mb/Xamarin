using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using WhackAMonkey.Interfaces;
using System.IO;
using Xamarin.Forms;
using WhackAMonkey.iOS;

[assembly: Dependency(typeof(SQLiteIOs))]
namespace WhackAMonkey.iOS
{
    public class SQLiteIOs : IFilePathInterface
    {
        public string GetFilePath(string dbName)
        {
            string docpath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string path = Path.Combine(docpath, "..", "Library");
            string dbpath = Path.Combine(path, dbName);
            return dbpath;

        }
    }
}
