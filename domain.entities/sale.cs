using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace domain.entities
{
    [Table("sale")]
    public class sale : baseentity<Guid?>
    { 
        public DateTime? SaleDate { get; set; }
    }
}
