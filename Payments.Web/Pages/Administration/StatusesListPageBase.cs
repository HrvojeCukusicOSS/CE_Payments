using Microsoft.AspNetCore.Components;
using Payments.Model.Entities;
using Payments.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Pages.Administration
{
    public class StatusesListPageBase:ComponentBase
    {
        [Inject]
        
        public IStatusFinalBillService statusFinalBillService { get; set; }
        [Inject]
        public IStatusPaymentSolutionService statusPaymentSolutionService { get; set; }
        public IEnumerable<StatusFinalBill> statusFinalBills { get; set; }
        public IEnumerable<StatusPaymentSolution> statusPaymentSolutions { get; set; }
        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            statusFinalBills = (await statusFinalBillService.GetStatuses()).ToList();

            statusPaymentSolutions = (await statusPaymentSolutionService.GetStatuses()).ToList();
            Id = Id ?? "1";

        }
    }
}
