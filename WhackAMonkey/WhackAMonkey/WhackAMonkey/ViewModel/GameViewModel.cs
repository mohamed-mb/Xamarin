using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using WhackAMonkey.Model;
using Xamarin.Forms;
using XamarinUniversity.Interfaces;
using XamarinUniversity.Services;
using static WhackAMonkey.App;

namespace WhackAMonkey.ViewModel
{
    public class GameViewModel:SimpleViewModel
    {
        public  GameEngine GameEngine { get; set; }
        public Game  Game { get; set; }
        public AboutFileLoader Abt { get; set; }
        //All the commands
        public Command EndGameCommand { get; set; }
        public Command RestartButtonCommand { get; set; }
        public Command GoButtonCommand { get; set; }
        public Command OldPlayerButtonCommand { get; set; }
        public Command ImageTappedCommand { get; set; }
        public Command AboutTapped { get; set; }
        //All the public properties reflecting Model
        private List<Player> oldPlayers;
        public List<Player> OldPlayers {
            get { return oldPlayers; }

            set {
                if(oldPlayers!=value)
                {
                    oldPlayers = value;
                    RaiseOnPropertyChanged();
                }
            }
        }
        public string About { get { return Abt.About; }
            set
            {
                if (Abt.About != value)
                {
                    Abt.About = value;
                    RaiseOnPropertyChanged();
                }
            }
        }
        public bool IsHit { get { return Game.IsHit; }
            set {
                 if(Game.IsHit!=value)
                 {
                       Game.IsHit = value;
                       RaiseOnPropertyChanged();
                 }
                }
        }        
        public List<string> MonkeyImages {
            get { return Game.MonkeyImages; }
            set
            {
                if(Game.MonkeyImages!=value)
                {
                    Game.MonkeyImages = value;
                    RaiseOnPropertyChanged();
                    RaiseOnPropertyChanged("PlaygroundImages");
                }
            } }
        public string[] PlaygroundImages { get {
                
               return MonkeyImages.ToArray();
            }     
        }        
        public string PlayerName { get { return Game.PlayerName; }
            set
            {
                if(Game.PlayerName!=value)
                {
                    var canExecute = GoButtonCommand.CanExecute(null);
                    Game.PlayerName = value;
                    RaiseOnPropertyChanged();

                    if (canExecute != GoButtonCommand.CanExecute(null))
                    GoButtonCommand.ChangeCanExecute();
                   
                }
            }
        }
        public int Level { get { return Game.Level; }
            set
            {
                if(Game.Level!=value)
                {
                    Game.Level = value;
                    RaiseOnPropertyChanged();
                }
            }
        }
        public long Score {
            get
            { return Game.Score; }  
            set
            {
                if (Game.Score != value)
                {
                    Game.Score = value;
                    RaiseOnPropertyChanged();
                   
                }
            }
        }       
        public string Status {
           get { return Game.Status; }
            set
            {
                if(Game.Status!=value)
                {
                    Game.Status = value;
                    RaiseOnPropertyChanged();
                }
            }
        }
        public int Timer {
            get { return Game.Timer; }
            set {
                    if(Game.Timer!=value)
                    {
                      Game.Timer =value;
                      RaiseOnPropertyChanged();
                    }
            }
        }
        public GameViewModel()
        {
           
            Abt = new AboutFileLoader();
            Game = new Game();
            GameEngine = new GameEngine(this);
           /*Question: What is the use of View Model, is it just an Abstraction?
            * Reason: Model consists of both Data and Logic,ex Game and GameEngine
            * I can manipulate my Game class in GameEngine directly, 
            * if so i can write PropertyChangedNotification in my model directly
            * I dont have to use ViewModel to write them            * 
            
           */
            RestartButtonCommand = new Command(OnRestartButtonClicked);
            GoButtonCommand = new Command(OnGoButtonClicked,CanGo);
            ImageTappedCommand = new Command<Image>(o=>TapImage(o));
            AboutTapped = new Command(AboutTap);
            OldPlayerButtonCommand = new Command(OldPlayerButtonTapped);
            EndGameCommand = new Command(OnEnd);
            
        }
        public void OnEnd(Object sender)
        {
            GameEngine.OnStop();
        }
        public void OldPlayerButtonTapped(object sender)
        {
            DependencyService.Get<INavigationService>().NavigateAsync(AppPages.Player);
        }
        public bool CanGo(object sender)
        {
            if (string.IsNullOrEmpty(PlayerName))
            {
                return false;
            }
            return true; 
        }
        public void AboutTap()
        {
            DependencyService.Get<INavigationService>().NavigateAsync(AppPages.About);
        }
        public  void TapImage(object sender)
        {
            Image img = (Image)sender;
            ImageSource ims = img.Source;
            var name = "" + ims.GetValue(FileImageSource.FileProperty);
           
            GameEngine.CalculateScore(name);
        }
        public void Setup()
        {
            GameEngine.Setup();            
        }   
        public void StartGame()
        {
            GameEngine.StartGame();           
        }

        public async void OnGoButtonClicked(object sender)
        {
            await DependencyService.Get<INavigationService>().PushModalAsync(AppPages.Playground);
            StartGame();
        }
        private void OnRestartButtonClicked(object sender)
        {
            GameEngine.OnRestart();
        }
    }
}
