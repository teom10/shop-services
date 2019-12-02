using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace domain.entities
{
    [Table("category")]
    public class category  : baseentity<Guid?>
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
