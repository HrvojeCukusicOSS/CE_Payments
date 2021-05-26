﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Payments.Api.Models;

namespace Payments.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210521203315_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Payment.Models.UserTest", b =>
                {
                    b.Property<int>("UserTestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("UserTestNamse")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserTestId");

                    b.ToTable("UserTests");

                    b.HasData(
                        new
                        {
                            UserTestId = 1,
                            Age = 29,
                            UserTestNamse = "Potato"
                        },
                        new
                        {
                            UserTestId = 2,
                            Age = 10,
                            UserTestNamse = "Batman"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
