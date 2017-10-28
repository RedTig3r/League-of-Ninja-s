using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Data.Entity;


namespace LeagueOfNinja.ViewModel.EquipmentViewModel
{
    public class UpdateEquipmentVM : ViewModelBase
    {

        private EquipmentListVM _equipmentListVM;

        public EquipmentVM EquipmentVM { get; set; }

        public ICommand UpdateEquipmentICommand { get; set; }

        public UpdateEquipmentVM(EquipmentListVM equipmentListVM)
        {
            this._equipmentListVM = equipmentListVM;
            this.EquipmentVM = _equipmentListVM.SelectedEquipment;
            UpdateEquipmentICommand = new RelayCommand(UpdateEquipment, CanUpdateEquipment);
        }

        private void UpdateEquipment()
        {
            using (var context = new NinjaEntities())
            {

                var equipment = EquipmentVM.ToModel();

                context.Entry(equipment).State = EntityState.Modified;
                context.SaveChanges();


            }

            _equipmentListVM.HideUpdateEquipment();
        }

        private bool CanUpdateEquipment()
        {
            return true;
        }
    }
}
