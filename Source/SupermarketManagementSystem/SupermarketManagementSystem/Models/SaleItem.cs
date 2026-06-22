namespace SupermarketManagementSystem.Models
{
    public class SaleItem
    {
        public int SaleItemId { get; set; }

        public int SaleId { get; set; }

        public int ProductId { get; set; }

        public int QuantitySold { get; set; }

        public decimal UnitPrice { get; set; }
    }
}