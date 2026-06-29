using SupermarketManagementSystem.Models;

namespace SupermarketManagementSystem.DataStructures
{
    public class CustomProductList
    {
        private Product[] products;
        private int count;

        public CustomProductList()
        {
            products = new Product[100];
            count = 0;
        }

        public void AddProduct(Product product)
        {
            if (count < products.Length)
            {
                products[count] = product;
                count++;
            }
        }

        public Product SearchByName(string productName)
        {
            for (int i = 0; i < count; i++)
            {
                if (products[i].ProductName == productName)
                {
                    return products[i];
                }
            }

            return null;
        }

        public Product SearchByBarcode(string barcode)
        {
            for (int i = 0; i < count; i++)
            {
                if (products[i].Barcode == barcode)
                {
                    return products[i];
                }
            }

            return null;
        }

        public int GetCount()
        {
            return count;
        }
    }
}