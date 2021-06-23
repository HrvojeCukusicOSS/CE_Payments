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
    public class ReceiversRepository : IReceiversRepository
    {

        private readonly AppDbContext appDbContext;

        public ReceiversRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext; 
        }

        public async Task<IEnumerable<ReceiversTable>> GetReceivers()
        {
            
           // var a = appDbContext.ReceiversTable.ToList();
            return await appDbContext.Receivers.ToListAsync();
        }
        public async Task<ReceiversTable> GetReceiver(int ReceiversTableId)
        {
            return await appDbContext.Receivers.FirstOrDefaultAsync(e => e.IdReceiver == ReceiversTableId);
        }


        public async Task<ReceiversTable> AddReceiver(ReceiversTable ReceiversTable)
        {
            var result = await appDbContext.Receivers.AddAsync(ReceiversTable);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
       
        public async Task<ReceiversTable> UpdateReceiver(ReceiversTable ReceiversTable)
        {
            var result = await appDbContext.Receivers.FirstOrDefaultAsync(e => e.IdReceiver == ReceiversTable.IdReceiver);
            if(result != null)
            {
                result.Name = ReceiversTable.Name;
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<ReceiversTable> DeleteReceiver(int ReceiversTableId)
        {
            var result = await appDbContext.Receivers.FirstOrDefaultAsync(e => e.IdReceiver == ReceiversTableId);
            if( result != null)
            {
                appDbContext.Receivers.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;

        }

        public async Task<ReceiversTable> GetReceiverByName(string userName)
        {
            return await appDbContext.Receivers.FirstOrDefaultAsync(e => e.Name == userName);
        }


    }
}
