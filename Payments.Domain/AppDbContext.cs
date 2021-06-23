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
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS01;Database=MyDb;Trusted_Connection=True;");
            optionsBuilder.EnableSensitiveDataLogging();
        }
        public DbSet<PayersTable> Payers { get; set; }
        public DbSet<ReceiversTable> Receivers { get; set; }
        public DbSet<FinalBill> FinalBills { get; set; }
        public DbSet<StatusFinalBill> StatusFinalBills { get; set; }
        public DbSet<StatusPaymentSolution> StatusPaymentSolutions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<FinalBill>().Property(d => d.IdFinalBill).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            var u1 = new PayersTable { IdPayer = 1, Name = "eaaav@gad" };
            var u2 = new ReceiversTable { IdReceiver = 1, Name = "asdf@gad" };
            var u3 = new PayersTable { IdPayer = 2, Name = "htthv@gad" };
            var u4 = new ReceiversTable { IdReceiver = 2, Name = "zztzf@gad" };

            var s1 = new StatusFinalBill { IdStatus = 1, ShortName = "Some Status", Description = "This is some very dangerous string error", Code = "1950" };
            modelBuilder.Entity<PayersTable>().HasData(u1);
            modelBuilder.Entity<ReceiversTable>().HasData(u2);
            modelBuilder.Entity<PayersTable>().HasData(u3);
            modelBuilder.Entity<ReceiversTable>().HasData(u4);
            modelBuilder.Entity<StatusFinalBill>().HasData(s1);


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
