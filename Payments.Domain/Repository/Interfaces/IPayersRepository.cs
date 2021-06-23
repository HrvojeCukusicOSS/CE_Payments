using Payments.Domain;
using Payments.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Domain.Repository.Interfaces
{
    public interface IPayersRepository
    {
        Task<IEnumerable<PayersTable>> GetPayers();
        Task<PayersTable> GetPayer(int UserModelId);
        Task<PayersTable> AddPayer(PayersTable UserModel);
        Task<PayersTable> UpdatePayer(PayersTable UserModel);
        Task<PayersTable> DeletePayer(int UserModelId);
        Task<PayersTable> GetPayerByName(string userName);
    }
}
