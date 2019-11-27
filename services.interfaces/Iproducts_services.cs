using domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace services.interfaces
{
    public interface Iproducts_services
    {
        IList<products> GetAllProducts();
    }
}
