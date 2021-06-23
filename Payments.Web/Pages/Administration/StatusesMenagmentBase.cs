using Microsoft.AspNetCore.Components;
using Payments.Domain.Repository.Interfaces;
using Payments.Model.Entities;
using Payments.Model.Models;
using Payments.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Pages.FinalBillPages
{

    public class StatusesMenagmentBase : ComponentBase
    {
        [Inject]
        public IStatusFinalBillService statusFinalBillService { get; set; }
        [Inject]
        public IStatusPaymentSolutionService statusPaymentSolutionService { get; set; }

        public StatusesModel statusModel { get; set; } = new StatusesModel();
        public StatusesModel statusModel2 { get; set; } = new StatusesModel();

        public IEnumerable<StatusFinalBill> statusFinalBills { get; set; }
        public IEnumerable<StatusPaymentSolution> statusPaymentSolutions { get; set; }

       
        public void OnAddStatusFinalBill()
        {
            //add check validity

            statusFinalBillService.AddStatus(new StatusFinalBill
            {
                IdStatus = 0,
                ShortName = statusModel.ShortName,
                Description = statusModel.Description,
                Code = statusModel.Code
            });
        }
        public void OnAddStatusPaymentSolution()
        {
            //add check validity
            var a = new StatusPaymentSolution
            {
                IdStatus = 0,
                ShortName = statusModel2.ShortName,
                Description = statusModel2.Description,
                Code = statusModel2.Code
            };
            statusPaymentSolutionService.AddStatus(a);
        }
        protected override async Task OnInitializedAsync()
        {
            statusFinalBills = (await statusFinalBillService.GetStatuses()).ToList();

            statusPaymentSolutions = (await statusPaymentSolutionService.GetStatuses()).ToList();
        }
    }
}
