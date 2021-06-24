using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Payments.Model.Entities
{
    [Table("FinalBill")]
    public class FinalBill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdFinalBill { get; set; }

        public int PayerId { get; set; }
        [ForeignKey("PayerId")]
        [InverseProperty("FinalBill")]
        //[System.Text.Json.Serialization.JsonIgnore]
        public virtual PayersTable Payer { get; set; }

        public int ReceiverId { get; set; }
        [ForeignKey("ReceiverId")]
        [InverseProperty("FinalBill")]
        //[System.Text.Json.Serialization.JsonIgnore]
        public virtual  ReceiversTable Receiver { get; set; }

        public int StatusId { get; set; }   
        [ForeignKey("StatusId")]
        [InverseProperty("FinalBill")]
        //[System.Text.Json.Serialization.JsonIgnore]
        public virtual  StatusFinalBill Status { get; set; }

        public int ConformationID { get; set; }
        [ForeignKey("ConformationTable")]
        [InverseProperty("FinalBill")]
        //[System.Text.Json.Serialization.JsonIgnore]
        public virtual ConformationTable Conformaion { get; set; }
    }
}
