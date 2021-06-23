using Payments.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Payments.Model.Entities
{
    [Table("StatusFinalBill")]
    public class StatusFinalBill
    {
        [Key]
        public int IdStatus { get; set; }
        public string ShortName { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }
        [InverseProperty("Status")]
        [System.Text.Json.Serialization.JsonIgnore]
        public  virtual ICollection<FinalBill> FinalBill{ get; set; }

    }
}
