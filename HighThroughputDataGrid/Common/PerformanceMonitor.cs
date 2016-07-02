using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighThroughputDataGrid.Common
{
    public class PerformanceMonitor : Notifier
    {
        private double _maximum = 0.0;
        private double _minimum = 0.0;
        private double _average = 0.0;
        private double _sum = 0.0;
        private double _count;

        public void Add(double value)
        {
            _count++;
            _sum += value;

            Average = _sum / _count;
            Maximum = Math.Max(_maximum, value);
            Minimum = _minimum > 0.0001? Math.Min(_minimum, value) : value;
        }

        public double Maximum
        {
            get { return _maximum; }
            set
            {
                if (_maximum != value)
                {
                    _maximum = value;
                    RaisePropertyChanged();
                }
            }
        }

        public double Minimum
        {
            get { return _minimum; }
            set
            {
                if (_minimum != value)
                {
                    _minimum = value;
                    RaisePropertyChanged();
                }
            }
        }

        public double Average
        {
            get { return _average; }
            set
            {
                if (_average != value)
                {
                    _average = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
