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
        private CpuMonitoring _cpuMonitroing { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            _cpuMonitroing = new CpuMonitoring(_currentCpuUsage);
        }

        private void _monitorButton_Click(object sender, RoutedEventArgs e)
        {
            _cpuMonitroing.StartMonitoring();
        }
    }
}
