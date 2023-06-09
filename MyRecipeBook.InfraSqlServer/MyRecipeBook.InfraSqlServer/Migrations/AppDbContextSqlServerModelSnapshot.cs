﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyRecipeBook.InfraSqlServer.ContextSqlServer;

#nullable disable

namespace MyRecipeBook.InfraSqlServer.Migrations
{
    [DbContext(typeof(AppDbContextSqlServer))]
    partial class AppDbContextSqlServerModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyRecipeBook.InfraSqlServer.Model.PriceProductClient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateValidate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdProduct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("PriceProductClient");
                });
#pragma warning restore 612, 618
        }
    }
}
