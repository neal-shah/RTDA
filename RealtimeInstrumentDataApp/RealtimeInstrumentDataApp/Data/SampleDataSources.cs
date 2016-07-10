﻿using System;
using System.Collections.Generic;
using RealtimeInstrumentDataApp.Service;

namespace RealtimeInstrumentDataApp.Data
{
    public interface ISource
    {
        IList<ISourceItem> GetData();
    }

    public interface ISourceItem
    {
        string Name { get; set; }
        double Price { get; set; }
    }

    /// <summary>
    /// Sample data (for testing app logic)
    /// </summary>

    public class SampleDataSource : ISource

    {

        public static string data = @"BT.L:100
            VOD.L:85
            BP.L:1450.4
            Dow:12,860
            Oil:86.67
            BT.L:98
            VOD.L:87
            BP.L:1460.4
            Dow:12,960
            Oil:84.67
            BT.L:102
            VOD.L:90
            BP.L:1455.95
            Dow:12,965
            Oil:84
            BT.L:1103
            VOD.L:92.3
            BP.L:1453
            Dow:12,966
            Oil:83.5
            BT.L:104.5
            VOD.L:92.4
            BP.L:1452
            Dow:12,860
            Oil:83.49
            BT.L:105.9
            VOD.L:92.3
            BP.L:1455.3
            Dow:12,970.8
            Oil:83.48
            BT.L:107
            VOD.L:92.5
            BP.L:1449
            Dow:12500
            Oil:82.5
            BT.L:106
            VOD.L:93.4
            BP.L:1448
            Dow:12670.3
            Oil:84.6
            BT.L:98
            VOD.L:94
            BP.L:1450
            Dow:12,800
            Oil:84.9
            BT.L:97
            VOD.L:95
            BP.L:1450.1
            Dow:12,830.2
            Oil:85.6";


        public IList<ISourceItem> GetData()
        {
            var result = new List<ISourceItem>();

            foreach (var item in data.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))

            {
                if (string.IsNullOrEmpty(item))
                    continue;

                var items = item.Trim().Split(':');
                result.Add(new Instrument { Name = items[0], Price = double.Parse(items[1]) });

            }

            return result;
        }
    }
}