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

        private EquipmentVM _equipmentType;

        private EquipmentVM _equipment;

        public NinjaVM SelectedNinja;

        public ObservableCollection<EquipmentVM> ShopTypesOC { get; set; }


        public ObservableCollection<EquipmentVM> ShopItemsOC { get; set; }


        public ICommand ShowAllItemsFromEquipmentTypeCommand { get; set; }
        public ICommand ShowEquipmentDetailCommand { get; set; }
        public ICommand BuyEquipmentTypeCommand { get; set; }

        public ShopVM(NinjaListVM ninjaListVM)
        {
            this._ninjaListVM = ninjaListVM;

            SelectedNinja = _ninjaListVM.SelectedNinja;

            using (var context = new NinjaEntities())
            {

                var equipmentTypes = context.Equipments.ToList();
                ShopTypesOC = new ObservableCollection<EquipmentVM>(equipmentTypes.Select(et => new EquipmentVM(et)).GroupBy(et => et.EquipmentType).First());
            }

            ShowAllItemsFromEquipmentTypeCommand = new RelayCommand(ShowAllItemsFromEquipmentType);
            ShowEquipmentDetailCommand = new RelayCommand(ShowEquipmentDetail);
            BuyEquipmentTypeCommand = new RelayCommand(BuyEquipmentType);
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
            SelectedNinja = _ninjaListVM.SelectedNinja;
        }

        private void ShowAllItemsFromEquipmentType()
        {
            if (_equipmentType != null)
            {
                if (ShopItemsOC != null)
                {
                    ShopItemsOC.Clear();
                }
             

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
