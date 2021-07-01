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
    public class PaymentInformationRepository : IPaymentInformationRepository
    {

        private readonly AppDbContext appDbContext;

        public PaymentInformationRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext; 
        }

        public async Task<IEnumerable<PaymentInformation>> GetPaymentInformations()
        {
            
           // var a = appDbContext.PaymentInformationTable.ToList();

            return await appDbContext.PaymentInformations.ToListAsync();
        }
        public async Task<PaymentInformation> GetPaymentInformation(int Id)
        {
            return await appDbContext.PaymentInformations.FirstOrDefaultAsync(e => e.IdPaymentInformation == Id);
        }


        public async Task<PaymentInformation> AddPaymentInformation(PaymentInformation Solution)
        {
            var result = await appDbContext.PaymentInformations.AddAsync(Solution);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
       
        public async Task<PaymentInformation> UpdatePaymentInformation(PaymentInformation Solution)
        {
            var result = await appDbContext.PaymentInformations.FirstOrDefaultAsync(e => e.IdPaymentInformation == Solution.IdPaymentInformation);
            if(result != null)
            {
                //fill for update 
                result.Amount = Solution.Amount;
                result.Description= Solution.Description;
                
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<PaymentInformation> DeletePaymentInformation(int Id)
        {
            var result = await appDbContext.PaymentInformations.FirstOrDefaultAsync(e => e.IdPaymentInformation == Id);
            if( result != null)
            {
                appDbContext.PaymentInformations.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;

        }
    }
}
