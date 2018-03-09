using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.MainWindowVM
{
    public class CpuMonitorCommand : ICommand
    {
        private MainWindowViewModel _mainViewModel;
        private Thread _cpuMonitorThread;
        //private AutoResetEvent _autoResetEvent;
        //private bool _monitorActive = false;

        public event EventHandler CanExecuteChanged;

        public CpuMonitorCommand(MainWindowViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _cpuMonitorThread = new Thread(CpuMonitoring);
            //_autoResetEvent = new AutoResetEvent(false);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _cpuMonitorThread.Start();
            _mainViewModel.MonitorButtonEnabled = !_mainViewModel.MonitorButtonEnabled;
        }

        private void CpuMonitoring()
        {
            var cpuPerformance = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
            while (true)
            {
                Thread.Sleep(500);
                _mainViewModel.CpuUsage = cpuPerformance.NextValue().ToString();
            }
        }
    }
}
