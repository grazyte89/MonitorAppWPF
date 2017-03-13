using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Timers;
using System.Windows;
using System.ComponentModel;

namespace MonitorAppWPF.Monitors
{
    public class CpuMonitoring : IMonitor, INotifyPropertyChanged
    {
        //private Label _cpuUsageDisplay { get; set; }
        private PerformanceCounter _cpuPerformance { get; set; }
        private Timer _cycleTimer { get; set; }
        private string _lbCpuUsage;

        public event PropertyChangedEventHandler PropertyChanged;

        public CpuMonitoring(Label label)
        {
            this.InitialiseCyceTimer();
            _cpuPerformance = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
            _lbCpuUsage = "0";
            //_cpuUsageDisplay = label;
        }

        public string CpuUsage
        {
            get
            {
                return _lbCpuUsage + " %";
            }
            set
            {
                _lbCpuUsage = value;
                this.OnPropertyChanged("CpuUsage");
            }
        }

        private void InitialiseCyceTimer()
        {
            _cycleTimer = new Timer(1000);
            _cycleTimer.Elapsed += OnTimedEvent;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(new System.Action(() => DisplayMonitoredData()));

            /* In wpf, you could only work with the graphical UI elements in the
             * main thread, and trying to access the graphical UI lements from
             * another thread, will cause an error. So in-order to work around it
             * we use the above statement. 
             * */

            _cycleTimer.Start();
        }

        private void DisplayMonitoredData()
        {
            this.CpuUsage = _cpuPerformance.NextValue().ToString();
            //this.CpuUsage = PetsEntityLib.TestClass.GetCustomers().Count().ToString();
        }

        public void StartMonitoring()
        {
            DisplayMonitoredData();
            _cycleTimer.Start();
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
