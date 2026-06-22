using SupermarketManagementSystem.Models;
using SupermarketManagementSystem.Data;

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
                Console.WriteLine("0. Exit");
                Console.WriteLine();

                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());


                if (choice == 1)
                {
                    Product newProduct = new Product();

                    Console.Write("Enter Product Name: ");
                    newProduct.ProductName = Console.ReadLine();

                    Console.Write("Enter Barcode: ");
                    newProduct.Barcode = Console.ReadLine();

                    Console.Write("Enter Price: ");
                    newProduct.Price = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Enter Stock Quantity: ");
                    newProduct.StockQuantity = Convert.ToInt32(Console.ReadLine());

                    newProduct.RestockDate = DateTime.Now;

                    if (newProduct.StockQuantity > 0)
                    {
                        newProduct.AvailabilityStatus = "In Stock";
                    }
                    else
                    {
                        newProduct.AvailabilityStatus = "Out of Stock";
                    }

                    Console.Write("Enter Category ID: ");
                    newProduct.CategoryId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Supplier ID: ");
                    newProduct.SupplierId = Convert.ToInt32(Console.ReadLine());

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




            }
        }
            }
        }
    
