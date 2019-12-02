using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace infraestructure.data.database
{
    public class ToDoContextFactory : IDesignTimeDbContextFactory<repository_context>
    {
        public repository_context CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<repository_context>();
            builder.UseSqlServer("Data Source=BMXEXT052551-LP\\SQLEXPRESS;Initial Catalog=shopping;Persist Security Info=True;User ID=sa;Password=root_2019;");
            return new repository_context(builder.Options);
        }
    }
}
