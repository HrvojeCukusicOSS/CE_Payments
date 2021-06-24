using Payments.Model.Entities;
using Payments.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Services.Interfaces
{
    public interface IStatusPaymentSolutionService
    {
        Task<IEnumerable<StatusPaymentSolution>> GetStatuses();

        Task<StatusPaymentSolution> AddStatus(StatusPaymentSolution status);
        //Task<StatusPaymentSolution> DeleteStatus(int id);
    }
}
