
using Payments.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Services.Interfaces
{
    public interface IContractService
    {
        Task<IEnumerable<Contract>> GetContracts();
        Task<Contract> GetContract(int Id);
    }
}
