using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Payments.Model.Entities
{
    public class PaymentSolution
    {
        [Key]
        public int IdPaymentSolution { get; set; }

        //add to final bil 


        public string TermsOfPaymnt { get; set; }
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        [InverseProperty("PaymentSolutions")]
        public virtual StatusPaymentSolution Status { get; set; }

        public string NumberOfPayments { get; set; }


        [InverseProperty("PaymentSolution")]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<PaymentSchedule> PaymentSchedule { get; set; }


    }
}
