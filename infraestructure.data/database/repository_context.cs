using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using domain.entities;
using Microsoft.EntityFrameworkCore.Storage;
using infraestructure.data.interfaces;

namespace infraestructure.data.database
{
    public class repository_context : DbContext, IDataContext
    {
        public repository_context(DbContextOptions<repository_context> options)
        : base(options)
        {
        }

        public DbSet<products> Products { get; set; }
        public DbSet<category> Category { get; set; }
        public DbSet<sale> Sales { get; set; }
        public DbSet<sale_detail> SaleDetails { get; set; }


        private IDbContextTransaction _transaction;

        public void BeginTransaction()
        {
            _transaction = Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
            }
        }
        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }
    }
}
