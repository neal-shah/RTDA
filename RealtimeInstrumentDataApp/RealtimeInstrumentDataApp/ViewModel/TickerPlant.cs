using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RealtimeInstrumentDataApp.Data;

namespace RealtimeInstrumentDataApp
{
    public interface ITickerPlant
    {
        event EventHandler<ISourceItem> Tick;
        void Start();
    }

    public class TickerPlant : ITickerPlant
    {
        public event EventHandler<ISourceItem> Tick;

        private readonly IList<ISourceItem> _data;

        public TickerPlant(IList<ISourceItem> data)
        {
            _data = data;
        }

        public async void Start()
        {
            while (true)
            {
                foreach (var item in _data)
                {
                    if (Tick != null)
                    {
                        Tick(this, item);
                    }
                    await Task.Delay(100);
                }
            }
        }
    }
}
