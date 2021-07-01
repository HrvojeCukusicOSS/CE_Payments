using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Payments.Model.Entities
{
    public  class PaymentSchedule
    {
        [Key]
        public int IdPaymentSchedule { get; set; }

        public int PaymentSolutionId { get; set; }

        [ForeignKey("PaymentSolutionId")]
        [InverseProperty("PaymentSchedule")]
        public virtual PaymentSolution PaymentSolution { get; set; }

        public int PaymnetInformationId { get; set; }
        [ForeignKey("PaymnetInformationId")]
        [InverseProperty("PaymentSchedule")]
        public PaymentInformation PaymentInformation { get; set; }

        public DateTime StartOfSchedule { get; set; }

        public DateTime EntOfSchedule { get; set; }

        public string FinalAmount { get; set; }


    }

}
