using HighThroughputDataGrid.Common;
using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace HighThroughputDataGrid
{
    public class Stock : Suppressible, IComparable
    {
        #region Fields
        private string _symbol;
        private string _companyName;
        private double _open;
        private double _close;
        private double _high;
        private double _low;
        private double _change;
        private double _changeInPercentage;
        private double _bid;
        private double _ask;
        private double _last;
        private int _bidSize;
        private int _askSize;
        private long _volumn;
        private long _lastVolumn;
        #endregion Fields

        public double Ask
        {
            get { return _ask; }
            set
            {
                if (_ask != value)
                {
                    _ask = value;
                    QueuePropertyChanged();
                }
            }
        }

        public int AskSize
        {
            get { return _askSize; }
            set
            {
                if (_askSize != value)
                {
                    _askSize = value;
                    QueuePropertyChanged();
                }
            }
        }

        public double Bid
        {
            get { return _bid; }
            set
            {
                if (_bid != value)
                {
                    _bid = value;
                    QueuePropertyChanged();
                }
            }
        }

        public int BidSize
        {
            get { return _bidSize; }
            set
            {
                if (_bidSize != value)
                {
                    _bidSize = value;
                    QueuePropertyChanged();
                }
            }
        }

        public double ChangeInPercentage
        {
            get { return _changeInPercentage; }
            set
            {
                if (_changeInPercentage != value)
                {
                    _changeInPercentage = value;
                    QueuePropertyChanged();
                }
            }
        }

        public double Close
        {
            get { return _close; }
            set
            {
                if (_close != value)
                {
                    _close = value;
                    QueuePropertyChanged();
                }
            }
        }

        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                if (_companyName != value)
                {
                    _companyName = value;
                    QueuePropertyChanged();
                }
            }
        }

        public double Change
        {
            get { return _change; }
            set
            {
                if (_change != value)
                {
                    _change = value;
                    QueuePropertyChanged();
                }
            }
        }

        public double Last
        {
            get { return _last; }
            set
            {
                if (_last != value)
                {
                    _last = value;
                    QueuePropertyChanged();
                }
            }
        }

        public double High
        {
            get { return _high; }
            set
            {
                if (_high != value)
                {
                    _high = value;
                    QueuePropertyChanged();
                }
            }
        }

        public long LastVolumn
        {
            get { return _lastVolumn; }
            set
            {
                if (_lastVolumn != value)
                {
                    _lastVolumn = value;
                    QueuePropertyChanged();
                }
            }
        }

        public double Low
        {
            get { return _low; }
            set
            {
                if (_low != value)
                {
                    _low = value;
                    QueuePropertyChanged();
                }
            }
        }

        public double Open
        {
            get { return _open; }
            set
            {
                if (_open != value)
                {
                    _open = value;
                    QueuePropertyChanged();
                }
            }
        }

        public string Symbol
        {
            get { return _symbol; }
            set
            {
                if (_symbol != value)
                {
                    _symbol = value;
                    QueuePropertyChanged();
                }
            }
        }

        public long Volumn
        {
            get { return _volumn; }
            set
            {
                if (_volumn != value)
                {
                    _volumn = value;
                    QueuePropertyChanged();
                }
            }
        }

        public int CompareTo(object obj)
        {
            if (obj is string)
                return Symbol.CompareTo((string)obj);
            if (obj == null || GetType() != obj.GetType())
                return -1;
            return Symbol.CompareTo(((Stock)obj).Symbol);
        }
    }

    public class StockCollection : ObservableCollection<Stock> { }
}
