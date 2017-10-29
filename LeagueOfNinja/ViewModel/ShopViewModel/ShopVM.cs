using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinja.View;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
namespace LeagueOfNinja.ViewModel
{
    public class ShopVM : ViewModelBase
    {


        public ObservableCollection<EquipmentVM> ShopItems { get; set; }


    

    }
}
