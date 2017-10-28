using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinja.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LeagueOfNinja.ViewModel
{
    public class AddEquipmentVM : ViewModelBase
    {

        private EquipmentListVM _equipmentListVM;

        public EquipmentVM Equipment { get; set; }

        public ICommand AddEquipmentICommand { get; set; }

        public AddEquipmentVM(EquipmentListVM equiptmentListVM)
        {
            this._equipmentListVM = equiptmentListVM;
            this.Equipment = new EquipmentVM();
            AddEquipmentICommand = new RelayCommand(AddEquipment, CanAddEquipment);
        }

        private void AddEquipment()
        {
            var equipment = Equipment.ToModel();

            using (var context = new NinjaEntities())
            {

                context.Equipments.Add(equipment);
                context.Entry(equipment).State = EntityState.Added;
                context.SaveChanges();
            }

            _equipmentListVM.EquipmentsOC.Add(Equipment);
            _equipmentListVM.HideAddEquipment();
        }

        private bool CanAddEquipment()
        {
            return true;
        }

    }
}
