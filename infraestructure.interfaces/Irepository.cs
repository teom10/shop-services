using domain.entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace infraestructure.interfaces
{
    public interface Irepository<T> where T : class
    {
        T Get(Guid id);
        IList<T> List();
        IList<T> List(Expression<Func<T, bool>> expression);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
