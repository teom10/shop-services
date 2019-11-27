using System;
using System.Collections.Generic;
using System.Text;

namespace shopping_entities
{
    public class sale_detail
    {
        public Guid? Id { get; set; }
        public decimal? Count { get; set; }
        public Guid? ProductId { get; set; }
        public decimal? Total { get; set; }
        public decimal? TotalWithTax { get; set; }

    }
}
