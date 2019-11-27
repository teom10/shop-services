using System;
using System.Collections.Generic;
using System.Text;

namespace domain.entities
{
    public class category  : baseentity<Guid?>
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
