using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinja.ViewModel.NinjaViewModel
{
    public class UpdateNinjaVM : ViewModelBase
    {


        private NinjaListVM _ninjaListVM;

        public UpdateNinjaVM(NinjaListVM ninjaListVM)
        {
            this._ninjaListVM = ninjaListVM;
        }

    }
}
