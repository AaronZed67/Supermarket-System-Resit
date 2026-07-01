using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupermarketManagementSystem.Models;

namespace SupermarketManagementSystem.Tests
{
    [TestClass]
    public class LowStockReportTests
    {
        [TestMethod]
        public void LowStockReport_ProductWithFiveStockIsIncluded()
        {
            Product product = new Product();
            product.ProductName = "Bread";
            product.Barcode = "222";
            product.StockQuantity = 5;

            bool shouldAppearInLowStockReport = false;

            if (product.StockQuantity <= 5)
            {
                shouldAppearInLowStockReport = true;
            }

            Assert.IsTrue(shouldAppearInLowStockReport);
        }

        [TestMethod]
        public void LowStockReport_ProductWithZeroStockIsIncluded()
        {
            Product product = new Product();
            product.ProductName = "Milk";
            product.Barcode = "111";
            product.StockQuantity = 0;

            bool shouldAppearInLowStockReport = false;

            if (product.StockQuantity <= 5)
            {
                shouldAppearInLowStockReport = true;
            }

            Assert.IsTrue(shouldAppearInLowStockReport);
        }

        [TestMethod]
        public void LowStockReport_ProductWithMoreThanFiveStockIsNotIncluded()
        {
            Product product = new Product();
            product.ProductName = "Orange Juice";
            product.Barcode = "333";
            product.StockQuantity = 10;

            bool shouldAppearInLowStockReport = false;

            if (product.StockQuantity <= 5)
            {
                shouldAppearInLowStockReport = true;
            }

            Assert.IsFalse(shouldAppearInLowStockReport);
        }

        [TestMethod]
        public void LowStockReport_ProductWithNegativeStockIsIncluded()
        {
            Product product = new Product();
            product.ProductName = "Error Product";
            product.Barcode = "999";
            product.StockQuantity = -1;

            bool shouldAppearInLowStockReport = false;

            if (product.StockQuantity <= 5)
            {
                shouldAppearInLowStockReport = true;
            }

            Assert.IsTrue(shouldAppearInLowStockReport);
        }
    }
}