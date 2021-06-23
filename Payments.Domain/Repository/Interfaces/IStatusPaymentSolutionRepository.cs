
using Payments.Domain;
using Payments.Model.Entities;
using Payments.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Domain.Repository.Interfaces
{
    public interface IStatusPaymentSolutionRepository
    {
        Task<IEnumerable<StatusPaymentSolution>> GetStatuses();
        Task<StatusPaymentSolution> GetStatus(int statusId);
        Task<StatusPaymentSolution> AddStatus(StatusPaymentSolution status);
        Task<StatusPaymentSolution> UpdateStatus(StatusPaymentSolution status);
        Task<StatusPaymentSolution> DeleteStatus(int statusId);
    }
}
