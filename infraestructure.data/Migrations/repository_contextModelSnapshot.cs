﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using infraestructure.data.database;

namespace infraestructure.data.Migrations
{
    [DbContext(typeof(repository_context))]
    partial class repository_contextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("domain.entities.category", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("category");
                });

            modelBuilder.Entity("domain.entities.products", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Path");

                    b.Property<decimal?>("Price")
                        .IsRequired();

                    b.Property<decimal?>("PriceWithTax")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("domain.entities.sale", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("SaleDate");

                    b.HasKey("Id");

                    b.ToTable("sale");
                });

            modelBuilder.Entity("domain.entities.sale_detail", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("Count");

                    b.Property<Guid?>("ProductId");

                    b.Property<decimal?>("Total");

                    b.Property<decimal?>("TotalWithTax");

                    b.HasKey("Id");

                    b.ToTable("sale_detail");
                });
#pragma warning restore 612, 618
        }
    }
}
