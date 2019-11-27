using System;
using System.Collections.Generic;
using System.Text;

namespace domain.entities
{
    public class sale : baseentity<Guid?>
    { 
        public DateTime? SaleDate { get; set; }
    }
}
