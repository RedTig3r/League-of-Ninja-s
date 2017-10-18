using GalaSoft.MvvmLight;
using LeagueOfNinja.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System;
using LeagueOfNinja.Model.Entities;

namespace LeagueOfNinja.ViewModel.NinjaViewModel
{
    public class NinjaVM : ViewModelBase
    {

        private Ninja _ninja;

        public int Id
        {
            get { return _ninja.NinjaId; }
            set { _ninja.NinjaId = value;  RaisePropertyChanged("Id"); }
        }

        public string Name
        {
            get { return _ninja.Name; }
            set { _ninja.Name = value; RaisePropertyChanged("Name"); }
        }

        public int Money
        {
            get { return _ninja.Money; }
            set { _ninja.Money = value; RaisePropertyChanged("Money"); }
        }

        internal Ninja ToModel()
        {
            return _ninja;
        }

       

        public NinjaVM()
        {
            this._ninja = new Ninja();
        }

        public NinjaVM(Ninja ninja)
        {
            this._ninja = ninja;
        }

    }
}
