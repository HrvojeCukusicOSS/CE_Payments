using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Payments.Model.Entities
{
    [Table("ConformationTable")]
    public class ConformationTable
    {
        [Key]
        public int ConformationID { get; set; }
        public decimal PriceCheck { get; set; }
        public int JobListId { get; set; }
        public JobsList JobList { get; set; }
    }
}
