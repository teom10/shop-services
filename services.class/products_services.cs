using domain.entities;
using infraestructure.interfaces;
using services.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace services.classes
{
    public class products_services : Iproducts_services
    {
        public products_services()
        {

        }
        public IList<products> GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}
