using infraestructure.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using domain.entities;
using Microsoft.EntityFrameworkCore;
using infraestructure.data.database;
using System.Linq;
using System.Linq.Expressions;

namespace infraestructure.data.repository
{
    public abstract class repository<T> : Irepository<T> where T : class
    {
        private readonly repository_context _dataContext;

        public repository(repository_context dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(T entity)
        {
            _dataContext.Set<T>().Remove(entity);
            _dataContext.SaveChanges();
        }

        public T Get(Guid id)
        {
            return _dataContext.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _dataContext.Set<T>().Add(entity);
            _dataContext.SaveChanges();
        }

        public IList<T> List()
        {
            return _dataContext.Set<T>().ToList();
        }

        public IList<T> List(Expression<Func<T, bool>> expression)
        {
            return _dataContext.Set<T>().Where(expression).ToList();
        }

        public void Update(T entity)
        {
            _dataContext.Entry<T>(entity).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }
    }
}
