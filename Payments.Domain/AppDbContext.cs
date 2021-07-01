using Payments.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payments.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payments.Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Hrvoje\\Desktop\\Faks3GOD\\6sem\\C#\\Završni\\NewestCE_Payments\\CE_Payments-main\\Payments.Model\\MyDb.mdf;Integrated Security=True");
            optionsBuilder.EnableSensitiveDataLogging();
        }
        public DbSet<PayersTable> Payers { get; set; }
        public DbSet<ReceiversTable> Receivers { get; set; }
        public DbSet<FinalBill> FinalBills { get; set; }
        public DbSet<StatusFinalBill> StatusFinalBills { get; set; }
        public DbSet<StatusPaymentSolution> StatusPaymentSolutions { get; set; }
        public DbSet<JobsList> JobsLists { get; set; }
        public DbSet<ConformationTable> Conformations { get; set; }
        public DbSet<JobsTable> Jobs { get; set; }

        public DbSet<PaymentSolution> PaymentSolutions { get; set; }
        public DbSet<PaymentSchedule> PaymentSchedules { get; set; }
        public DbSet<PaymentInformation> PaymentInformations { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<FinalBill>().Property(d => d.IdFinalBill).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            var u1 = new PayersTable { IdPayer = 1, Name = "eaaav@gad" };
            var u2 = new ReceiversTable { IdReceiver = 1, Name = "asdf@gad" };
            var u3 = new PayersTable { IdPayer = 2, Name = "htthv@gad" };
            var u4 = new ReceiversTable { IdReceiver = 2, Name = "zztzf@gad" };
            var j1 = new JobsTable { JobsID = 1, Name = "Software Developer", Description = "Writes code for apps", Price = 225, JobListId=1 };
            var j2 = new JobsTable { JobsID = 2, Name = "IT Manager", Description = "Supervises developers", Price = 550, JobListId = 1 };
            var jl1 = new JobsList { JobListID = 1, PayerConformation = true, ReciverConformation = true };
            var c = new ConformationTable { ConformationID = 1, JobListId=1, PriceCheck = j1.Price + j2.Price };

            var s1 = new StatusFinalBill { IdStatus = 1, ShortName = "Some Status", Description = "This is some very dangerous string error", Code = "1950" };

            var cont = new Contract
            {
                IdContract = 10,
                PayersName = "eaaav@gad",
                ReciversName = "asdf@gad",
                TermsOfPayments = "One Payment",
                NumberOfPayments = 1,
                IntrestPercentage = "5.0",
                PenaltyPErcentage = "7.5",
                StartDate = new DateTime(2021, 6, 25),
                EndDate = new DateTime(2021,6,30),
                IsActivated = false

            };


            // modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            foreach(var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e=> e.GetForeignKeys()) )
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<PayersTable>().HasData(u1);
            modelBuilder.Entity<ReceiversTable>().HasData(u2);
            modelBuilder.Entity<PayersTable>().HasData(u3);
            modelBuilder.Entity<ReceiversTable>().HasData(u4);

            modelBuilder.Entity<JobsTable>().HasData(j1);
            modelBuilder.Entity<JobsTable>().HasData(j2);
            modelBuilder.Entity<JobsList>().HasData(jl1);
            modelBuilder.Entity<ConformationTable>().HasData(c);
            modelBuilder.Entity<StatusFinalBill>().HasData(s1);
            modelBuilder.Entity<Contract>().HasData(cont);

            modelBuilder.Entity<FinalBill>()
                .HasData(new FinalBill
                {
                    IdFinalBill = 1,
                    PayerId = u1.IdPayer,
                    ReceiverId = u2.IdReceiver,
                    StatusId = s1.IdStatus
                });
            modelBuilder.Entity<FinalBill>()
                .HasData(new FinalBill
                {
                    IdFinalBill = 2,
                    PayerId = u3.IdPayer,
                    ReceiverId = u4.IdReceiver,
                    StatusId = s1.IdStatus
                });


        }
    }
}
