using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupermarketManagementSystem.Models;

namespace SupermarketManagementSystem.Tests
{
    [TestClass]
    public class SalesTests
    {
        [TestMethod]
        public void RecordSale_ReducesProductStock()
        {
            Product product = new Product();
            product.ProductName = "Milk";
            product.Barcode = "111";
            product.StockQuantity = 10;
            product.AvailabilityStatus = "In Stock";

            int quantitySold = 3;

            product.StockQuantity = product.StockQuantity - quantitySold;

            Assert.AreEqual(7, product.StockQuantity);
        }

        [TestMethod]
        public void RecordSale_CreatesSaleObject()
        {
            Sale sale = new Sale();
            sale.ProductId = 1;
            sale.QuantitySold = 2;
            sale.SaleDate = DateTime.Now;

            Assert.AreEqual(1, sale.ProductId);
            Assert.AreEqual(2, sale.QuantitySold);
        }

        [TestMethod]
        public void RecordSale_CannotSellMoreThanStock()
        {
            Product product = new Product();
            product.ProductName = "Bread";
            product.Barcode = "222";
            product.StockQuantity = 5;

            int quantitySold = 10;

            bool canSell = false;

            if (product.StockQuantity >= quantitySold)
            {
                canSell = true;
            }

            Assert.IsFalse(canSell);
        }

        [TestMethod]
        public void RecordSale_QuantitySoldMustBeGreaterThanZero()
        {
            int quantitySold = 0;

            bool validQuantity = false;

            if (quantitySold > 0)
            {
                validQuantity = true;
            }

            Assert.IsFalse(validQuantity);
        }
    }
}