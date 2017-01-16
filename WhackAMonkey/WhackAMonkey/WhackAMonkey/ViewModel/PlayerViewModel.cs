using WhackAMonkey.Model;

namespace WhackAMonkey.ViewModel
{
    public class PlayerViewModel:SimpleViewModel
    {
        public Player Player { get; set; }       
        public string PlayerName { get { return Player.PlayerName;}
            set {
                if (Player.PlayerName != value)
                {
                    Player.PlayerName = value;
                    RaiseOnPropertyChanged();
                }
            }
        }
        public long Score { get { return Player.Score; }
            set {
                if (Player.Score != value)
                {
                    Player.Score = value;
                    RaiseOnPropertyChanged();
                }
            }
        }
        public PlayerViewModel(Player  _player)
        {
            Player = _player;
        }
    }
}
