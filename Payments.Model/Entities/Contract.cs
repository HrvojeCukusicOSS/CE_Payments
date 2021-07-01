using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Payments.Model.Entities
{
    public class Contract
    {
        [Key]
        public int IdContract { get; set; }

        public string PayersName { get; set; }

        public string ReciversName { get; set; }

        public string TermsOfPayments { get; set; }

        public int NumberOfPayments { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public string  IntrestPercentage { get; set; }

        public string PenaltyPErcentage { get; set; }

        public bool IsActivated { get; set; }
    }
}
