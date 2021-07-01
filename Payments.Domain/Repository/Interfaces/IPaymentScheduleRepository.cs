using Payments.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.Repository.Interfaces
{
    public interface IPaymentScheduleRepository
    {
        Task<IEnumerable<PaymentSchedule>> GetPaymentSchedules();
        Task<PaymentSchedule> GetPaymentSchedule(int Id);
        Task<PaymentSchedule> AddPaymentSchedule(PaymentSchedule scheduleModel);
        Task<PaymentSchedule> UpdatePaymentSchedule(PaymentSchedule scheduleModel);
        Task<PaymentSchedule> DeletePaymentSchedule(int Id);
    }
}
