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

namespace MonitorAppWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool State { get; set; }
        private PerformanceCounter cpuPerformance;

        public MainWindow()
        {
            InitializeComponent();
            cpuPerformance = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
        }

        private void _startButton_Click(object sender, RoutedEventArgs e)
        {
            _CPUtextbox.Text = cpuPerformance.NextValue() + "%";
            while(true)
            {
                string i = cpuPerformance.NextValue() + "%";
                _CPUtextbox.Text = i;
                _CPUtextbox.Clear();
            }
        }

        private void _stopButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
