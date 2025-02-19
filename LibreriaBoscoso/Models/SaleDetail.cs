namespace LibreriaBoscoso.Models
{
    public class SaleDetail  // Hacer la clase pública
    {
        public int SaleId { get; set; }

        public int BookId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
