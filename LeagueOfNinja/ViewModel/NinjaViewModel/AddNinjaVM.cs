using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinja.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LeagueOfNinja.ViewModel.NinjaViewModel
{
    public class AddNinjaVM : ViewModelBase
    {

        private NinjaListVM _ninjaListVM;

        public NinjaVM NinjaVM { get; set; }

        public ICommand AddNinjaICommand { get; set; }

        public AddNinjaVM(NinjaListVM ninjaListVM)
        {
            this._ninjaListVM = ninjaListVM;
            this.NinjaVM = new NinjaVM();
            AddNinjaICommand = new RelayCommand(AddNinja, CanAddNinja);
        }

        private void AddNinja()
        {
            using (var context = new NinjaEntities())
            {
                context.Ninjas.Add(NinjaVM.ToModel());
                context.SaveChanges();
            }

            _ninjaListVM.HideAddNinja();
        }

        private bool CanAddNinja()
        {
            return true;
        }
    }
}
