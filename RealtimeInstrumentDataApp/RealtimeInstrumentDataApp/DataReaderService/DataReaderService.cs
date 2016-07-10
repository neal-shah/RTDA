using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace RealtimeInstrumentDataApp.Service
{
    public class DataReaderService
    {
        public string ReadLineFromSampleData(int line)
        {
            using (var sr = new StreamReader(Constants.File))
            {
                for (int i = 0; i < line; i++)
                    sr.ReadLine();
                return sr.ReadLine();
            }
        }

        public Dictionary<string, double> GetInstrumentCurrentPrice(int line)
        {
            var dict = new Dictionary<string, double>();

            var sampleDataLine = ReadLineFromSampleData(line);
            string[] data = sampleDataLine.Split(':');

            var instrumentName = data[0];
            var currentPrice = Convert.ToDouble(data[1]);

            dict.Add(instrumentName, currentPrice);

            return dict;
        }
    }
}
