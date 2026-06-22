using SupermarketManagementSystem.Models;
using SupermarketManagementSystem.Data;

namespace SupermarketManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[50];  //temporary
            int productCount = 0;

            Sale[] sales = new Sale[50];
            int saleCount = 0;

            int choice = -1;

            while (choice != 0)
            {
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
            }
        }
    }
}