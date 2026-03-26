using System;
using System.Collections.Generic;
using System.Text;

namespace ExempleTestMongo.DTOs
{
    public class ProductRequestDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
