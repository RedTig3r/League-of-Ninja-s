using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinja.Model;
using LeagueOfNinja.View;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
namespace LeagueOfNinja.ViewModel
{
    public class ShopVM : ViewModelBase
    {

        private NinjaListVM _ninjaListVM;

        private InventoryWindow _inventoryWindow;

        private InventoryListVM _inventoryListVM;

        public NinjaVM NinjaVM { get; set; }

        private EquipmentVM _equipmentType;

        private EquipmentVM _equipment;



        public ObservableCollection<EquipmentVM> ShopTypesOC { get; set; }


        public ObservableCollection<EquipmentVM> ShopItemsOC { get; set; }


        public ICommand ShowAllItemsFromEquipmentTypeCommand { get; set; }
        public ICommand ShowEquipmentDetailCommand { get; set; }
        public ICommand BuyEquipmentTypeCommand { get; set; }

        public ICommand ShowInventoryCommand { get; set; }

        public ShopVM(NinjaListVM ninjaListVM, InventoryListVM inventoryListVM)
        {
            this._ninjaListVM = ninjaListVM;

            this.NinjaVM = _ninjaListVM.SelectedNinja;

            this._inventoryListVM = inventoryListVM;

            using (var context = new NinjaEntities())
            {

                var equipmentTypes = context.Equipments.ToList();
                ShopTypesOC = new ObservableCollection<EquipmentVM>(equipmentTypes.Select(et => new EquipmentVM(et)).GroupBy(et => et.EquipmentType).First());
            }

            ShowAllItemsFromEquipmentTypeCommand = new RelayCommand(ShowAllItemsFromEquipmentType);
            ShowEquipmentDetailCommand = new RelayCommand(ShowEquipmentDetail);
            BuyEquipmentTypeCommand = new RelayCommand(BuyEquipmentType);
            ShowInventoryCommand = new RelayCommand(ShowInventory);
        }

        private void ShowInventory()
        {

            _inventoryWindow = new InventoryWindow();
            _inventoryWindow.Show();
            _inventoryListVM.HideShop();
        }

        private void BuyEquipmentType()
        {
            using (var context = new NinjaEntities())
            {
                var equipment = context.Equipments.ToList();
                ShopItemsOC = new ObservableCollection<EquipmentVM>(equipment.Select(e => new EquipmentVM(e)).Where(e => e.EquipmentType == _equipmentType.EquipmentType));
            }
        }

        private void ShowEquipmentDetail()
        {
        }

        private void ShowAllItemsFromEquipmentType()
        {
            if (_equipmentType != null)
            {
       

                using (var context = new NinjaEntities())
                {
                    var equipment = context.Equipments.ToList();
                    ShopItemsOC = new ObservableCollection<EquipmentVM>(equipment.Select(e => new EquipmentVM(e)).Where(e => e.EquipmentType == _equipmentType.EquipmentType));
                }
            }
          
        }

        public EquipmentVM SelectedEquipmentType
        {
            get { return _equipmentType; }
            set
            {
                _equipmentType = value;
                base.RaisePropertyChanged();
            }
        }


        public EquipmentVM SelectedEquipment
        {
            get { return _equipment; }
            set
            {
                _equipment = value;
                base.RaisePropertyChanged();
            }
        }


 





    }
}
