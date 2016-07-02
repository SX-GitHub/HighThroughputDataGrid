using HighThroughputDataGrid.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace HighThroughputDataGrid.ViewModel
{
    public class MainViewModel : Notifier, IObserver<double>
    {
        private object _dialog;
        private int _virtualizingCount;
        private int _virtualizingCapacity;
        private DispatcherTimer _timer;

        public MainViewModel()
        {
            Performance = new PerformanceMonitor();
            _timer = new DispatcherTimer();
            _timer.Tick += (s, e) =>
            {
                foreach (Stock stock in Stocks.Where(stock => !stock.IsSuppressed))
                    stock.OnTimerTick();
            };
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            _timer.Start();
        }

        private int BinarySearch(StockCollection stocks, int index, int length, string symbol, IComparer<string> comparer)
        {
            int lo = index;
            int hi = index + length - 1;
            while (lo <= hi)
            {
                int i = lo + ((hi - lo) >> 1);
                int order = comparer.Compare(((Stock)stocks[i]).Symbol, symbol);
                if (order == 0)
                    return i;
                if (order < 0)
                    lo = i + 1;
                else
                    hi = i - 1;
            }
            return ~lo;
        }

        public StockCollection Stocks { get; set; }

        public PerformanceMonitor Performance { get; set; }

        public object Dialog
        {
            get { return _dialog; }
            set
            {
                if(_dialog != value)
                {
                    _dialog = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int VirtualizingCount
        {
            get { return _virtualizingCount; }
            set
            {
                _virtualizingCount = value;
                RaisePropertyChanged();
            }
        }

        public int VirtualizingCapacity
        {
            get { return _virtualizingCapacity; }
            set
            {
                _virtualizingCapacity = value;
                RaisePropertyChanged();
            }
        }

        #region Interface IObserver<T>

        public void OnCompleted() { }
        public void OnError(Exception error) { }
        public void OnNext(double value) { Performance.Add(value); }

        #endregion Interface IObserver<T>
    }
}
