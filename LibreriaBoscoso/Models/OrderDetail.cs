namespace LibreriaBoscoso.Models
{
    public class OrderDetail  // Hacer la clase pública
    {
        public int OrderId { get; set; }

        public int BookId { get; set; }

        public int Quantity { get; set; }
    }
}
