using System;
using System.Collections.Generic;
using System.Text;

namespace domain.entities
{
    public abstract class baseentity<T>
    {
        public virtual T Id { get; set; }
    }
}
