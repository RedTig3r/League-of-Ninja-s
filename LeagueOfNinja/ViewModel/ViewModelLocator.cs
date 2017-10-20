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
using LeagueOfNinja.ViewModel.NinjaViewModel;
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

        private NinjaListVM _ninjaListVM;


        public NinjaListVM NinjaListVM
        {
            get
            { //De service locator gebruikt een 'singleton' patroon.
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


        public static void Cleanup()
        {
           
        }
    }
}