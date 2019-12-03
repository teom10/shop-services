﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace domain.entities
{
    [Table("sale_detail")]
    public class sale_detail: baseentity<Guid?>
    { 
        public decimal? Count { get; set; }
        public Guid? ProductId { get; set; }
        public decimal? Total { get; set; }
        public decimal? TotalWithTax { get; set; }

    }
}
