using domain.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace infraestructure.data.interfaces
{
    public interface IDataContext
    {
         DbSet<products> Products { get; set; }
         DbSet<category> Category { get; set; }
         DbSet<sale> Sales { get; set; }
         DbSet<sale_detail> SaleDetails { get; set; }


        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
