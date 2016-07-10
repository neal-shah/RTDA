using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Diagnostics;
using System.Linq;
using RealtimeInstrumentDataApp.Data;

namespace RealtimeInstrumentDataApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<GuiInstrument> _instruments;

        public MainWindow()
        {
            InitializeComponent();
            ISource source = new SampleDataSource();
            ITickerPlant tickerPlant = new TickerPlant(source.GetData());

            _instruments = new ObservableCollection<GuiInstrument>();

            tickerPlant.Tick += HandleTick;

            tickerPlant.Start();
        }

        public ObservableCollection<GuiInstrument> Instruments { get { return _instruments; } }

        public void HandleTick(object sender, ISourceItem e)
        {
            AddSourceItem(e);
        }

        public void AddSourceItem(ISourceItem item)
        {
            var instrumentInGuiInstruments = _instruments.Where(t => t.Name == item.Name).ToList();
            if (instrumentInGuiInstruments.Count == 0)
            {
                var guiInst = new GuiInstrument { Name = item.Name, Prices = new List<double> { item.Price } };
                _instruments.Add(guiInst);
                Debug.WriteLine("New Instrument - Ticker: {0} First Price: {1}", item.Name, item.Price);
            }
            else
            {
                var inst = _instruments.First(t => t.Name == item.Name);
                inst.AddPrice(item.Price);
                Debug.WriteLine("Instrument Found - Ticker: {0} Current Price: {1} Moving Average: {2}", inst.Name, inst.LastPrice, inst.AverageOver5Prices);
            }
        }
    }
}