using GalaSoft.MvvmLight;
using LeagueOfNinja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinja.ViewModel
{
    public class EquipmentVM : ViewModelBase
    {

        private Equipment _equipment;

        public EquipmentVM()
        {
            this._equipment = new Equipment();
        }

        public EquipmentVM(Equipment equipment)
        {
            this._equipment = equipment;
        }
        internal Equipment ToModel()
        {
            return _equipment;
        }




        public int EquipmentId
        {
            get { return _equipment.EquipmentId; }
            set { _equipment.EquipmentId = value; RaisePropertyChanged("EquipmentId"); }
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
      
        public string EquipmentType
        {
            get { return _equipment.EquipmentType; }
            set { _equipment.EquipmentType = value.ToString(); RaisePropertyChanged("EquipmentType"); }
        }

  


       }      

    }

