using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinja.Model;
using LeagueOfNinja.View;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;
namespace LeagueOfNinja.ViewModel
{
    public class ShopVM : ViewModelBase
    {

        private NinjaListVM _ninjaListVM;
        private InventoryWindow _inventoryWindow;
        private InventoryListVM _inventoryListVM;
        private EquipmentVM _equipment;


        public NinjaVM NinjaVM { get; set; }
        public ObservableCollection<EquipmentVM> ShopItemsOC { get; set; }
        public ICommand ShowAllItemsFromEquipmentTypeCommand { get; set; }
        public ICommand ShowEquipmentDetailCommand { get; set; }
        public ICommand BuyEquipmentTypeCommand { get; set; }

        public ICommand ShowInventoryCommand { get; set; }

        public ICommand BugItemCommand { get; set; }

        public ICommand ShowBeltCategory { get; set; }
        public ICommand ShowBootsCategory { get; set; }
        public ICommand ShowChestCategory { get; set; }
        public ICommand ShowLegsCategory { get; set; }
        public ICommand ShowShouldersCategory { get; set; }

        public ICommand ShowHeadCategory { get; set; }


        public ShopVM(NinjaListVM ninjaListVM, InventoryListVM inventoryListVM)
        {
            this._ninjaListVM = ninjaListVM;

            this.NinjaVM = _ninjaListVM.SelectedNinja;

            this._inventoryListVM = inventoryListVM;
            


            using (var context = new NinjaEntities())
            {
   
                var equipment = context.Equipments.ToList();
                ShopItemsOC = new ObservableCollection<EquipmentVM>(equipment.Select(e => new EquipmentVM(e)));
            }


            //ShowAllItemsFromEquipmentTypeCommand = new RelayCommand(ShowAllItemsFromEquipmentType);
            ShowEquipmentDetailCommand = new RelayCommand(ShowEquipmentDetail);
            BuyEquipmentTypeCommand = new RelayCommand(BuyEquipmentType);
            ShowInventoryCommand = new RelayCommand(ShowInventory);
            BugItemCommand = new RelayCommand(BuyItem, CanBuyItem);


            ShowHeadCategory = new RelayCommand(RetrieveHeadItems);
            ShowLegsCategory = new RelayCommand(RetrieveLegsItems);
            ShowBeltCategory = new RelayCommand(RetrieveBeltItems);
            ShowChestCategory = new RelayCommand(RetrieveChestItems);
            ShowBootsCategory = new RelayCommand(RetrieveBootsItems);
            ShowShouldersCategory = new RelayCommand(RetrieveShouldersItems);
        }

        private void BuyItem()
        {
           
                var InventoryItemVM = new InventoryVM();

                var inventoryItem = InventoryItemVM.ToModel();

                inventoryItem.NinjaId = NinjaVM.NinjaId;
                inventoryItem.IsUsingEquitment = false;
                inventoryItem.EquipmentId = SelectedEquipment.EquipmentId;

                using (var context = new NinjaEntities())
                {

                    context.InventoryItems.Add(inventoryItem);
                    context.Entry(inventoryItem).State = EntityState.Added;
                    context.SaveChanges();
                }

            

        }

        private bool CanBuyItem()
        {
            return NinjaVM.Money > SelectedEquipment.EquipmentValue;
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
                ShopItemsOC = new ObservableCollection<EquipmentVM>(equipment.Select(e => new EquipmentVM(e)).Where(e => e.EquipmentType == _equipment.EquipmentType));
                //ShopItemsOC = new ObservableCollection<EquipmentVM>(equipment.Select(e => new EquipmentVM(e)).Where(e => e.EquipmentType == _equipmentType.EquipmentType));
            }
        }

        private void ShowEquipmentDetail()
        {


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



        public void RetrieveCategoryItems(String categoryName)
        {
            ShopItemsOC.Clear();

            foreach (var item in ShopItemsOC)
            {
                if (item.EquipmentType.ToLower().Equals(categoryName.ToLower()))
                {
                    ShopItemsOC.Add(item);
                }
            }
        }

        private void RetrieveHeadItems()
        {
            this.RetrieveCategoryItems("Head");
        }

        private void RetrieveShouldersItems()
        {
            this.RetrieveCategoryItems("Shoulders");
        }

        private void RetrieveChestItems()
        {
            this.RetrieveCategoryItems("Chest");
        }

        private void RetrieveBeltItems()
        {
            this.RetrieveCategoryItems("Belt");
        }

        private void RetrieveLegsItems()
        {
            this.RetrieveCategoryItems("Legs");
        }

        private void RetrieveBootsItems()
        {
            this.RetrieveCategoryItems("Boots");
        }

        }
}
