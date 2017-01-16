using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WhackAMonkey.Model;
using Xamarin.Forms;
using XamarinUniversity.Interfaces;
using static WhackAMonkey.App;

namespace WhackAMonkey.ViewModel
{
    public class ListViewModel:SimpleViewModel
    {
        private PlayerViewModel selectedItem;        
        public PlayerViewModel SelectedItem { get { return selectedItem;   }
            set {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    RaiseOnPropertyChanged();
                }
            }
        }
        private bool isTrueIndicator;
       

        public bool IsTrueIndicator { get
            {
                return isTrueIndicator;}
            set
            {
                if(isTrueIndicator!=value)
                {
                    isTrueIndicator = value;
                    RaiseOnPropertyChanged();
                }
            }
        }
        private ObservableCollection<PlayerViewModel> players;
        public ObservableCollection<PlayerViewModel> Players { get { return players; }
            set {
                if(players!=value)
                {
                    players = value;
                    RaiseOnPropertyChanged();
                }
            }
        }
        private ObservableCollection<Grouping<string,PlayerViewModel>> groupedPlayers;
        public ObservableCollection<Grouping<string,PlayerViewModel>> GroupedPlayers
        {
            get { return groupedPlayers; }
            set
            {
                if (groupedPlayers != value)
                {
                    groupedPlayers = value;
                    RaiseOnPropertyChanged();
                }
            }
        }
        //AllCommands
        public Command DeleteCommand { get; set; }
        public Command ChoosePlayerCommand { get; set; }
        public Command RefreshCommand { get; set; }
        public DBAdapter DB { get; set; }
        private List<Player> collection = null;
        private List<PlayerViewModel> pvm = null;
        public ListViewModel()
        {
            DB = App.DB;
            DeleteCommand = new Command<PlayerViewModel>(async (o)=>await OnDelete(o));
            ChoosePlayerCommand = new Command<PlayerViewModel>((o)=>ChoosePlayer(o));
            RefreshCommand = new Command(Rearrange);         
            
        }         
        public async Task LoadDataForPage(AppPages pageName)
        {
            IsTrueIndicator = true;
            if (pageName == AppPages.Score)
            {
                await DB.UpdateOrInsertRow(App.GameViewModel.PlayerName, App.GameViewModel.Score);

            }
            await RetrieveData();
            if(pageName==AppPages.Player)
            {
                var cx = pvm.
               OrderBy(p => p.PlayerName).
               GroupBy(p => p.PlayerName[0].ToString(), p => p)
               .Select(g => new Grouping<string, PlayerViewModel>(g.Key, g)).ToList();
               
                GroupedPlayers = new ObservableCollection<Grouping<string,PlayerViewModel>>(cx);
               SelectedItem = pvm.First();
            }
            else
            {
                Players = new ObservableCollection<PlayerViewModel>(pvm);
            }
            
        }
        private bool isRefreshing;
        public bool IsRefreshing { get { return isRefreshing; }
            set
            {
                if(isRefreshing!=value)
                {
                    isRefreshing = value;
                    RaiseOnPropertyChanged();
                }
            }
        }
        private bool isDescended = false;
        public void Rearrange(object o)
        {
          
            var ordered = isDescended ? pvm.OrderBy(p => p.PlayerName) : pvm.OrderByDescending(p => p.PlayerName);
            isDescended = !isDescended;
            var cx= ordered.GroupBy(p => p.PlayerName[0].ToString(), p => p)
               .Select(g => new Grouping<string, PlayerViewModel>(g.Key, g)).ToList();
            GroupedPlayers.Clear();
            foreach(var x in cx)
            {
                GroupedPlayers.Add(x);
            }
           // GroupedPlayers = new ObservableCollection<Grouping<string, PlayerViewModel>>(cx);
            SelectedItem = ordered.First();
            
            IsRefreshing = false;
        }
        public void ChoosePlayer(PlayerViewModel e)
        {
            SelectedItem = e;
            App.GameViewModel.PlayerName = SelectedItem.PlayerName;
            App.GameViewModel.Score = SelectedItem.Score;
            DependencyService.Get<INavigationService>().GoBackAsync();

        }
        public async Task OnDelete(PlayerViewModel pvm)
        {
            Player p = pvm.Player;
            await DBAdapter.Instance.DeleteAsync(p);
            //var groupedPlayer = GroupedPlayers.SelectMany(x=>x);
            for (int i = GroupedPlayers.Count-1; i >= 0; i--)
            {
                var groupedPlayer = GroupedPlayers[i];
                for (int j = groupedPlayer.Count-1; j >=0 ; j--)
                {
                    var playerViewModel = groupedPlayer[j];
                    if (playerViewModel.PlayerName == pvm.PlayerName)
                    {
                        groupedPlayer.Remove(playerViewModel);
                        break;
                    }
                }
                if (!groupedPlayer.Any()) { GroupedPlayers.Remove(groupedPlayer); break; }
            }

        }

        public async Task RetrieveData()
        {
           
            try
            {
                
                collection = await DBAdapter.Instance.Table<Player>().ToListAsync();
                IsTrueIndicator = false;
                if (collection == null)
                {
                    collection = new List<Player>();
                    collection.Add(new Player()
                    {
                        PlayerName = "Ali",
                        Score = 30
                    });
                }
                pvm = collection.Select(p => new PlayerViewModel(p)).
                    OrderByDescending(p => p.Score).
                    ToList();        
             }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            
        }
    }
}
