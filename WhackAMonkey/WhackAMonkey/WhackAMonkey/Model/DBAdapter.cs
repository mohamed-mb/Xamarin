using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhackAMonkey.Interfaces;
using Xamarin.Forms;

namespace WhackAMonkey.Model
{
    public class DBAdapter
    {
       public  static SQLiteAsyncConnection Instance { get; set; } 
        public DBAdapter()
        {
            string dbName = "monkey2.db3";
            string filePath = DependencyService.Get<IFilePathInterface>().GetFilePath(dbName);
            Instance = new SQLiteAsyncConnection(filePath);
            Instance.CreateTableAsync<Player>().Wait();
           
        }
        public async Task UpdateOrInsertRow(string name, long score)
        {
            Player player = null;         
            try
            {
                player = (await Instance.Table<Player>().Where(l => l.PlayerName == name).FirstOrDefaultAsync());
               
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            if (player == null)
            {
                player = new Player()
                {
                    PlayerName = name,
                    Score = score,
                };
                try
                {
                    await Instance.InsertAsync(player);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            else
            {

                player.PlayerName = name;
                player.Score = score;
                try
                {
                    await Instance.UpdateAsync(player);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
        }
    }
}
