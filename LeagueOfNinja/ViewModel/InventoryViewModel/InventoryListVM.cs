using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinja.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using LeagueOfNinja.View;
using System.Data.Entity;
using System;

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

        public NinjaVM NinjaVM { get; set; }

        public ObservableCollection<EquipmentVM> EquipmentInventoryOC { get; set; }

        //Commands

        public ICommand ShowNinjaCommand { get; set; }
        public ICommand ShowShopCommand { get; set; }
        public ICommand ShowEquipmentsCommand { get; set; }

        public ICommand ShowVisualGearCommand { get; set; }

        public ICommand EquipItemCommand { get; set; }


        public ICommand SellEverythingCommand { get; set; }
        public InventoryListVM(NinjaListVM ninjaListVM)
        {

            _ninjaListVM = ninjaListVM;

            NinjaVM = _ninjaListVM.SelectedNinja;


            using (var context = new NinjaEntities())
            {

                var index = NinjaVM.NinjaId;
                var inventoryItems = context.InventoryItems.ToList();
                var inventoryID = (inventoryItems.Select(e => new InventoryVM(e)).Where(e => e.NinjaId == index)).ToList();

                var equipments = context.Equipments.ToList();
                EquipmentInventoryOC = new ObservableCollection<EquipmentVM>(equipments.Select(e => new EquipmentVM(e)).Where(e => inventoryID.Any(e2 => e2.EquipmentId == e.EquipmentId)));
            }


            ShowNinjaCommand = new RelayCommand(ShowNinjas);
            ShowEquipmentsCommand = new RelayCommand(ShowEquipements);
            ShowShopCommand = new RelayCommand(ShowShop);
            ShowVisualGearCommand = new RelayCommand(ShowVisualGear);
            EquipItemCommand = new RelayCommand(EquipItem);

            SellEverythingCommand = new RelayCommand(SellEverything);

        }

        internal void HideShop()
        {
            _shopWindow.Close();
        }

        private void EquipItem()
        {



        }

  
        private void SellEverything()
        {

            foreach (EquipmentVM e in EquipmentInventoryOC)
            {
                NinjaVM.Money += e.EquipmentValue;
            }


            using (var context = new NinjaEntities())
            {

                context.InventoryItems.Where(p => p.NinjaId == NinjaVM.NinjaId).ToList().ForEach(p => context.InventoryItems.Remove(p));

                var ninja = NinjaVM.ToModel();
                context.Entry(ninja).State = EntityState.Modified;
                context.SaveChanges();
            }


            EquipmentInventoryOC.Clear();
    
     

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
