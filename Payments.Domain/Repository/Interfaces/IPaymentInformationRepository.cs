using Payments.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.Repository.Interfaces
{
    public interface IPaymentInformationRepository
    {
        Task<IEnumerable<PaymentInformation>> GetPaymentInformations();
        Task<PaymentInformation> GetPaymentInformation(int Id);
        Task<PaymentInformation> AddPaymentInformation(PaymentInformation solutioneModel);
        Task<PaymentInformation> UpdatePaymentInformation(PaymentInformation solutioneModel);
        Task<PaymentInformation> DeletePaymentInformation(int Id);
    }
}
