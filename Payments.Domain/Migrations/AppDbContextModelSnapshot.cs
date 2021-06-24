﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Payments.Domain;

namespace Payments.Domain.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Payments.Model.Entities.ConformationTable", b =>
                {
                    b.Property<int>("ConformationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JobListID")
                        .HasColumnType("int");

                    b.Property<decimal>("PriceCheck")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ConformationID");

                    b.HasIndex("JobListID");

                    b.ToTable("ConformationTable");

                    b.HasData(
                        new
                        {
                            ConformationID = 1,
                            JobListID = 1,
                            PriceCheck = 775m
                        });
                });

            modelBuilder.Entity("Payments.Model.Entities.FinalBill", b =>
                {
                    b.Property<int>("IdFinalBill")
                        .HasColumnType("int");

                    b.Property<int>("ConformationID")
                        .HasColumnType("int");

                    b.Property<int?>("ConformationTable")
                        .HasColumnType("int");

                    b.Property<int?>("JobsListJobListID")
                        .HasColumnType("int");

                    b.Property<int?>("JobsTableJobsID")
                        .HasColumnType("int");

                    b.Property<int>("PayerId")
                        .HasColumnType("int");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("IdFinalBill");

                    b.HasIndex("ConformationTable");

                    b.HasIndex("JobsListJobListID");

                    b.HasIndex("JobsTableJobsID");

                    b.HasIndex("PayerId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("StatusId");

                    b.ToTable("FinalBill");

                    b.HasData(
                        new
                        {
                            IdFinalBill = 1,
                            ConformationID = 1,
                            PayerId = 1,
                            ReceiverId = 1,
                            StatusId = 1
                        },
                        new
                        {
                            IdFinalBill = 2,
                            ConformationID = 1,
                            PayerId = 2,
                            ReceiverId = 2,
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("Payments.Model.Entities.JobsList", b =>
                {
                    b.Property<int>("JobListID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JobsID")
                        .HasColumnType("int");

                    b.Property<bool>("PayerConformation")
                        .HasColumnType("bit");

                    b.Property<bool>("ReciverConformation")
                        .HasColumnType("bit");

                    b.HasKey("JobListID");

                    b.HasIndex("JobsID");

                    b.ToTable("JobsList");

                    b.HasData(
                        new
                        {
                            JobListID = 1,
                            JobsID = 1,
                            PayerConformation = true,
                            ReciverConformation = true
                        });
                });

            modelBuilder.Entity("Payments.Model.Entities.JobsTable", b =>
                {
                    b.Property<int>("JobsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("JobsID");

                    b.ToTable("JobsTable");

                    b.HasData(
                        new
                        {
                            JobsID = 1,
                            Description = "Writes code for apps",
                            Name = "Software Developer",
                            Price = 225m
                        },
                        new
                        {
                            JobsID = 2,
                            Description = "Supervises developers",
                            Name = "IT Manager",
                            Price = 550m
                        });
                });

            modelBuilder.Entity("Payments.Model.Entities.PayersTable", b =>
                {
                    b.Property<int>("IdPayer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPayer");

                    b.ToTable("PayersTable");

                    b.HasData(
                        new
                        {
                            IdPayer = 1,
                            Name = "eaaav@gad"
                        },
                        new
                        {
                            IdPayer = 2,
                            Name = "htthv@gad"
                        });
                });

            modelBuilder.Entity("Payments.Model.Entities.ReceiversTable", b =>
                {
                    b.Property<int>("IdReceiver")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdReceiver");

                    b.ToTable("ReceiversTable");

                    b.HasData(
                        new
                        {
                            IdReceiver = 1,
                            Name = "asdf@gad"
                        },
                        new
                        {
                            IdReceiver = 2,
                            Name = "zztzf@gad"
                        });
                });

            modelBuilder.Entity("Payments.Model.Entities.StatusFinalBill", b =>
                {
                    b.Property<int>("IdStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdStatus");

                    b.ToTable("StatusFinalBill");

                    b.HasData(
                        new
                        {
                            IdStatus = 1,
                            Code = "1950",
                            Description = "This is some very dangerous string error",
                            ShortName = "Some Status"
                        });
                });

            modelBuilder.Entity("Payments.Model.Entities.StatusPaymentSolution", b =>
                {
                    b.Property<int>("IdStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdStatus");

                    b.ToTable("StatusPaymentSolution");
                });

            modelBuilder.Entity("Payments.Model.Entities.ConformationTable", b =>
                {
                    b.HasOne("Payments.Model.Entities.JobsList", "JobList")
                        .WithMany()
                        .HasForeignKey("JobListID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobList");
                });

            modelBuilder.Entity("Payments.Model.Entities.FinalBill", b =>
                {
                    b.HasOne("Payments.Model.Entities.ConformationTable", "Conformaion")
                        .WithMany("FinalBill")
                        .HasForeignKey("ConformationTable");

                    b.HasOne("Payments.Model.Entities.JobsList", null)
                        .WithMany("FinalBill")
                        .HasForeignKey("JobsListJobListID");

                    b.HasOne("Payments.Model.Entities.JobsTable", null)
                        .WithMany("FinalBill")
                        .HasForeignKey("JobsTableJobsID");

                    b.HasOne("Payments.Model.Entities.PayersTable", "Payer")
                        .WithMany("FinalBill")
                        .HasForeignKey("PayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Payments.Model.Entities.ReceiversTable", "Receiver")
                        .WithMany("FinalBill")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Payments.Model.Entities.StatusFinalBill", "Status")
                        .WithMany("FinalBill")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conformaion");

                    b.Navigation("Payer");

                    b.Navigation("Receiver");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Payments.Model.Entities.JobsList", b =>
                {
                    b.HasOne("Payments.Model.Entities.JobsTable", "Job")
                        .WithMany()
                        .HasForeignKey("JobsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Payments.Model.Entities.ConformationTable", b =>
                {
                    b.Navigation("FinalBill");
                });

            modelBuilder.Entity("Payments.Model.Entities.JobsList", b =>
                {
                    b.Navigation("FinalBill");
                });

            modelBuilder.Entity("Payments.Model.Entities.JobsTable", b =>
                {
                    b.Navigation("FinalBill");
                });

            modelBuilder.Entity("Payments.Model.Entities.PayersTable", b =>
                {
                    b.Navigation("FinalBill");
                });

            modelBuilder.Entity("Payments.Model.Entities.ReceiversTable", b =>
                {
                    b.Navigation("FinalBill");
                });

            modelBuilder.Entity("Payments.Model.Entities.StatusFinalBill", b =>
                {
                    b.Navigation("FinalBill");
                });
#pragma warning restore 612, 618
        }
    }
}
