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
        public bool PayerConformation { get; set; }
        public bool ReciverConformation { get; set; }
        public ICollection<ConformationTable> Conformations { get; set; }        
        public ICollection<JobsTable> Job { get; set; }
    }
}
