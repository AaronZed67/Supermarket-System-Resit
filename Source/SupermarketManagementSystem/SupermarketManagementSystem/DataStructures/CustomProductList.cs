using SupermarketManagementSystem.Models

namespace SupermarketManagementSystem.DataStructures
{
    public class CustomProductList
    {
        private Product[] products
        private int count;

        public CustomProductList()
        {
            products = new Product[100]
            count = 0;
        }

        public void AddProduct(Product product)
        {
            if count < products.Length
            {
                products[count] = product;
                count++;
            }
        }

        public int GetCount()
        {
            return count
        }
    }
}