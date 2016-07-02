using HighThroughputDataGrid.BusinessLogic;
using HighThroughputDataGrid.Common;
using HighThroughputDataGrid.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HighThroughputDataGrid
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private HighOutputDataSource _source;

        private void OnStartup(object sender, StartupEventArgs e)
        {
            _source = new HighOutputDataSource
            {
                FreshRateObserver = new Observable<double>(),
                NumberOfRandomGenerators = 200
            };

            MainViewModel dc = new MainViewModel
            {
                Stocks = _source.Stocks
            };

            MainWindow window = new MainWindow();
            window.DataContext = dc;
            window.Show();

            _source.FreshRateObserver.Subscribe(dc);
            _source.Start();
        }
    }
}
