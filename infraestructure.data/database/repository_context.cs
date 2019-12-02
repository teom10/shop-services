using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using domain.entities;
using Microsoft.EntityFrameworkCore.Storage;
using infraestructure.data.interfaces;


namespace infraestructure.data.database
{
    public class repository_context : DbContext
    {
        public repository_context(DbContextOptions<repository_context> options)
        : base(options)
        {
        }

        public DbSet<products> products { get; set; }
        public DbSet<category> category { get; set; }
        public DbSet<sale> sale { get; set; }
        public DbSet<sale_detail> sale_detail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var config = modelBuilder.Entity<products>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
