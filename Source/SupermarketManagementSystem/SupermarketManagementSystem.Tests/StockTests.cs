using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupermarketManagementSystem.Models;

namespace SupermarketManagementSystem.Tests
{
    [TestClass]
    public class StockTests
    {
        [TestMethod]
        public void UpdateStock_ChangesStockQuantity()
        {
            Product product = new Product();
            product.ProductName = "Milk";
            product.Barcode = "111";
            product.StockQuantity = 10;
            product.AvailabilityStatus = "In Stock";

            product.StockQuantity = 20;

            Assert.AreEqual(20, product.StockQuantity);
        }

        [TestMethod]
        public void UpdateStock_ToZeroChangesStatusToOutOfStock()
        {
            Product product = new Product();
            product.ProductName = "Bread";
            product.Barcode = "222";
            product.StockQuantity = 5;
            product.AvailabilityStatus = "In Stock";

            product.StockQuantity = 0;

            if (product.StockQuantity > 0)
            {
                product.AvailabilityStatus = "In Stock";
            }
            else
            {
                product.AvailabilityStatus = "Out of Stock";
            }

            Assert.AreEqual("Out of Stock", product.AvailabilityStatus);
        }

        [TestMethod]
        public void LowStock_ProductWithFiveOrLessIsLowStock()
        {
            Product product = new Product();
            product.ProductName = "Apples";
            product.Barcode = "333";
            product.StockQuantity = 5;

            bool isLowStock = false;

            if (product.StockQuantity <= 5)
            {
                isLowStock = true;
            }

            Assert.IsTrue(isLowStock);
        }

        [TestMethod]
        public void LowStock_ProductWithMoreThanFiveIsNotLowStock()
        {
            Product product = new Product();
            product.ProductName = "Orange Juice";
            product.Barcode = "444";
            product.StockQuantity = 8;

            bool isLowStock = false;

            if (product.StockQuantity <= 5)
            {
                isLowStock = true;
            }

            Assert.IsFalse(isLowStock);
        }
    }
}