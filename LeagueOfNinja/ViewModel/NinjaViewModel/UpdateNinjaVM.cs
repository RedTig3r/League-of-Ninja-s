using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Data.Entity;

namespace LeagueOfNinja.ViewModel.NinjaViewModel
{
    public class UpdateNinjaVM : ViewModelBase
    {
        private NinjaListVM _ninjaListVM;

        public NinjaVM NinjaVM { get; set; }

        public ICommand UpdateNinjaICommand { get; set; }

        public UpdateNinjaVM(NinjaListVM ninjaListVM)
        {
            this._ninjaListVM = ninjaListVM;
            this.NinjaVM = _ninjaListVM.SelectedNinja;
            UpdateNinjaICommand = new RelayCommand(UpdateNinja, CanUpdateNinja);
        }

        private void UpdateNinja()
        {
            using (var context = new NinjaEntities())
            {

                var ninja = NinjaVM.ToModel();

                context.Entry(ninja).State = EntityState.Modified;
                context.SaveChanges();


            }

            _ninjaListVM.HideUpdateNinja();
        }

        private bool CanUpdateNinja()
        {
            return true;
        }

    }
}
