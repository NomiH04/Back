using System;

namespace LibreriaBoscoso.Models
{
    public class Order  // Hacer la clase pública
    {
        public int OrderId { get; set; }

        public int? StoreId { get; set; }

        public int? UserId { get; set; }

        public int? SupplierId { get; set; }

        public DateTime? OrderDate { get; set; }

        public string Status { get; set; }
    }
}

