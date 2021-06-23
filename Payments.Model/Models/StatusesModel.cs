using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Model.Models
{
    public class StatusesModel
    {
        public int IdStatus { get; set; }
        public string ShortName { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }
       
        //public virtual ICollection<FinalBill> FinalBill { get; set; }
    }
}
