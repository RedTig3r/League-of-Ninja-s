﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LeagueOfNinja.ViewModel
{
    public class InventoryVM : ViewModelBase
    {

        private InventoryItem _inventoryItem;

        public NinjaVM SelectedNinja { get; set; }

        public ICommand ClearInventoryCommand { get; set; }


        public InventoryVM()
        {
            this._inventoryItem = new InventoryItem();
        }

        public InventoryVM(InventoryItem inventory)
        {
            this._inventoryItem = inventory;
        }
        
        internal InventoryItem ToModel()
        {
            return _inventoryItem;
        }

        public InventoryVM(NinjaVM selectedNinja)
        {
            SelectedNinja = selectedNinja;

            //ClearInventoryCommand = new RelayCommand(Clear, CanClear);
        }

        private bool CanClear(object parameter)
        {
            if (SelectedNinja.InventoryItems.Count > 0)
            {
                return true;
            }
            return false;
        }

        



        public int NinjaId {
            get { return _inventoryItem.NinjaId; }
            set { _inventoryItem.NinjaId = value; RaisePropertyChanged("NinjaId"); }
        }

        public int EquipmentId {
            get { return _inventoryItem.EquipmentId; }
            set { _inventoryItem.EquipmentId = value; RaisePropertyChanged("EquipmentId"); }
        }

        public bool IsUsingEquipment
        {
            get { return _inventoryItem.IsUsingEquitment; }
            set { _inventoryItem.IsUsingEquitment = value; RaisePropertyChanged("IsUsingEquipment"); }
        }



    }
}
