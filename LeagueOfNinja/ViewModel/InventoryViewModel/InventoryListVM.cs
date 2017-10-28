using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinja.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using LeagueOfNinja.View;
using System.Data.Entity;
namespace LeagueOfNinja.ViewModel.InventoryViewModel
{
    public class InventoryListVM : ViewModelBase
    {
        
        private EquipmentWindow _equipmentWindow;

        private ShopWindow _shopWindow;

        private VisualGearWindow _visualGearWindow;


        public ObservableCollection<InventoryVM> InventoryOC { get; set; }

        //Commands
        public ICommand ShowShopCommand { get; set; }
        public ICommand ShowEquipmentsCommand { get; set; }

        public ICommand ShowVisualGearCommand { get; set; }

        public InventoryListVM()
        {

            
            using (var context = new NinjaEntities())
            {

                var inventoryItems = context.InventoryItems.ToList();
                InventoryOC = new ObservableCollection<InventoryVM>(inventoryItems.Select(r => new InventoryVM(r)));
            }

            ShowEquipmentsCommand = new RelayCommand(ShowEquipements);
            ShowShopCommand = new RelayCommand(ShowShop);
            ShowVisualGearCommand = new RelayCommand(ShowVisualGear);

        }


        //--- Equipments ---

        public void ShowEquipements()
        {
            _equipmentWindow = new EquipmentWindow();
            _equipmentWindow.Show();
        }

        //--- Visual Gear ---

        public void ShowVisualGear()
        {
            _visualGearWindow = new VisualGearWindow();
            _visualGearWindow.Show();            
        }

        //--- Shop ---

        public void ShowShop()
        {
            _shopWindow = new ShopWindow();
            _shopWindow.Show();
        }

    }
}
