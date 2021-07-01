using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Payments.Model.Entities
{
    public class PaymentInformation
    {
        [Key]
        public int IdPaymentInformation { get; set; }

        public string Amount { get; set; }

        public string Description { get; set;  }

        [InverseProperty("PaymentInformation")]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<PaymentSchedule> PaymentSchedule { get; set; }
    }
}
