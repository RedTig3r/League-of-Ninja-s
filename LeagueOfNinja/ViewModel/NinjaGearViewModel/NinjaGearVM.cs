using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinja.ViewModel
{
    public class NinjaGearVM : ViewModelBase
    {
        private InventoryListVM _inventoryListVM;

        public NinjaGearVM(InventoryListVM inventoryListVM)
        {
            this._inventoryListVM = inventoryListVM;
        }
    }
}
