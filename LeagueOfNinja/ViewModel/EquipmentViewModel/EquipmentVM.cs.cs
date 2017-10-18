using GalaSoft.MvvmLight;
using LeagueOfNinja.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinja.ViewModel.EquipmentViewModel
{
    public class EquipmentVM : ViewModelBase
    {

        private Equipment _equipment;

        public string Title
        {
            get { return _equipment.Title; }
            set { _equipment.Title = value; RaisePropertyChanged("Title"); }
        }
        public int Price
        {
            get { return _equipment.Price; }
            set { _equipment.Price = value; RaisePropertyChanged("Price"); }
        }
        public int Strength
        {
            get { return _equipment.Strength; }
            set { _equipment.Strength = value; RaisePropertyChanged("Strength"); }
        }
        public int Intelligence
        {
            get { return _equipment.Intelligence; }
            set { _equipment.Intelligence = value; RaisePropertyChanged("Intelligence"); }
        }
        public int Agility
        {
            get { return _equipment.Agility; }
            set { _equipment.Agility = value; RaisePropertyChanged("Agility"); }
        }
        public string Type
        {
            get { return _equipment.Type; }
            set { _equipment.Type = value; RaisePropertyChanged("Type"); }
        }

        internal Equipment ToModel()
        {
            return _equipment;
        }

        public EquipmentVM()
        {
            this._equipment = new Equipment();
        }

        public EquipmentVM(Equipment equipment)
        {
            this._equipment = equipment;
        }

    }
}
