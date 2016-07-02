using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace HighThroughputDataGrid.Common
{
    public class Suppressible : Notifier
    {
        private HashSet<string> _eventCache = new HashSet<string>();
        private bool _isSuppressed= true;
        
        public bool IsSuppressed
        {
            get { return _isSuppressed; }
            set
            {
                if (_isSuppressed != value)
                {
                    _isSuppressed = value;
                    RaisePropertyChanged();
                    OnPropertyChanged();
                }
            }
        }

        public void OnTimerTick()
        {
            if (!_isSuppressed)
            {
                lock (_eventCache)
                {
                    foreach (string property in _eventCache)
                        RaisePropertyChanged(property);
                    _eventCache.Clear();
                }
            }
        }

        protected void QueuePropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (!_isSuppressed)
            {
                lock (_eventCache) { _eventCache.Add(propertyName); }
            }
        }

        protected override void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (propertyName == "IsSuppressed")
            {
                if (!IsSuppressed)
                    OnTimerTick();
            }
        }
    }
}
