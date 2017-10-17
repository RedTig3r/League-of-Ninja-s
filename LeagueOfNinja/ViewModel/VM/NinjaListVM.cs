using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinja.ViewModel.VM
{
    public class NinjaListVM : ViewModelBase
    {
        private AddNinjaWindow _addNinjaWindow;

        public ObservableCollection<NinjaVM> Ninjas { get; set; }

        private NinjaVM _selectedNinja;


    }
}
