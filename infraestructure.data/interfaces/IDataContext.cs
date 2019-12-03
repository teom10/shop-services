using domain.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace infraestructure.data.interfaces
{
    public interface IDataContext
    {
         DbSet<products> products { get; set; }
         DbSet<category> category { get; set; }
         DbSet<sale> sale { get; set; }
         DbSet<sale_detail> sale_detail { get; set; }
    }
}
