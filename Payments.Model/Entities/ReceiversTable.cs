using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Payments.Model.Entities
{
    [Table("ReceiversTable")]
    public class ReceiversTable
    {
        [Key]
        public int IdReceiver { get; set; }
        public string Name { get; set; }
        [InverseProperty("Receiver")]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<FinalBill> FinalBill { get; set; }
    }
}
