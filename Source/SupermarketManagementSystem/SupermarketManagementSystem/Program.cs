using SupermarketManagementSystem.Models;
using SupermarketManagementSystem.Data;
using SupermarketManagementSystem.DataStructures;

namespace SupermarketManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = -1;

            while (choice != 0)
            {
                Console.WriteLine("LOCAL SUPERMARKET MANAGEMENT SYSTEM");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Search Product");
                Console.WriteLine("4. Update Stock");
                Console.WriteLine("5. Record Sale");
                Console.WriteLine("6. Sales Report");
                Console.WriteLine("7. Low Stock Report");
                Console.WriteLine("8. Remove Product");
                Console.WriteLine("9. Add Supplier");
                Console.WriteLine("10. View Suppliers");
                Console.WriteLine("11. Search Supplier");
                Console.WriteLine("12. Remove Supplier");
                Console.WriteLine("13. Update Product Supplier");
                Console.WriteLine("14. Update Product Price");
                Console.WriteLine("0. Exit");
                Console.WriteLine();

                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Product newProduct = new Product();

                    Console.Write("Enter Product Name: ");
                    newProduct.ProductName = Console.ReadLine();

                    if (newProduct.ProductName == "")
                    {
                        Console.WriteLine("Product name is required.");
                        continue;
                    }

                    Console.Write("Enter Barcode: ");
                    newProduct.Barcode = Console.ReadLine();

                    if (newProduct.Barcode == "")
                    {
                        Console.WriteLine("Barcode is required.");
                        continue;
                    }

                    bool barcodeExists = false;

                    using (SupermarketDbContext db = new SupermarketDbContext())
                    {
                        foreach (Product product in db.Products)
                        {
                            if (product.Barcode == newProduct.Barcode)
                            {
                                barcodeExists = true;
                            }
                        }
                    }

                    if (barcodeExists == true)
                    {
                        Console.WriteLine("A product with this barcode already exists.");
                        continue;
                    }

                    Console.Write("Enter Price: ");
                    string priceInput = Console.ReadLine();

                    decimal price;

                    bool priceValid = decimal.TryParse(priceInput, out price);

                    if (priceValid == false)
                    {
                        Console.WriteLine("Price must be a number.");
                        continue;
                    }

                    if (price <= 0)
                    {
                        Console.WriteLine("Price must be greater than 0.");
                        continue;
                    }

                    newProduct.Price = price;

                    Console.Write("Enter Stock Quantity: ");
                    string stockInput = Console.ReadLine();

                    int stockQuantity;

                    bool stockValid = int.TryParse(stockInput, out stockQuantity);

                    if (stockValid == false)
                    {
                        Console.WriteLine("Stock quantity must be a whole number.");
                        continue;
                    }

                    if (stockQuantity < 0)
                    {
                        Console.WriteLine("Stock quantity cannot be negative.");
                        continue;
                    }

                    newProduct.StockQuantity = stockQuantity;

                    if (newProduct.StockQuantity > 0)
                    {
                        newProduct.AvailabilityStatus = "In Stock";
                    }
                    else
                    {
                        newProduct.AvailabilityStatus = "Out of Stock";
                    }

                    newProduct.RestockDate = DateTime.Now;

                    Console.Write("Enter Category ID: ");
                    string categoryInput = Console.ReadLine();

                    int categoryId;

                    bool categoryValid = int.TryParse(categoryInput, out categoryId);

                    if (categoryValid == false)
                    {
                        Console.WriteLine("Category ID must be a whole number.");
                        continue;
                    }

                    newProduct.CategoryId = categoryId;

                    Console.Write("Enter Supplier ID: ");
                    string supplierInput = Console.ReadLine();

                    int supplierId;

                    bool supplierValid = int.TryParse(supplierInput, out supplierId);

                    if (supplierValid == false)
                    {
                        Console.WriteLine("Supplier ID must be a whole number.");
                        continue;
                    }

                    newProduct.SupplierId = supplierId;

                    using (SupermarketDbContext db = new SupermarketDbContext())
                    {
                        db.Products.Add(newProduct);
                        db.SaveChanges();
                    }

                    Console.WriteLine("Product added successfully.");
                }

                else if (choice == 2)
                {
                    using (SupermarketDbContext db = new SupermarketDbContext())
                    {
                        bool productsFound = false;

                        foreach (Product product in db.Products)
                        {
                            Console.WriteLine("ID: " + product.ProductId);
                            Console.WriteLine("Name: " + product.ProductName);
                            Console.WriteLine("Barcode: " + product.Barcode);
                            Console.WriteLine("Price: " + product.Price);
                            Console.WriteLine("Stock: " + product.StockQuantity);
                            Console.WriteLine("Supplier ID: " + product.SupplierId);
                            Console.WriteLine("-----------------------------");

                            productsFound = true;
                        }

                        if (productsFound == false)
                        {
                            Console.WriteLine("No products have been added yet.");
                        }
                    }
                }

                else if (choice == 3)
                {
                    Console.Write("Enter product name or barcode to search: ");
                    string searchText = Console.ReadLine();

                    CustomProductList productList = new CustomProductList();

                    using (SupermarketDbContext db = new SupermarketDbContext())
                    {
                        foreach (Product product in db.Products)
                        {
                            productList.AddProduct(product);
                        }
                    }

                    Product foundProduct = productList.SearchByName(searchText);

                    if (foundProduct == null)
                    {
                        foundProduct = productList.SearchByBarcode(searchText);
                    }

                    if (foundProduct != null)
                    {
                        Console.WriteLine("Product found:");
                        Console.WriteLine("ID: " + foundProduct.ProductId);
                        Console.WriteLine("Name: " + foundProduct.ProductName);
                        Console.WriteLine("Barcode: " + foundProduct.Barcode);
                        Console.WriteLine("Price: " + foundProduct.Price);
                        Console.WriteLine("Stock: " + foundProduct.StockQuantity);
                        Console.WriteLine("Supplier ID: " + foundProduct.SupplierId);
                        Console.WriteLine("-----------------------------");
                    }
                    else
                    {
                        Console.WriteLine("Product not found.");
                    }
                }

                else if (choice == 4)
                {
                    Console.Write("Enter product ID or product name to update stock: ");
                    string searchText = Console.ReadLine();

                    Product productToUpdate = null;
                    bool found = false;

                    using (SupermarketDbContext db = new SupermarketDbContext())
                    {
                        foreach (Product product in db.Products)
                        {
                            if (product.ProductId.ToString() == searchText || product.ProductName == searchText)
                            {
                                productToUpdate = product;
                                found = true;
                            }
                        }

                        if (found == true)
                        {
                            Console.Write("Enter new stock quantity: ");
                            string stockInput = Console.ReadLine();

                            int newStockQuantity;

                            bool stockValid = int.TryParse(stockInput, out newStockQuantity);

                            if (stockValid == false)
                            {
                                Console.WriteLine("Stock quantity must be a whole number.");
                                continue;
                            }

                            if (newStockQuantity < 0)
                            {
                                Console.WriteLine("Stock quantity cannot be negative.");
                                continue;
                            }

                            productToUpdate.StockQuantity = newStockQuantity;

                            if (productToUpdate.StockQuantity > 0)
                            {
                                productToUpdate.AvailabilityStatus = "In Stock";
                            }
                            else
                            {
                                productToUpdate.AvailabilityStatus = "Out of Stock";
                            }

                            db.SaveChanges();

                            Console.WriteLine("Stock updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }
                    }
                }

                else if (choice == 5)
                {
                    Console.Write("Enter product ID for sale: ");
                    int productId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter quantity sold: ");
                    int quantitySold = Convert.ToInt32(Console.ReadLine());

                    if (quantitySold <= 0)
                    {
                        Console.WriteLine("Quantity sold must be greater than 0.");
                        continue;
                    }

                    Product productToSell = null;
                    bool found = false;

                    using (SupermarketDbContext db = new SupermarketDbContext())
                    {
                        foreach (Product product in db.Products)
                        {
                            if (product.ProductId == productId)
                            {
                                productToSell = product;
                                found = true;
                            }
                        }

                        if (found == true)
                        {
                            if (productToSell.StockQuantity >= quantitySold)
                            {
                                productToSell.StockQuantity = productToSell.StockQuantity - quantitySold;

                                if (productToSell.StockQuantity > 0)
                                {
                                    productToSell.AvailabilityStatus = "In Stock";
                                }
                                else
                                {
                                    productToSell.AvailabilityStatus = "Out of Stock";
                                }

                                Sale newSale = new Sale();
                                newSale.ProductId = productId;
                                newSale.QuantitySold = quantitySold;
                                newSale.SaleDate = DateTime.Now;

                                db.Sales.Add(newSale);
                                db.SaveChanges();

                                Console.WriteLine("Sale recorded successfully.");
                                Console.WriteLine("Remaining stock: " + productToSell.StockQuantity);
                            }
                            else
                            {
                                Console.WriteLine("Not enough stock to complete sale.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }
                    }
                }

                else if (choice == 6)
                {
                    Console.WriteLine("SALES REPORT");
                    Console.WriteLine("------------");

                    bool salesFound = false;

                    using (SupermarketDbContext db = new SupermarketDbContext())
                    {
                        foreach (Sale sale in db.Sales)
                        {
                            Console.WriteLine("Sale ID: " + sale.SaleId);
                            Console.WriteLine("Product ID: " + sale.ProductId);
                            Console.WriteLine("Quantity Sold: " + sale.QuantitySold);
                            Console.WriteLine("Sale Date: " + sale.SaleDate);
                            Console.WriteLine("-----------------------------");

                            salesFound = true;
                        }
                    }

                    if (salesFound == false)
                    {
                        Console.WriteLine("No sales have been recorded.");
                    }
                }

                else if (choice == 7)
                {
                    Console.WriteLine("LOW STOCK REPORT");
                    Console.WriteLine("----------------");

                    bool lowStockFound = false;

                    using (SupermarketDbContext db = new SupermarketDbContext())
                    {
                        foreach (Product product in db.Products)
                        {
                            if (product.StockQuantity <= 5)
                            {
                                Console.WriteLine("Product ID: " + product.ProductId);
                                Console.WriteLine("Product Name: " + product.ProductName);
                                Console.WriteLine("Barcode: " + product.Barcode);
                                Console.WriteLine("Current Stock: " + product.StockQuantity);
                                Console.WriteLine("Status: " + product.AvailabilityStatus);
                                Console.WriteLine("Supplier ID: " + product.SupplierId);
                                Console.WriteLine("-----------------------------");

                                lowStockFound = true;
                            }
                        }
                    }

                    if (lowStockFound == false)
                    {
                        Console.WriteLine("No low stock products found.");
                    }
                }

                else if (choice == 8)
                {
                    Console.Write("Enter product ID to remove: ");
                    int productId = Convert.ToInt32(Console.ReadLine());

                    Product productToRemove = null;
                    bool found = false;

                    using (SupermarketDbContext db = new SupermarketDbContext())
                    {
                        foreach (Product product in db.Products)
                        {
                            if (product.ProductId == productId)
                            {
                                productToRemove = product;
                                found = true;
                            }
                        }

                        if (found == true)
                        {
                            db.Products.Remove(productToRemove);
                            db.SaveChanges();

                            Console.WriteLine("Product removed successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }
                    }
                }

                else if (choice == 9)
                {
                    Supplier newSupplier = new Supplier();

                    Console.Write("Enter Supplier Name: ");
                    newSupplier.SupplierName = Console.ReadLine();

                    if (newSupplier.SupplierName == "")
                    {
                        Console.WriteLine("Supplier name is required.");
                        continue;
                    }

                    Console.Write("Enter Contact Number: ");
                    newSupplier.ContactNumber = Console.ReadLine();

                    if (newSupplier.ContactNumber == "")
                    {
                        Console.WriteLine("Supplier contact number is required.");
                        continue;
                    }

                    using (SupermarketDbContext db = new SupermarketDbContext())
                    {
                        db.Suppliers.Add(newSupplier);
                        db.SaveChanges();
                    }

                    Console.WriteLine("Supplier added successfully.");
                }

                else if (choice == 10)
                {
                    Console.WriteLine("SUPPLIER LIST");
                    Console.WriteLine("-------------");

                    bool suppliersFound = false;

                    using (SupermarketDbContext db = new SupermarketDbContext())
                    {
                        foreach (Supplier supplier in db.Suppliers)
                        {
                            Console.WriteLine("Supplier ID: " + supplier.SupplierId);
                            Console.WriteLine("Supplier Name: " + supplier.SupplierName);
                            Console.WriteLine("Contact Number: " + supplier.ContactNumber);
                            Console.WriteLine("-----------------------------");

                            suppliersFound = true;
                        }
                    }

                    if (suppliersFound == false)
                    {
                        Console.WriteLine("No suppliers have been added yet.");
                    }
                }


                else if (choice == 11)
                {
                    Console.Write("Enter supplier ID or supplier name to search: ");
                    string searchText = Console.ReadLine();

                    CustomSupplierList supplierList = new CustomSupplierList();

                    using (SupermarketDbContext db = new SupermarketDbContext())
                    {
                        foreach (Supplier supplier in db.Suppliers)
                        {
                            supplierList.AddSupplier(supplier);
                        }
                    }

                    Supplier foundSupplier = supplierList.SearchById(searchText);

                    if (foundSupplier == null)
                    {
                        foundSupplier = supplierList.SearchByName(searchText);
                    }

                    if (foundSupplier != null)
                    {
                        Console.WriteLine("Supplier found:");
                        Console.WriteLine("Supplier ID: " + foundSupplier.SupplierId);
                        Console.WriteLine("Supplier Name: " + foundSupplier.SupplierName);
                        Console.WriteLine("Contact Number: " + foundSupplier.ContactNumber);
                        Console.WriteLine("-----------------------------");
                    }
                    else
                    {
                        Console.WriteLine("Supplier not found.");
                    }
                }

                else if (choice == 12)
                {
                    Console.Write("Enter supplier ID to remove: ");
                    int supplierId = Convert.ToInt32(Console.ReadLine());

                    Supplier supplierToRemove = null;
                    bool found = false;

                    using (SupermarketDbContext db = new SupermarketDbContext())
                    {
                        foreach (Supplier supplier in db.Suppliers)
                        {
                            if (supplier.SupplierId == supplierId)
                            {
                                supplierToRemove = supplier;
                                found = true;
                            }
                        }

                        if (found == true)
                        {
                            db.Suppliers.Remove(supplierToRemove);
                            db.SaveChanges();

                            Console.WriteLine("Supplier removed successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Supplier not found.");
                        }
                    }
                }

                else if (choice == 13)
                {
                    Console.Write("Enter product ID to update supplier: ");
                    int productId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter new supplier ID: ");
                    int newSupplierId = Convert.ToInt32(Console.ReadLine());

                    bool productFound = false;
                    bool supplierFound = false;

                    Product productToUpdate = null;

                    using (SupermarketDbContext db = new SupermarketDbContext())
                    {
                        foreach (Supplier supplier in db.Suppliers)
                        {
                            if (supplier.SupplierId == newSupplierId)
                            {
                                supplierFound = true;
                            }
                        }

                        if (supplierFound == true)
                        {
                            foreach (Product product in db.Products)
                            {
                                if (product.ProductId == productId)
                                {
                                    productToUpdate = product;
                                    productFound = true;
                                }
                            }

                            if (productFound == true)
                            {
                                productToUpdate.SupplierId = newSupplierId;
                                db.SaveChanges();

                                Console.WriteLine("Product supplier updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Product not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Supplier not found.");
                        }
                    }
                }



                else if (choice == 14)
                {
                    Console.Write("Enter product ID to update price: ");
                    int productId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter new product price: ");
                    decimal newPrice = Convert.ToDecimal(Console.ReadLine());

                    Product productToUpdate = null;
                    bool found = false;

                    using (SupermarketDbContext db = new SupermarketDbContext())
                    {
                        foreach (Product product in db.Products)
                        {
                            if (product.ProductId == productId)
                            {
                                productToUpdate = product;
                                found = true;
                            }
                        }

                        if (found == true)
                        {
                            if (newPrice > 0)
                            {
                                productToUpdate.Price = newPrice;
                                db.SaveChanges();

                                Console.WriteLine("Product price updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Price must be greater than 0.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }
                    }
                }


                else if (choice == 0)
                {
                    Console.WriteLine("Exiting program...");
                }

                else
                {
                    Console.WriteLine("Invalid choice.");
                }

                Console.WriteLine();
            }
        }
    }
}