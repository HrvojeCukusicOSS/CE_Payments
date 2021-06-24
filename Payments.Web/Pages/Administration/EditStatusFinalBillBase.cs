using AutoMapper;
using Microsoft.AspNetCore.Components;
using Payments.Model.Entities;
using Payments.Model.Models;
using Payments.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Pages.Administration
{
    public class EditStatusFinalBillBase : ComponentBase
    {
        [Inject]
        public IStatusFinalBillService StatusFinalBillService { get; set; }

        public StatusesModel EditStatusModel { get; set; } = new StatusesModel();

        private StatusFinalBill StatusFinalBill { get; set;  }


        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            StatusFinalBill = await StatusFinalBillService.GetStatus(int.Parse(Id));
            Mapper.Map(StatusFinalBill, EditStatusModel);
        }
        protected async Task OnSubmit()
        {
            Mapper.Map(EditStatusModel, StatusFinalBill);
            var result = await StatusFinalBillService.UpdateStatus(StatusFinalBill);
            if(result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
