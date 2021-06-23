
using Payments.Domain;
using Payments.Model.Entities;
using Payments.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Domain.Repository.Interfaces
{
    public interface IStatusFinalBillRepository
    {
       public Task<IEnumerable<StatusFinalBill>> GetStatuses();
       public Task<StatusFinalBill> GetStatus(int statusId);
       public Task<StatusFinalBill> AddStatus(StatusFinalBill status);
       public Task<StatusFinalBill> UpdateStatus(StatusFinalBill status);
       public Task<StatusFinalBill> DeleteStatus(int statusId);
    }
}
