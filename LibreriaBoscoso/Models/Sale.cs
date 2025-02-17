using System;

namespace LibreriaBoscoso.Models
{
    public class Sale  // Cambié 'class' por 'public class'
    {
        public int SaleId { get; set; }

        public int? UserId { get; set; }

        public int? StoreId { get; set; }

        public DateTime? SaleDate { get; set; }

        public decimal Total { get; set; }
    }
}
