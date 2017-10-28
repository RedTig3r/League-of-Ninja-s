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
using LeagueOfNinja.ViewModel.InventoryViewModel;
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
                    _ninjaListVM = new NinjaListVM();

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
                    _equipmentListVM = new EquipmentListVM();

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


        //--- Inventory ---

        private InventoryListVM _inventoryListVM;

        public InventoryListVM InventoryListVM
        {
            get
            {
                if (_inventoryListVM == null)
                    _inventoryListVM = new InventoryListVM();

                return _inventoryListVM;
            }
        }

        public InventoryVM NinjaInventory
        {
            get
            {
                return new InventoryVM(_ninjaListVM.SelectedNinja);
            }
        }

        

       
        public static void Cleanup()
        {
           
        }
    }
}