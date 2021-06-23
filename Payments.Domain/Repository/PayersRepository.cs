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
    public class PayersRepository : IPayersRepository
    {

        private readonly AppDbContext appDbContext;

        public PayersRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext; 
        }

        public async Task<IEnumerable<PayersTable>> GetPayers()
        {
            
           // var a = appDbContext.PayersTable.ToList();
            return await appDbContext.Payers.ToListAsync();
        }
        public async Task<PayersTable> GetPayer(int PayersTableId)
        {
            return await appDbContext.Payers.FirstOrDefaultAsync(e => e.IdPayer == PayersTableId);
        }


        public async Task<PayersTable> AddPayer(PayersTable PayersTable)
        {
            var result = await appDbContext.Payers.AddAsync(PayersTable);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
       
        public async Task<PayersTable> UpdatePayer(PayersTable PayersTable)
        {
            var result = await appDbContext.Payers.FirstOrDefaultAsync(e => e.IdPayer == PayersTable.IdPayer);
            if(result != null)
            {
                result.Name = PayersTable.Name;
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<PayersTable> DeletePayer(int PayersTableId)
        {
            var result = await appDbContext.Payers.FirstOrDefaultAsync(e => e.IdPayer == PayersTableId);
            if( result != null)
            {
                appDbContext.Payers.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;

        }

        public async Task<PayersTable> GetPayerByName(string userName)
        {
            return await appDbContext.Payers.FirstOrDefaultAsync(e => e.Name == userName);
        }


    }
}
