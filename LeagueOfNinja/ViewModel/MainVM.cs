using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinja.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using LeagueOfNinja.View;
using System.Data.Entity;

namespace LeagueOfNinja.ViewModel
{
    public class MainVM : ViewModelBase
    {
        private NinjaWindow _ninjaWindow;

        //Commands
        public ICommand ShowStartCommand { get; set; }

        public MainVM()
        {

            ShowStartCommand = new RelayCommand(ShowNinjaWindow);
        }

        //--- create ---
        public void ShowNinjaWindow()
        {
            _ninjaWindow = new NinjaWindow();
            _ninjaWindow.Show();

        }


        public void CloseNinjawindow()
        {
            _ninjaWindow.Close();
        }

   



        
       
    }
}
