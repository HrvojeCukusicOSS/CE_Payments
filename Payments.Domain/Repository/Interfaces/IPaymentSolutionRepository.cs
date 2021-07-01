using Payments.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.Repository.Interfaces
{
    public interface IPaymentSolutionRepository
    {
        Task<IEnumerable<PaymentSolution>> GetPaymentSolutions();
        Task<PaymentSolution> GetPaymentSolution(int Id);
        Task<PaymentSolution> AddPaymentSolution(PaymentSolution solutioneModel);
        Task<PaymentSolution> UpdatePaymentSolution(PaymentSolution solutioneModel);
        Task<PaymentSolution> DeletePaymentSolution(int Id);
    }
}
