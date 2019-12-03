﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using domain.entities;
using infraestructure.data.database;
using infraestructure.data.interfaces;
using infraestructure.data.repository;
using infraestructure.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using rest_application.helpers;
using rest_application.models;
using services.classes;
using services.interfaces;

namespace rest_application
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(env.ContentRootPath)
             .AddEnvironmentVariables();

            this.Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ThreadPool.SetMinThreads(250, 250);
            services.AddLogging(config =>
            {
                config.ClearProviders();
            });

            services.AddResponseCompression();

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            services.AddMvcCore(opt =>
            {
                opt.ModelValidatorProviders.Clear();
                opt.InputFormatters.Clear();
                opt.OutputFormatters.Clear();
                opt.OutputFormatters.Add(new JsonFormatter());

                // opt.OutputFormatters.Add(new MessagePackOutputFormatter(ContractlessStandardResolver.Instance));
                // opt.InputFormatters.Add(new MessagePackInputFormatter(ContractlessStandardResolver.Instance));
            });
            //services.TryAddSingleton<OutputFormatterSelector, DefaultOutputFormatterSelector>();

            services.AddMemoryCache();

            var cnn = this.Configuration.GetSection("shoppingoptions").GetValue<string>("connectionstring");

            if (string.IsNullOrWhiteSpace(cnn))
            {
                throw new System.ApplicationException("No se encontró la cadena de conexión");
            }

            services.AddMvc();

            //// Add the DbContextOptions:
            //var dbContextOptions = new DbContextOptionsBuilder<repository_context>()
            //    .UseSqlServer(cnn, x => x.MigrationsAssembly("infraestructure.data"))
            //    .Options;

            //services.AddSingleton(dbContextOptions);

            //// Finally register the DbContextOptions:
            //services.AddSingleton<repository_context>();

            //// Finally Add the Applications DbContext:
            //services.AddDbContext<repository_context>();

          

            services.AddDbContext<repository_context>(options =>
            {
                options.UseSqlServer(@"Server=BMXEXT052551-LP\\SQLEXPRESS;Database=shopping;Trusted_Connection=True;MultipleActiveResultSets=true",
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 10,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
                });
            });

            //services.AddScoped<IDataContext, repository_context>();
            services.AddScoped(typeof(Irepository<products>), typeof(products_repository));
            services.AddScoped<Iproducts_repository, products_repository>();
            services.AddScoped<Iproducts_services, products_services>();

            //services.AddScoped(typeof(Irepository<>), typeof(repository<>));
            //services.AddScoped(typeof(Irepository<>), typeof(repository<>));
            //services.AddTransient<DbConnection>(db => new SqlConnection(cnn));
            //services.Configure<shoppingoptions>(this.Configuration.GetSection("shoppingoptions"));
            //services.AddSingleton<IConfiguration>(_ => Configuration);
            //services.AddTransient<DbConnection>(db => new SqlConnection(cnn));
            //services.AddDbContext<repository_context>();
            //services.AddScoped<IDataContext, repository_context>();
            //services.AddScoped<Iproducts_repository, products_repository>();
            //services.AddScoped<Iproducts_repository>(_ => new products_repository(_.GetService<IDataContext>()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
