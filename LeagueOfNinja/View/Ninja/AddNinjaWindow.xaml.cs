﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LeagueOfNinja.ViewModel.NinjaViewModel;

namespace LeagueOfNinja.View
{
    /// <summary>
    /// Interaction logic for AddNinjaWindow.xaml
    /// </summary>
    public partial class AddNinjaWindow : Window
    {
       
        public AddNinjaWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}