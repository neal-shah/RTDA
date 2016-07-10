using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace RealtimeInstrumentDataApp
{
    /// <summary>
    /// Used in the GUI... 
    /// </summary>
    /// 
    public class GuiInstrument : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public IList<double> Prices { get; set; }
        public double AverageOver5Prices { get; set; }
        public double LastPrice
        {
            get { return Prices.Skip(Math.Max(0, Prices.Count() - 1)).Sum(); }
        }
        public string State { get; set; } 

        public void AddPrice(double price)
        {
            if (price < LastPrice)
            {
                State = "down";
            }
            else if (price > LastPrice)
            {
                State = "up";
            }
            else if(price == LastPrice)
            {
                State = "nochange";
            }

            Prices.Add(Math.Round(price, 2));
            AverageOver5Prices = Math.Round(Prices.Skip(Math.Max(0, Prices.Count() - 5)).Average(), 2);
            OnPropertyChanged("Prices");
            OnPropertyChanged("AverageOver5Prices");
            OnPropertyChanged("LastPrice");
            OnPropertyChanged("State");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
