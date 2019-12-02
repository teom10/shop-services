using domain.entities;
using infraestructure.data.database;
using infraestructure.data.interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace infraestructure.data.repository
{
    public class products_repository : repository<products>, Iproducts_repository
    {

        public products_repository(repository_context context) : base(context)
        {

        }
    }
}
