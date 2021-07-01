using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payments.Domain;
using Payments.Domain.Repository.Interfaces;
using Payments.Model.Entities;

namespace Payments.Domain.Repository
{
    public class PaymentScheduleRepository : IPaymentScheduleRepository
    {

        private readonly AppDbContext appDbContext;

        public PaymentScheduleRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext; 
        }

        public async Task<IEnumerable<PaymentSchedule>> GetPaymentSchedules()
        {
            
           // var a = appDbContext.PaymentScheduleTable.ToList();

            return await appDbContext.PaymentSchedules.ToListAsync();
        }
        public async Task<PaymentSchedule> GetPaymentSchedule(int Id)
        {
            return await appDbContext.PaymentSchedules.FirstOrDefaultAsync(e => e.IdPaymentSchedule == Id);
        }


        public async Task<PaymentSchedule> AddPaymentSchedule(PaymentSchedule Solution)
        {
            var result = await appDbContext.PaymentSchedules.AddAsync(Solution);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
       
        public async Task<PaymentSchedule> UpdatePaymentSchedule(PaymentSchedule Solution)
        {
            var result = await appDbContext.PaymentSchedules.FirstOrDefaultAsync(e => e.IdPaymentSchedule == Solution.IdPaymentSchedule);
            if(result != null)
            {
                //fill for update 
                result.PaymentSolutionId = Solution.PaymentSolutionId;
                result.PaymnetInformationId= Solution.PaymnetInformationId;
                result.StartOfSchedule = Solution.StartOfSchedule;
                result.EntOfSchedule = Solution.EntOfSchedule;
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<PaymentSchedule> DeletePaymentSchedule(int Id)
        {
            var result = await appDbContext.PaymentSchedules.FirstOrDefaultAsync(e => e.IdPaymentSchedule == Id);
            if( result != null)
            {
                appDbContext.PaymentSchedules.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;

        }
    }
}
