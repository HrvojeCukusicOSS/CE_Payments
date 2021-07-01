using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Model.Entities
{
    public enum TypeOfPaymentsEnum
    {
        OnePayment = 0, 
        PartialPyments=1,
        MonthleyPayments = 2,
        PaymentPerJob = 3,
        Custom=4
    }
}
