namespace SupermarketManagementSystem.Models
{
    public class Stock
    {
        public int StockId { get; set; }

        public int ProductId { get; set; }

        public int QuantityAvailable { get; set; }

        public DateTime LastUpdated { get; set; }

        public DateTime RestockDate { get; set; }
    }
}