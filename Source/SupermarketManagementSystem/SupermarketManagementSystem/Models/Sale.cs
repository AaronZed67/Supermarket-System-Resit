namespace SupermarketManagementSystem.Models
{

    public class Sale // stores payment info
    {

        public int SaleId { get; set; } // sale id

        public int ProductId { get; set; }
        public int QuantitySold { get; set; } // how many products sold in the transaction
        public DateTime SaleDate { get; set; }
    }
}