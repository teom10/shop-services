using infraestructure.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using domain.entities;
using Microsoft.EntityFrameworkCore;
using infraestructure.data.database;
using System.Linq;
using System.Linq.Expressions;
using infraestructure.data.interfaces;

namespace infraestructure.data.repository
{
    public abstract class repository<T> : Irepository<T> where T : class
    {
        protected repository_context _dataContext { get; set; }
        private DbSet<T> _dbSet;

        public repository(repository_context datacontext)
        {
            _dataContext = datacontext;
            _dbSet = datacontext.Set<T>();
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dataContext.SaveChanges();
        }

        public T Get(Guid id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
            _dataContext.SaveChanges();
        }

        public IList<T> List()
        {
            try
            {
                return _dbSet.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IList<T> List(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).ToList();
        }

        public void Update(T entity)
        {
            _dataContext.Entry<T>(entity).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }
    }
}
