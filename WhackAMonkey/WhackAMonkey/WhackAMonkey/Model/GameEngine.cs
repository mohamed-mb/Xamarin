using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhackAMonkey.ViewModel;
using Xamarin.Forms;
using XamarinUniversity.Interfaces;
using XamarinUniversity.Services;
using static WhackAMonkey.App;

namespace WhackAMonkey.Model
{
    public class GameEngine
    {     
        public GameViewModel Game { get; set; }
        public Player player { get; set; }
        //public DBAdapter DB { get; set; }
        private Random random;
        private bool IsEnd;
        public event EventHandler Problems = delegate { };      
        public Task UpdateTask { get; set; }
        public GameEngine(GameViewModel _game)
        {
            Game = _game;
            random = new Random();
            Game.Level = 1;
           // DB = new DBAdapter();
           
            IsRestart = false;
            IsEnd = false;

        }
        public void Setup()
        {
            AssignMonkeyImages(Game.Level);
            ReshuffleMonkeyImages();
        }
        public async void OnStop()
        {
           var messgService = DependencyService.Get<IMessageVisualizerService>() as FormsMessageVisualizerService;
            if (await messgService.ShowMessage("EndGame!!", "Sure You want to EndGame?", "Yes", "No"))
           {
            IsEnd = true;            
            }              
        }
        private bool IsRestart;
        public void OnRestart()
        {
            IsRestart = true;           
        }
        public void AssignMonkeyImages(int level)
        {
           
            for (int counter1 = 0; counter1 < 4-level; counter1++)
            { Game.MonkeyImages.Add("monkey.png"); }
            for (int counter2 = 0; counter2 < 12+level; counter2++)
            { Game.MonkeyImages.Add("icon.png"); }
         }
        public void CalculateScore(string imageName)
        {
            if (imageName == "monkey.png")
            {
                var s = 1;
                Game.Score = Game.Score + s * Game.Level;
                Game.IsHit = true;
                Game.Status = "Hit";
            }
            else
            {
                Game.IsHit = false;
                Game.Status = "Miss";
            }
        }
        public void StartGame()
        {
            GameEnded += GameEndedEventHandler;
            Game.Timer = 5;
            Game.Status = "Welcome";
            Device.StartTimer(TimeSpan.FromSeconds(2), StartTimer);
            
        }
        private void GameEndedEventHandler(object o,EventArgs e)
        {
            var messgService = DependencyService.Get<IMessageVisualizerService>() as FormsMessageVisualizerService;
            Device.BeginInvokeOnMainThread(async () => {
                if (await messgService.ShowMessage("GameOver!!", "You want a NewGame?", "Yes", "No"))
                {
                    GameEnded -= GameEndedEventHandler;
                    StartGame();
                }
                else
                {
                    GameEnded -= GameEndedEventHandler;
                    MoveToNextPage();
                }
            });
        }
        public event EventHandler GameEnded = delegate { };
        private bool StartTimer()
        {
            if (IsRestart)
            {
                Game.Timer = 5;
                IsRestart = false;
            }
            Game.Timer--;
            if (Game.Timer >0 && IsEnd == false)
            {
                ReshuffleMonkeyImages();
                return true;
            }
            else
            {
                Task.Run(()=>GameEnded(null,null));                                       
                return false;
            }

        }
        private void MoveToNextPage()
        {
            
            DependencyService.Get<INavigationService>()         
                .PushModalAsync(AppPages.Score);
        }
       
        public void ReshuffleMonkeyImages()
        {
            Game.MonkeyImages = Game.MonkeyImages.OrderBy(item => random.Next()).ToList();
        }
    }
    
}
