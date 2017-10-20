using GalaSoft.MvvmLight;
using LeagueOfNinja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinja.ViewModel.InventoryViewModel
{
    public class InventoryVM : ViewModelBase
    {

        private InventoryItem _inventoryItem;


        public InventoryVM()
        {
            this._inventoryItem = new InventoryItem();
        }

        public InventoryVM(InventoryItem inventory)
        {
            this._inventoryItem = inventory;
        }


        internal InventoryItem ToModel()
        {
            return _inventoryItem;
        }


        public bool IsUsingEquitment
        {
            get { return _inventoryItem.IsUsingEquitment; }
            set { _inventoryItem.IsUsingEquitment = value; RaisePropertyChanged("IsUsingEquitment"); }
        }



    }
}
