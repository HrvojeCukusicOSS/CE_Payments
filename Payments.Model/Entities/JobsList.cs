using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Payments.Model.Entities
{
    [Table("JobsList")]
    public class JobsList
    {
        [Key]
        public int JobListID { get; set; }
        public int JobsID { get; set; }
        [ForeignKey("JobsID")]
        //[InverseProperty("JobsList")]
        public virtual JobsTable Job { get; set; }
        public bool PayerConformation { get; set; }
        public bool ReciverConformation { get; set; }
        /*[InverseProperty("JobList")]
        [System.Text.Json.Serialization.JsonIgnore]*/
        public virtual ICollection<FinalBill> FinalBill { get; set; }
    }
}
