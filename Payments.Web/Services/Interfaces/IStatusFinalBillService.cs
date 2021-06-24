using Payments.Model.Entities;
using Payments.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Services.Interfaces
{
    public interface IStatusFinalBillService
    {

        Task<IEnumerable<StatusFinalBill>> GetStatuses();
        Task<StatusFinalBill> AddStatus(StatusFinalBill status);
        Task<StatusFinalBill> GetStatus(int id);
        Task<StatusFinalBill> UpdateStatus(StatusFinalBill status);
    }
}
