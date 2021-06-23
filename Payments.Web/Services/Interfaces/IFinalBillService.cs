
using Payments.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Services.Interfaces
{
    public interface IFinalBillService
    {
        Task<IEnumerable<FinalBill>> GetFinalBIlls();
        Task<FinalBill> GetFinalBill(int Id);
    }
}
