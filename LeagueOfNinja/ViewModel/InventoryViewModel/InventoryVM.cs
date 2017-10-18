using GalaSoft.MvvmLight;
using LeagueOfNinja.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinja.ViewModel.InventoryViewModel
{
    public class InventoryVM : ViewModelBase
    {

        private Inventory _inventory;

        internal Inventory ToModel()
        {
            return _inventory;
        }

        public InventoryVM()
        {
            this._inventory = new Inventory();
        }

        public InventoryVM(Inventory inventory)
        {
            this._inventory = inventory;
        }

    }
}
