using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Payments.Model.Entities
{
    [Table("PayersTable")]
    public class PayersTable
    {
        [Key]
        public int IdPayer { get; set; }
        public string Name { get; set; }
        [InverseProperty("Payer")]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<FinalBill> FinalBill { get; set; }
    }
}
