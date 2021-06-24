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
        public int JobListID { get; set; }
        [ForeignKey("JobListID")]
        //[InverseProperty("Conformation")]
        public virtual JobsList JobList { get; set; }
        public decimal PriceCheck { get; set; }
        /*[InverseProperty("Conformation")]
        [System.Text.Json.Serialization.JsonIgnore]*/
        public virtual ICollection<FinalBill> FinalBill { get; set; }
    }
}
