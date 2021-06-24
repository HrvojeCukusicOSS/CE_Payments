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
    public class StatusFinalBillRepository : IStatusFinalBillRepository
    {

        private readonly AppDbContext appDbContext;

        public StatusFinalBillRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext; 
        }

        public async Task<IEnumerable<StatusFinalBill>> GetStatuses()
        {
            
           // var a = appDbContext.StatusFinalBillTable.ToList();

            return await appDbContext.StatusFinalBills.ToListAsync();
        }
        public async Task<StatusFinalBill> GetStatus(int Id)
        {
            return await appDbContext.StatusFinalBills.FirstOrDefaultAsync(e => e.IdStatus == Id);
        }


        public async Task<StatusFinalBill> AddStatus(StatusFinalBill StatusFinalBill)
        {
            var result = await appDbContext.StatusFinalBills.AddAsync(StatusFinalBill);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
       
        public async Task<StatusFinalBill> UpdateStatus(StatusFinalBill StatusFinalBill)
        {
            var result = await appDbContext.StatusFinalBills.FirstOrDefaultAsync(e => e.IdStatus == StatusFinalBill.IdStatus);
            if(result != null)
            {
                //fill for update 
                result.ShortName = StatusFinalBill.ShortName;
                result.Description = StatusFinalBill.Description;
                result.Code = StatusFinalBill.Code;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<StatusFinalBill> DeleteStatus(int Id)
        {
            var result = await appDbContext.StatusFinalBills.FirstOrDefaultAsync(e => e.IdStatus == Id);
            if( result != null)
            {
                appDbContext.StatusFinalBills.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;

        }



    }
}
