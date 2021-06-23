using Microsoft.AspNetCore.Components;

using Payments.Model.Entities;
using Payments.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Pages.FinalBillPages
{ 
    public class FinalBillPageBase : ComponentBase
    {
        [Inject]
        public IFinalBillService FinalBillService { get; set; }
        public IEnumerable<FinalBill> FinalBills { get; set;  }
        public FinalBill b { get; set; }
        protected override async Task OnInitializedAsync()
        {
            FinalBills = (await FinalBillService.GetFinalBIlls()).ToList();
            b   = (await FinalBillService.GetFinalBill(1));
           
        }
    }
}
