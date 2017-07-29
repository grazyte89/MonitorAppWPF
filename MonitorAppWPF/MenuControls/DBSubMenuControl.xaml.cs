﻿using PetsEntityLib;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MonitorAppWPF.MenuControls
{
    /// <summary>
    /// Interaction logic for DBSubMenuControl.xaml
    /// </summary>
    public partial class DBSubMenuControl : UserControl
    {
        private ContentControl _mainUserControl;

        public DBSubMenuControl(ContentControl mainContent)
        {
            InitializeComponent();
            _mainUserControl = mainContent;
        }

        private void BtnAnimal_Click(object sender, RoutedEventArgs e)
        {
            this.ClearContent();
            this._mainUserControl.Content = new DbControls.AnimalsDbControl();
        }

        private void BtnCustomers_Click(object sender, RoutedEventArgs e)
        {
            this.ClearContent();
            this._mainUserControl.Content = new DbControls.CustomerDBControl();
        }

        private void ClearContent()
        {
            if (_mainUserControl.Content != null)
                _mainUserControl.Content = null;
        }

        private void BtnStocks_Click(object sender, RoutedEventArgs e)
        {
            this.ClearContent();
            this._mainUserControl.Content = new DbControls.StockDbControl();
        }

        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            TestClass.ManyTwoManyTest();
        }
    }
}
