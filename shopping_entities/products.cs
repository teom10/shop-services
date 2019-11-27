using System;
using System.Collections.Generic;
using System.Text;

namespace shopping_entities
{
    public class products
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceWithTax { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
    }
}
