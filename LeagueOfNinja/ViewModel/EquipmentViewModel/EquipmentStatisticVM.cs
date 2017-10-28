using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinja.ViewModel
{
    class EquipmentStatisticVM : ViewModelBase
    {
        private EquipmentStatisticVM _equipmentStatistic;

        public EquipmentStatisticVM()
        {
            this._equipmentStatistic = new EquipmentStatisticVM();
        }

        public EquipmentStatisticVM(EquipmentStatisticVM equipmentStatistic)
        {
            this._equipmentStatistic = equipmentStatistic;
        }
        internal EquipmentStatisticVM ToModel()
        {
            return _equipmentStatistic;
        }


        public string EquipmentType
        {
            get { return _equipmentStatistic.EquipmentType; }
            set { _equipmentStatistic.EquipmentType = value.ToString(); RaisePropertyChanged("EquipmentType"); }
        }


    }
}
