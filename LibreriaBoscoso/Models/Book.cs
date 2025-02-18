﻿using System;

namespace LibreriaBoscoso.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime PublicationDate { get; set; }

        public string Publisher { get; set; }
    }
}
