using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinja.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using LeagueOfNinja.View;
using System.Data.Entity;
namespace LeagueOfNinja.ViewModel
{
    public class InventoryListVM : ViewModelBase
    {
        
        private EquipmentWindow _equipmentWindow;

        private ShopWindow _shopWindow;

        private NinjaWindow _ninjaWindow;

        private VisualGearWindow _visualGearWindow;

        private InventoryVM _selectedInventoryItem;

        private NinjaListVM _ninjaListVM;

        public ObservableCollection<InventoryVM> InventoryOC { get; set; }

        //Commands

        public ICommand ShowNinjaCommand { get; set; }
        public ICommand ShowShopCommand { get; set; }
        public ICommand ShowEquipmentsCommand { get; set; }

        public ICommand ShowVisualGearCommand { get; set; }

        public ICommand EquipItemCommand { get; set; }
        public ICommand UnEquipItemCommand { get; set; }

        public InventoryListVM(NinjaListVM ninjaListVM)
        {

            _ninjaListVM = ninjaListVM;


            using (var context = new NinjaEntities())
            {
                var inventoryItems = context.InventoryItems.ToList();
                InventoryOC = new ObservableCollection<InventoryVM>(inventoryItems.Select(i => new InventoryVM(i)).Where(i => i.NinjaId == _ninjaListVM.SelectedNinja.NinjaId));
            }
            ShowNinjaCommand = new RelayCommand(ShowNinjas);
            ShowEquipmentsCommand = new RelayCommand(ShowEquipements);
            ShowShopCommand = new RelayCommand(ShowShop);
            ShowVisualGearCommand = new RelayCommand(ShowVisualGear);

        }

        public InventoryVM SelectedInventoryItem
        {
            get { return _selectedInventoryItem; }
            set
            {
                _selectedInventoryItem = value;
                base.RaisePropertyChanged();
            }
        }


        //--- Equipments ---

        public void ShowEquipements()
        {
            _equipmentWindow = new EquipmentWindow();
            _equipmentWindow.Show();
            _ninjaListVM.CloseInventoryNinja();
        }


        public void HideEquipements()
        {

            _equipmentWindow.Close();
        }


        //--- Visual Gear ---

        public void ShowVisualGear()
        {
            _visualGearWindow = new VisualGearWindow();
            _visualGearWindow.Show();
            _ninjaListVM.CloseInventoryNinja();
        }

        //--- Shop ---

        public void ShowShop()
        {
            _shopWindow = new ShopWindow();
            _shopWindow.Show();
            _ninjaListVM.CloseInventoryNinja();
        }

        //--- Ninja ---

        public void ShowNinjas()
        {
            _ninjaWindow = new NinjaWindow();
            _ninjaWindow.Show();
            _ninjaListVM.CloseInventoryNinja();
        }



    }
}
