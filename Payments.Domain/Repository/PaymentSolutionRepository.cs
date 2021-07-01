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
    public class PaymentSolutionRepository : IPaymentSolutionRepository
    {

        private readonly AppDbContext appDbContext;

        public PaymentSolutionRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext; 
        }

        public async Task<IEnumerable<PaymentSolution>> GetPaymentSolutions()
        {
            
           // var a = appDbContext.PaymentSolutionTable.ToList();

            return await appDbContext.PaymentSolutions.ToListAsync();
        }
        public async Task<PaymentSolution> GetPaymentSolution(int Id)
        {
            return await appDbContext.PaymentSolutions.FirstOrDefaultAsync(e => e.IdPaymentSolution == Id);
        }


        public async Task<PaymentSolution> AddPaymentSolution(PaymentSolution Solution)
        {
            var result = await appDbContext.PaymentSolutions.AddAsync(Solution);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
       
        public async Task<PaymentSolution> UpdatePaymentSolution(PaymentSolution Solution)
        {
            var result = await appDbContext.PaymentSolutions.FirstOrDefaultAsync(e => e.IdPaymentSolution == Solution.IdPaymentSolution);
            if(result != null)
            {
                //fill for update 
                result.NumberOfPayments = Solution.NumberOfPayments;
                result.StatusId= Solution.StatusId;
                result.TermsOfPaymnt = Solution.TermsOfPaymnt;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<PaymentSolution> DeletePaymentSolution(int Id)
        {
            var result = await appDbContext.PaymentSolutions.FirstOrDefaultAsync(e => e.IdPaymentSolution == Id);
            if( result != null)
            {
                appDbContext.PaymentSolutions.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;

        }
    }
}
