/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:LeagueOfNinja"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using LeagueOfNinja.View;
using Microsoft.Practices.ServiceLocation;


namespace LeagueOfNinja.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
        }


        private MainVM _mainVM;


        //---- Main ----
        public MainVM MainVM
        {
            get
            {
                if (_mainVM == null)
                    _mainVM = new MainVM();

                return _mainVM;
            }
        }

        //---- Ninja ----

        private NinjaListVM _ninjaListVM;

        public NinjaListVM NinjaListVM
        {
            get
            {
                if (_ninjaListVM == null)
                    _ninjaListVM = new NinjaListVM(this.MainVM);

                return _ninjaListVM;
            }
        }


        public AddNinjaVM AddNinjaVM
        {
            get
            {

                return new AddNinjaVM(this.NinjaListVM);
            }
        }


        public UpdateNinjaVM UpdateNinjaVM
        {
            get
            {

                return new UpdateNinjaVM(this.NinjaListVM);
            }
        }



        //--- Equipment ---

        private EquipmentListVM _equipmentListVM;

        public EquipmentListVM EquipmentListVM
        {
            get
            {
                if (_equipmentListVM == null)
                    _equipmentListVM = new EquipmentListVM(this.InventoryListVM);

                return _equipmentListVM;
            }
        }

        public AddEquipmentVM AddEquipmentVM
        {
            get
            {
                return new AddEquipmentVM(EquipmentListVM);
            }
        }

        public UpdateEquipmentVM UpdateEquipmentVM
        {
            get
            {
                return new UpdateEquipmentVM(EquipmentListVM);
            }
        }
        private NinjaGearVM _ninjaGearVM;


        public NinjaGearVM NinjaGearVM
        {
            get
            {
                if (_ninjaGearVM == null)
                    _ninjaGearVM = new NinjaGearVM(this.InventoryListVM);
                return _ninjaGearVM;
            }
        }


        //--- Inventory ---


        private InventoryListVM _inventoryListVM;

        public InventoryListVM InventoryListVM
        {
            get
            {
                if (_inventoryListVM == null)
                _inventoryListVM = new InventoryListVM(this.NinjaListVM);

                return _inventoryListVM;
            }
        }


     
        private ShopVM _shopVM;

        public ShopVM ShopVM
        {
            get
            {
                if (_shopVM == null)
                    _shopVM = new ShopVM(this.NinjaListVM);

                return _shopVM;
            }
        }



 



        public static void Cleanup()
        {

        }
    }
}
