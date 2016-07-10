using System.Collections.Generic;
using NUnit.Framework;

namespace RealtimeInstrumentDataApp.Tests
{
    [TestFixture]
    public class InstrumentPriceStateTests
    {
        private GuiInstrument _guiInstrument;
        private List<double> _prices;

        [SetUp]
        public void InitialSetup()
        {
            _guiInstrument = new GuiInstrument();
            _guiInstrument.Prices = new List<double>();
            _prices = new List<double>()
            {
                15.0,
                16.3,
                14.2,
                14.2
            };
        }

        [Test]
        public void GetStateOfEachChangeInPrice()
        {
            // Arrange
            var expectedStateChangeFromPrevious = new List<string>()
            {
                "up",
                "up",
                "down",
                "nochange"
            };

            var actualStateChangeFromPrevious = new List<string>();


            // Act
            foreach (var price in _prices)
            {
                _guiInstrument.AddPrice(price);

                actualStateChangeFromPrevious.Add(_guiInstrument.State);
            }

            // Assert
            CollectionAssert.AreEqual(expectedStateChangeFromPrevious, actualStateChangeFromPrevious);
        }


    }
}
