using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinja.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using LeagueOfNinja.View;
using System.Data.Entity;

namespace LeagueOfNinja.ViewModel.EquipmentViewModel
{
    public class EquipmentListVM : ViewModelBase
    {
        private AddEquipmentWindow _addEquipmentWindow;

        private UpdateEquipmentWindow _updateEquipmentWindow;

        private NinjaWindow _ninjaWindow;

        private EquipmentVM _selectedEquipment;

        public ObservableCollection<EquipmentVM> EquipmentsOC { get; set; }

        //Commands
        public ICommand ShowAddEquipmentCommand { get; set; }
        public ICommand ShowUpdateEquipmentCommand { get; set; }
        public ICommand DeleteEquipmentCommand { get; set; }
        public ICommand ShowNinjasCommand { get; set; }

        public EquipmentListVM()
        {
            using (var context = new NinjaEntities())
            {
                var equipments = context.Equipments.ToList();
                EquipmentsOC = new ObservableCollection<EquipmentVM>(equipments.Select(r => new EquipmentVM(r)));
            }

            ShowAddEquipmentCommand = new RelayCommand(ShowAddEquipment, CanShowAddEquipment);
            ShowUpdateEquipmentCommand = new RelayCommand(ShowUpdateEquipment, CanUpdateEquipment);
            DeleteEquipmentCommand = new RelayCommand(DeleteEquipment);

            ShowNinjasCommand = new RelayCommand(ShowNinjas);

        }

        public EquipmentVM SelectedEquipment
        {
            get { return _selectedEquipment; }
            set
            {
                _selectedEquipment = value;
                base.RaisePropertyChanged();
            }
        }

        //---  Create ---

        public void ShowAddEquipment()
        {
            _addEquipmentWindow = new AddEquipmentWindow();
            _addEquipmentWindow.Show();
        }

        public bool CanShowAddEquipment()
        {
            return _addEquipmentWindow != null ? !_addEquipmentWindow.IsVisible : true;
        }


        public void HideAddEquipment()
        {
            _addEquipmentWindow.Close();
        }



        //--- Update ---

        public void ShowUpdateEquipment()
        {
            _updateEquipmentWindow = new UpdateEquipmentWindow();
            _updateEquipmentWindow.Show();
        }


        public bool CanUpdateEquipment()
        {
            return _addEquipmentWindow != null ? !_addEquipmentWindow.IsVisible : true;
        }



        public void HideUpdateEquipment()
        {
            _updateEquipmentWindow.Close();
        }

        //--- Ninjas ---
        public void ShowNinjas()
        {
            _ninjaWindow = new NinjaWindow();
            _ninjaWindow.Show();
        }


        //--- Delete ---

        private void DeleteEquipment()
        {

            using (var context = new NinjaEntities())
            {
                var equipment = SelectedEquipment.ToModel();

                context.Entry(equipment).State = EntityState.Deleted;
                context.SaveChanges();
            }

            EquipmentsOC.Remove(SelectedEquipment);

        }


    }
}
