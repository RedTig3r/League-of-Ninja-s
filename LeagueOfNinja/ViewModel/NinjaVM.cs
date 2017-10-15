using GalaSoft.MvvmLight;
using LeagueOfNinja.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LeagueOfNinja.ViewModel
{
    public class NinjaVM : ViewModelBase
    {

        private Ninja _ninja;

        public int Id
        {
            get { return _ninja.Id; }
            set { _ninja.Id = value;  RaisePropertyChanged("Id"); }
        }

        public string Name
        {
            get { return _ninja.Name}
            set { _ninja.Name = value; RaisePropertyChanged("Name"); }
        }

        public int Gold
        {
            get { return _ninja.Gold; }
            set { _ninja.Gold = value; RaisePropertyChanged("Gold"); }
        }
        
    }
}
