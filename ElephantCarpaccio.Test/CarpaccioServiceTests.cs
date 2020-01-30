using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElephantCarpaccio.Service;
using ElephantCarpaccio.Models;

namespace ElephantCarpaccio.Test
{
    [TestClass]
    public class CarpaccioServiceTests
    {
        //Accept 3 inputs from the user:
        // - How many items
        // - Price per item
        // - 2-letter state code
        
        //Output the total price.Give a discount based on the total price.
        //Add state tax based on the state and the discounted price.

        //Pricing Matrix
        //Order Value       Discount Rate       State       Tax Rate 
        //$1000               3%                  UT          6.85%
        //$5000               5%                  NV          8.00%
        //$7000               7%                  TX          6.25%
        //$10000              10%                 AL          4.85%
        //$50000              15%                 CA          8.25%

       [TestMethod]
        public void GivenQuantityAndProductPriceAndState_ReturnTotalCalculatedPriceWithoutAnyDiscount()
        {
            const decimal expectedTotal = 246873.79M;
            const int expectedPercentage = 0;
            var input = new CarpaccioModel { Quantity = "978", ProductPrice = "270.99", SelectedState = States.Utah };

            var actual = new CarpaccioService().PriceCalculator(input);

            Assert.AreEqual(expectedTotal, actual.Total);
            Assert.AreEqual(expectedPercentage, actual.AppliedPercentage);
        }

        [TestMethod]
        public void GivenQuantityAndProductPriceAndState_ReturnTotalCalculatedPriceWith3PercentDiscount()
        {
            const decimal expectedTotal = 1338.60M;
            const int expectedPercentage = 3;
            var input = new CarpaccioModel { Quantity = "2", ProductPrice = "750.00", SelectedState = States.Nevada };

            var actual = new CarpaccioService().PriceCalculator(input);

            Assert.AreEqual(expectedTotal, actual.Total);
            Assert.AreEqual(expectedPercentage, actual.AppliedPercentage);
        }

        [TestMethod]
        public void GivenQuantityAndProductPriceAndState_ReturnTotalCalculatedPriceWith5PercentDiscount()
        {
            const decimal expectedTotal = 4788.00M;
            const int expectedPercentage = 5;
            var input = new CarpaccioModel { Quantity = "7", ProductPrice = "750.00", SelectedState = States.Alabama };

            var actual = new CarpaccioService().PriceCalculator(input);

            Assert.AreEqual(expectedTotal, actual.Total);
            Assert.AreEqual(expectedPercentage, actual.AppliedPercentage);
        }

        [TestMethod]
        public void GivenQuantityAndProductPriceAndState_ReturnTotalCalculatedPriceWith7PercentDiscount()
        {
            const decimal expectedTotal = 6399.56M;
            const int expectedPercentage = 7;
            var input = new CarpaccioModel { Quantity = "10", ProductPrice = "750.00", SelectedState = States.California };

            var actual = new CarpaccioService().PriceCalculator(input);

            Assert.AreEqual(expectedTotal, actual.Total);
            Assert.AreEqual(expectedPercentage, actual.AppliedPercentage);
        }

        [TestMethod]
        public void GivenQuantityAndProductPriceAndState_ReturnTotalCalculatedPriceWith10PercentDiscount()
        {
            const decimal expectedTotal = 8802.68M;
            const int expectedPercentage = 10;
            var input = new CarpaccioModel { Quantity = "14", ProductPrice = "750.00", SelectedState = States.Utah };

            var actual = new CarpaccioService().PriceCalculator(input);

            Assert.AreEqual(expectedTotal, actual.Total);
            Assert.AreEqual(expectedPercentage, actual.AppliedPercentage);
        }

        [TestMethod]
        public void GivenQuantityAndProductPriceAndState_ReturnTotalCalculatedPriceWith15PercentDiscount()
        {
            const decimal expectedTotal = 39588.75M;
            const int expectedPercentage = 15;
            var input = new CarpaccioModel { Quantity = "5", ProductPrice = "10000.00", SelectedState = States.Utah };

            var actual = new CarpaccioService().PriceCalculator(input);

            Assert.AreEqual(expectedTotal, actual.Total);
            Assert.AreEqual(expectedPercentage, actual.AppliedPercentage);
        }
    }
}
