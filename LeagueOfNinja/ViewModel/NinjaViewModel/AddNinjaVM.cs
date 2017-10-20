using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinja.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LeagueOfNinja.ViewModel.NinjaViewModel
{
    public class AddNinjaVM : ViewModelBase
    {

        private NinjaListVM _ninjaListVM;

        public NinjaVM Ninja { get; set; }

        public ICommand AddNinjaICommand { get; set; }

        public AddNinjaVM(NinjaListVM ninjaListVM)
        {
            this._ninjaListVM = ninjaListVM;
            this.Ninja = new NinjaVM();
            AddNinjaICommand = new RelayCommand(AddNinja, CanAddNinja);
        }

        private void AddNinja()
        {
            var ninja = Ninja.ToModel();
            ninja.Money = 0;
            using (var context = new NinjaEntities())
            {
          
                context.Ninjas.Add(ninja);
                context.SaveChanges();             
            }

            _ninjaListVM.NinjasOC.Add(Ninja);
            _ninjaListVM.HideAddNinja();
        }

        private bool CanAddNinja()
        {
            return true;
        }
    }
}
