using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupermarketManagementSystem.DataStructures;
using SupermarketManagementSystem.Models;

namespace SupermarketManagementSystem.Tests
{
    [TestClass]
    public class CustomSupplierListTests
    {
        [TestMethod]
        public void AddSupplier_IncreasesCount()
        {
            CustomSupplierList list = new CustomSupplierList();

            Supplier supplier = new Supplier();
            supplier.SupplierName = "Fresh Foods Ltd";
            supplier.ContactNumber = "07123456789";

            list.AddSupplier(supplier);

            Assert.AreEqual(1, list.GetCount());
        }

        [TestMethod]
        public void SearchByName_ReturnsCorrectSupplier()
        {
            CustomSupplierList list = new CustomSupplierList();

            Supplier supplier = new Supplier();
            supplier.SupplierId = 1;
            supplier.SupplierName = "Daily Dairy Supplies";
            supplier.ContactNumber = "07234567890";

            list.AddSupplier(supplier);

            Supplier result = list.SearchByName("Daily Dairy Supplies");

            Assert.IsNotNull(result);
            Assert.AreEqual("07234567890", result.ContactNumber);
        }

        [TestMethod]
        public void SearchById_ReturnsCorrectSupplier()
        {
            CustomSupplierList list = new CustomSupplierList();

            Supplier supplier = new Supplier();
            supplier.SupplierId = 2;
            supplier.SupplierName = "Bakery Wholesale Ltd";
            supplier.ContactNumber = "07345678901";

            list.AddSupplier(supplier);

            Supplier result = list.SearchById("2");

            Assert.IsNotNull(result);
            Assert.AreEqual("Bakery Wholesale Ltd", result.SupplierName);
        }

        [TestMethod]
        public void SearchByName_ReturnsNull_WhenSupplierDoesNotExist()
        {
            CustomSupplierList list = new CustomSupplierList();

            Supplier supplier = new Supplier();
            supplier.SupplierId = 1;
            supplier.SupplierName = "Fresh Foods Ltd";
            supplier.ContactNumber = "07123456789";

            list.AddSupplier(supplier);

            Supplier result = list.SearchByName("Unknown Supplier");

            Assert.IsNull(result);
        }
    }
}