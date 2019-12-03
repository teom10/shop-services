using domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace services.interfaces
{
    public interface Iproducts_services
    {
        IList<products> GetAllProducts();
        void AddProducts(products products);
        void UpdateProducts(products products);
        void DeleteProducts(products products);
        products GetProducts(products products);
    }
}
