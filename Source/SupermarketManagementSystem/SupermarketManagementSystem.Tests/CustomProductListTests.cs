using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupermarketManagementSystem.DataStructures;
using SupermarketManagementSystem.Models;

namespace SupermarketManagementSystem.Tests
{
    [TestClass]
    public class CustomProductListTests
    {
        [TestMethod]
        public void AddProduct_IncreasesCount()
        {
            CustomProductList list = new CustomProductList();

            Product product = new Product();
            product.ProductName = "Milk";
            product.Barcode = "111";
            product.Price = 1.50m;
            product.StockQuantity = 10;

            list.AddProduct(product);

            Assert.AreEqual(1, list.GetCount());
        }

        [TestMethod]
        public void SearchByName_ReturnsCorrectProduct()
        {
            CustomProductList list = new CustomProductList();

            Product product = new Product();
            product.ProductName = "Bread";
            product.Barcode = "222";
            product.Price = 1.20m;
            product.StockQuantity = 5;

            list.AddProduct(product);

            Product result = list.SearchByName("Bread");

            Assert.IsNotNull(result);
            Assert.AreEqual("222", result.Barcode);
        }

        [TestMethod]
        public void SearchByBarcode_ReturnsCorrectProduct()
        {
            CustomProductList list = new CustomProductList();

            Product product = new Product();
            product.ProductName = "Eggs";
            product.Barcode = "333";
            product.Price = 2.50m;
            product.StockQuantity = 20;

            list.AddProduct(product);

            Product result = list.SearchByBarcode("333");

            Assert.IsNotNull(result);
            Assert.AreEqual("Eggs", result.ProductName);
        }

        [TestMethod]
        public void SearchByName_ReturnsNull_WhenProductDoesNotExist()
        {
            CustomProductList list = new CustomProductList();

            Product product = new Product();
            product.ProductName = "Milk";
            product.Barcode = "111";

            list.AddProduct(product);

            Product result = list.SearchByName("Rice");

            Assert.IsNull(result);
        }
    }
}