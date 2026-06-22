namespace SupermarketManagementSystem.Models
{
    public class Product
    {
        public int ProductId { get; set; }  // stores info about the supermarket products
        public string ProductName { get; set; }  // makes it easier to identify for each product uniquely 
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }   // tell you the number of how much something is available in stock
        public DateTime RestockDate { get; set; }
        public string AvailabilityStatus { get; set; }
        public int CategoryId { get; set; } // links products to catergory and suplier
        public int SupplierId { get; set; }

    }
}