using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Payments.Model.Entities
{
    [Table("JobsTable")]
    public class JobsTable
    {
        [Key]
        public int JobsID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        /*[InverseProperty("Job")]
        [System.Text.Json.Serialization.JsonIgnore]*/
        public virtual ICollection<FinalBill> FinalBill { get; set; }
    }
}
