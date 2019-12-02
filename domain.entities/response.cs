using System;
using System.Collections.Generic;
using System.Text;

namespace domain.entities
{
    public class response<T>
    {
        public string Message { get; set; }
        public T Obj { get; set; }
        public int Code { get; set; }
    }
}
