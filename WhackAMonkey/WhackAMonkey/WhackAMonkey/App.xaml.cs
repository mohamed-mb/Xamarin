using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhackAMonkey.Model;
using WhackAMonkey.ViewModel;
using Xamarin.Forms;
using XamarinUniversity.Interfaces;
using XamarinUniversity.Services;

namespace WhackAMonkey
{
    public partial class App : Application
    {
        public static GameViewModel GameViewModel { get; set; }
        public static DBAdapter DB { get; set; }
        

        public enum AppPages
        {
            About,
            Start,
            Score,
            Player,
            Playground,
            Result
        }
        static App()
        {
            // Register dependencies.
           // DependencyService.Register<GameViewModel>();
            // Register standard XamU services
            XamUInfrastructure.Init();
        }
        public App()
        {
            InitializeComponent();
            DB = new DBAdapter();         
            GameViewModel = new GameViewModel();
            
            MainPage = new MainNavigationPage(new StartPage());
           
            //
            //new MonkeyPlayground();
            //new WhackAMonkey.MainPage();

            var navservice = DependencyService.Get<INavigationService>() as FormsNavigationPageService;
            navservice.RegisterPage(AppPages.Playground, () => new MonkeyPlayground());
            navservice.RegisterPage(AppPages.About, () => new AboutPage());
            navservice.RegisterPage(AppPages.Score, () => new ScorePage());
            navservice.RegisterPage(AppPages.Player, () => new PlayersPage());

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
