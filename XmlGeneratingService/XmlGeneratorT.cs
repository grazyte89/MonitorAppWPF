using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XmlPersistanceLib;

namespace XmlGeneratingService
{
    public partial class XmlGeneratorT : ServiceBase
    {
        private XmlFilePersist<string> _persistantObject;
        private readonly object _lockObject = new object();
        private CancellationTokenSource _tokenSource;

        public XmlGeneratorT()
        {
            InitializeComponent();
            _tokenSource = new CancellationTokenSource();
            _persistantObject = new XmlFilePersist<string>("Message");
            Thread.Sleep(5000);
        }

        protected override void OnStart(string[] args)
        {
            Thread thread1 = new Thread(ThreadOne);
            Thread thread2 = new Thread(ThreadTwo);
            thread1.Start();
            thread2.Start();
            AsyncOne();
            AsyncTwo();
        }

        protected override void OnStop()
        {
            _tokenSource.Cancel();
        }

        private void Write(string value)
        {
            lock (_lockObject)
            {
                _persistantObject.Message = value;
                _persistantObject.Persist();
            }
        }

        private void ThreadOne()
        {
            for (int index = 0; index < 1000; index++)
            {
                if (_tokenSource.IsCancellationRequested)
                    break;

                this.Write("One + " + index);
            }
        }

        private void ThreadTwo()
        {
            for (int index = 0; index < 1000; index++)
            {
                if (_tokenSource.IsCancellationRequested)
                    break;

                this.Write("Two + " + index);
            }            
        }

        private async void AsyncOne()
        {
            await WaitFunctionOne();
        }

        private Task WaitFunctionOne()
        {
            return Task.Factory.StartNew(() =>
            {
                for (int index = 0; index < 1000; index++)
                {
                    if (_tokenSource.IsCancellationRequested)
                        return;

                    this.Write("Async One + " + index);
                }
            });
        }

        private async void AsyncTwo()
        {
            await WaitFunctionTwo();
        }

        private Task WaitFunctionTwo()
        {
            return Task.Factory.StartNew(() =>
            {
                for (int index = 0; index < 1000; index++)
                {
                    if (_tokenSource.IsCancellationRequested)
                        return;

                    this.Write("Async Two + " + index);
                }
            });
        }
    }
}
