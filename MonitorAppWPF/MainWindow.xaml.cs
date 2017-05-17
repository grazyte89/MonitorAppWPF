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
using System.Diagnostics;
using MonitorAppWPF.Monitors;
using System.Threading;

namespace MonitorAppWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool State { get; set; }
        private CpuMonitoring _cpuMonitroing;

        public MainWindow()
        {
            InitializeComponent();
            _cpuMonitroing = new CpuMonitoring(_lbCurrentCpuUsage);
            this.DataContext = _cpuMonitroing;
            
        }

        private void MonitorButton_Click(object sender, RoutedEventArgs e)
        {
            _cpuMonitroing.StartMonitoring();
        }

        private void DatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            //this._ccMainControls.Content = new DbControls.PetDbControl();
            this._ccSubMenuControl.Content = new MenuControls.DBSubMenuControl();
        }
    }
}
