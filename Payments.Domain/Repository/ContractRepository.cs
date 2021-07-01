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
    public class ContractRepository : IContractRepository
    {

        private readonly AppDbContext appDbContext;

        public ContractRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext; 
        }

        public async Task<IEnumerable<Contract>> GetContracts()
        {
            
           // var a = appDbContext.ContractTable.ToList();

            return await appDbContext.Contracts.ToListAsync();
        }
        public async Task<Contract> GetContract(int Id)
        {
            return await appDbContext.Contracts.FirstOrDefaultAsync(e => e.IdContract == Id);
        }

    }
}
