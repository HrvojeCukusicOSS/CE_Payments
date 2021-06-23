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
    public class StatusPaymentSolutionRepository : IStatusPaymentSolutionRepository
    {

        private readonly AppDbContext appDbContext;

        public StatusPaymentSolutionRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext; 
        }

        public async Task<IEnumerable<StatusPaymentSolution>> GetStatuses()
        {
            
           // var a = appDbContext.StatusPaymentSolutionTable.ToList();

            return await appDbContext.StatusPaymentSolutions.ToListAsync();
        }
        public async Task<StatusPaymentSolution> GetStatus(int Id)
        {
            return await appDbContext.StatusPaymentSolutions.FirstOrDefaultAsync(e => e.IdStatus == Id);
        }


        public async Task<StatusPaymentSolution> AddStatus(StatusPaymentSolution StatusPaymentSolution)
        {
            var result = await appDbContext.StatusPaymentSolutions.AddAsync(StatusPaymentSolution);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
       
        public async Task<StatusPaymentSolution> UpdateStatus(StatusPaymentSolution StatusPaymentSolution)
        {
            var result = await appDbContext.StatusPaymentSolutions.FirstOrDefaultAsync(e => e.IdStatus == StatusPaymentSolution.IdStatus);
            if(result != null)
            {
                //fill for update 


                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<StatusPaymentSolution> DeleteStatus(int Id)
        {
            var result = await appDbContext.StatusPaymentSolutions.FirstOrDefaultAsync(e => e.IdStatus == Id);
            if( result != null)
            {
                appDbContext.StatusPaymentSolutions.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;

        }



    }
}
