using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinja.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using LeagueOfNinja.View;
using LeagueofNinja.Model;
using LeagueofNinja.Model.Repository;

namespace LeagueOfNinja.ViewModel.NinjaViewModel
{
    public class NinjaListVM : ViewModelBase
    {
        private AddNinjaVM _addNinjaWindow;

        INinjaRepository ninjaRepo;

        public ObservableCollection<NinjaVM> Ninjas { get; set; }
                
        private NinjaVM _selectedNinja;

        public NinjaVM SelectedNinja
        {
            get { return _selectedNinja; }
            set
            {
                _selectedNinja = value;
                base.RaisePropertyChanged();
            }
        }

        //Commands
        public ICommand ShowAddNinjaCommand { get; set; }
        public ICommand ShowUpdateNinjaCommand { get; set; }        
        public ICommand DeleteNinjaCommand { get; set; }

        public NinjaListVM()
        {
            ninjaRepo = new NinjaRepository();
            var ninjaList = ninjaRepo.GetNinjas().Select(s => new NinjaVM(s));
            Ninjas = new ObservableCollection<NinjaVM>(ninjaList);


        }

        public void ShowUpdateNinja()
        {
            var updateNinja = new UpdateNinjaWindow();
            updateNinja.Show();
        }

        public void ShowAddNinja()
        {
            //_addNinjaWindow = new AddNinjaWindow();
            //_addNinjaWindow.Show();
        }

        public bool CanShowAddNinja()
        {
            //return _addNinjaWindow != null ? !_addNinjaWindow.IsVisible : true;
            return true;
        }

        public void HideAddNinja()
        {
          //_addNinjaWindow.Close();
        }

        private void DeleteNinja()
        {
            Ninjas.Remove(SelectedNinja);
        }

    }
}
