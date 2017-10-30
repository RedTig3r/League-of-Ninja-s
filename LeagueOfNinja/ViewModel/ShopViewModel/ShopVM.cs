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

        public ICommand ShowInventoryCommand { get; set; }

        public ICommand BuyItemCommand { get; set; }

        public ICommand ShowBeltCategoryCommand { get; set; }
        public ICommand ShowBootsCategoryCommand { get; set; }
        public ICommand ShowChestCategoryCommand { get; set; }
        public ICommand ShowLegsCategoryCommand { get; set; }
        public ICommand ShowShouldersCategoryCommand { get; set; }



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



            ShowInventoryCommand = new RelayCommand(ShowInventory);
            BuyItemCommand = new RelayCommand(BuyItem);



            ShowLegsCategoryCommand = new RelayCommand(RetrieveLegsItems);
            ShowBeltCategoryCommand = new RelayCommand(RetrieveBeltItems);
            ShowChestCategoryCommand = new RelayCommand(RetrieveChestItems);
            ShowBootsCategoryCommand = new RelayCommand(RetrieveBootsItems);
            ShowShouldersCategoryCommand = new RelayCommand(RetrieveShouldersItems);
   
        }

  

        private void BuyItem()
        {

            if (SelectedEquipment != null && NinjaVM.Money > SelectedEquipment.EquipmentValue)
            {

                var InventoryItemVM = new InventoryVM();
                var inventoryItem = InventoryItemVM.ToModel();


                inventoryItem.NinjaId = NinjaVM.NinjaId;
                inventoryItem.IsUsingEquitment = false;
                inventoryItem.EquipmentId = SelectedEquipment.EquipmentId;

                _inventoryListVM.EquipmentInventoryOC.Add(SelectedEquipment);


                using (var context = new NinjaEntities())
                {

                    EquipmentVM items = new EquipmentVM(context.Equipments.Where(e => e.EquipmentId == inventoryItem.EquipmentId).First());



                    NinjaVM.Money -= items.EquipmentValue;

                    var ninja = NinjaVM.ToModel();
                    context.Entry(ninja).State = EntityState.Modified;

                    context.InventoryItems.Add(inventoryItem);
                    context.Entry(inventoryItem).State = EntityState.Added;
                    context.SaveChanges();
                }


                this.RaisePropertyChanged();
                ShopItemsOC.Remove(SelectedEquipment);


            }


        }



        private void ShowInventory()
        {

            _inventoryWindow = new InventoryWindow();
            _inventoryWindow.Show();
            _inventoryListVM.HideShop();
        }

        private void BuyEquipmentType()
        {


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



        public void RetrieveCategoryItems(string equipmentType)
        {



            ShopItemsOC.Clear();

            using (var context = new NinjaEntities())
            {

                var equipment = context.Equipments.ToList();

                foreach (var e in equipment)
                {


                    if (e.EquipmentType == equipmentType)
                    {
                        ShopItemsOC.Add(new EquipmentVM(e));
                    }

                }


            }



            this.RaisePropertyChanged();





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
