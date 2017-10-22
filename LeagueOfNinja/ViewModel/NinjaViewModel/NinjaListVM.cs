using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinja.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using LeagueOfNinja.View;
using System.Data.Entity;

namespace LeagueOfNinja.ViewModel.NinjaViewModel
{
    public class NinjaListVM : ViewModelBase
    {
        private AddNinjaWindow _addNinjaWindow;

        private UpdateNinjaWindow _updateNinjaWindow;

        private InventoryWindow _inventoryWindow;

        private EquipmentWindow _equipmentWindow;

        private NinjaVM _selectedNinja;

        public ObservableCollection<NinjaVM> NinjasOC { get; set; }

        //Commands
        public ICommand ShowAddNinjaCommand { get; set; }
        public ICommand ShowUpdateNinjaCommand { get; set; }
        public ICommand DeleteNinjaCommand { get; set; }
        public ICommand ShowInventoryCommand { get; set; }
        public ICommand ShowEquipmentsCommand { get; set; }


        public NinjaListVM()
        {
            using (var context = new NinjaEntities())
            {

                var ninjas = context.Ninjas.ToList();
                NinjasOC = new ObservableCollection<NinjaVM>(ninjas.Select(r => new NinjaVM(r)));
            }

            ShowAddNinjaCommand = new RelayCommand(ShowAddNinja, CanShowAddNinja);
            ShowUpdateNinjaCommand = new RelayCommand(ShowUpdateNinja, CanUpdateNinja);
            DeleteNinjaCommand = new RelayCommand(DeleteNinja);

            ShowInventoryCommand = new RelayCommand(ShowInventory);

            ShowEquipmentsCommand = new RelayCommand(ShowEquipements);
        }


        public NinjaVM SelectedNinja
        {
            get { return _selectedNinja; }
            set
            {
                _selectedNinja = value;
                base.RaisePropertyChanged();
            }
        }

        //---  Create ---

        public void ShowAddNinja()
        {
            _addNinjaWindow = new AddNinjaWindow();
            _addNinjaWindow.Show();
        }

        public bool CanShowAddNinja()
        {
            return _addNinjaWindow != null ? !_addNinjaWindow.IsVisible : true;
        }


        public void HideAddNinja()
        {
            _addNinjaWindow.Close();
        }



        //--- Update ---

        public void ShowUpdateNinja()
        {
            _updateNinjaWindow = new UpdateNinjaWindow();
            _updateNinjaWindow.Show();
        }


        public bool CanUpdateNinja()
        {
            return _addNinjaWindow != null ? !_addNinjaWindow.IsVisible : true;
        }



        public void HideUpdateNinja()
        {
            _updateNinjaWindow.Close();
        }


        //--- Inventory ---

        public void ShowInventory()
        {
            _inventoryWindow = new InventoryWindow();
            _inventoryWindow.Show();
        }

        //--- Equipments ---

        public void ShowEquipements()
        {
            _equipmentWindow = new EquipmentWindow();
            _equipmentWindow.Show();
        }


        //--- Delete ---

        private void DeleteNinja()
        {    

            using (var context = new NinjaEntities())
            {
                var ninja = SelectedNinja.ToModel();

                context.Entry(ninja).State = EntityState.Deleted;
                context.SaveChanges();
            }

            NinjasOC.Remove(SelectedNinja);

        }

    }
}
