﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinja.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LeagueOfNinja.ViewModel
{
    public class InventoryVM : ViewModelBase
    {

        private InventoryItem _inventoryItem;


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
