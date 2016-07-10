using RealtimeInstrumentDataApp.Data;

namespace RealtimeInstrumentDataApp
{
    /// <summary>
    /// Source instrument from source data
    /// </summary>
    public class Instrument : ISourceItem
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Name, Price);
        }
    }
}
