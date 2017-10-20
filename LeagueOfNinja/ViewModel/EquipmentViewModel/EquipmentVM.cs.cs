using GalaSoft.MvvmLight;
using LeagueOfNinja.Model;
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


        public int EquipmentId
        {
            get { return _equipment.EquitmentId; }
            set { _equipment.EquitmentId = value; RaisePropertyChanged("EquitmentId"); }
        }

        public string Name
        {
            get { return _equipment.Name; }
            set { _equipment.Name = value; RaisePropertyChanged("Name"); }
        }
        public int EquipmentValue
        {
            get { return _equipment.EquipmentValue; }
            set { _equipment.EquipmentValue = value; RaisePropertyChanged("EquipmentValue"); }
        }
      
        public string EquitmentType
        {
            get { return _equipment.EquitmentType; }
            set { _equipment.EquitmentType = value; RaisePropertyChanged("EquitmentType"); }
        }

        public int ShopId
        {
            get { return _equipment.ShopId; }
            set { _equipment.ShopId = value; RaisePropertyChanged("ShopId"); }
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
