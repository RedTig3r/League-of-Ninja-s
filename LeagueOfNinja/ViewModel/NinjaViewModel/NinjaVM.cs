using GalaSoft.MvvmLight;
using LeagueOfNinja.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System;
using System.Collections.ObjectModel;
using LeagueOfNinja.ViewModel.EquipmentViewModel;

namespace LeagueOfNinja.ViewModel
{
    public class NinjaVM : ViewModelBase
    {

        private Ninja _ninja;

        public ObservableCollection<EquipmentVM> InventoryItems { get; set; }

        public NinjaVM()
        {
            this._ninja = new Ninja();
        }

        public NinjaVM(Ninja ninja)
        {
            this._ninja = ninja;            
        }


        internal Ninja ToModel()
        {
            return _ninja;
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



   

 

    }
}
