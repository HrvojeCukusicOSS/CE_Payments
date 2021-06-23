using Payments.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.Repository.Interfaces
{
    public interface IFinallBillRepository
    {
        Task<IEnumerable<FinalBill>> GetFinalBills();
        Task<FinalBill> GetFinalBill(int UserModelId);
        Task<FinalBill> AddFinalBill(FinalBill UserModel);
        Task<FinalBill> UpdateFinalBill(FinalBill UserModel);
        Task<FinalBill> DeleteFinalBill(int UserModelId);
    }
}
