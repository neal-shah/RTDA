using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace RealtimeInstrumentDataApp.Tests
{
    [TestFixture]
    public class DataReaderServiceTests
    {
        [TestCase(0, "BT.L:100")]
        [TestCase(4, "Oil:86.67")]
        [TestCase(24, "Oil:83.49")]
        public void GetLineAsStringFromSampleData(int line, string expected)
        {
            // Arrange
            var drs = new Service.DataReaderService();

            // Act
            var actual = drs.ReadLineFromSampleData(line);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0)]
        [TestCase(4)]
        [TestCase(24)]
        public void GetInstrumentCurrentPriceDictionary(int line)
        {
            // Arrange
            var drs = new Service.DataReaderService();
            var expected = new Dictionary<string, double>();

            if (line == 0)
            {
                expected.Add("BT.L", 100);
            } else if (line == 4)
            {
                expected.Add("Oil", 86.67);
            } else if (line == 24)
            {
                expected.Add("Oil", 83.49);
            }
            
            // Act
            var actual = drs.GetInstrumentCurrentPrice(line);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
