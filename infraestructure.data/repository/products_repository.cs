using domain.entities;
using infraestructure.data.interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace infraestructure.data.repository
{
    public class products_repository : Iproducts_repository
    {
        private readonly IDataContext _context;
        public products_repository(IDataContext context)
        {
            _context = context;
        }

        public void Delete(products entity)
        {
            throw new NotImplementedException();
        }

        public products Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(products entity)
        {
            throw new NotImplementedException();
        }

        public IList<products> List()
        {
            throw new NotImplementedException();
        }

        public IList<products> List(Expression<Func<products, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(products entity)
        {
            throw new NotImplementedException();
        }
    }
}
