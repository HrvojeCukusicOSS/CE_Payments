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

        public bool warning { get; set; } = false;

        protected async override Task OnInitializedAsync()
        {

            int.TryParse(Id, out int idint);
            if(idint !=  0)
            {
                StatusFinalBill = await StatusFinalBillService.GetStatus(int.Parse(Id));
            }
            
                Mapper.Map(StatusFinalBill, EditStatusModel);
        }
        protected async Task OnSubmit()
        {
            if (StatusFinalBill == null)
                StatusFinalBill = new StatusFinalBill();

            var result = new StatusFinalBill();
            Mapper.Map(EditStatusModel, StatusFinalBill);
            
            if (StatusFinalBill.IdStatus != 0)
            {
                 result = await StatusFinalBillService.UpdateStatus(StatusFinalBill);
            }
            else
            {
                result = await StatusFinalBillService.AddStatus(StatusFinalBill);
            }
                NavigationManager.NavigateTo("/statuseslist");

        }
        protected async Task Delete_Click()
        {
            await StatusFinalBillService.DeleteStatus(EditStatusModel.IdStatus);
           

            var a = await StatusFinalBillService.GetStatus(EditStatusModel.IdStatus);
            if(a!=null)
            {
                StatusFinalBill = a; 
                warning = true;
                Mapper.Map(EditStatusModel, StatusFinalBill);
                //NavigationManager.NavigateTo("/editstatusfinalbill/{EditStatusModel.IdStatus}");
            }
            else
            {
                NavigationManager.NavigateTo("/statuseslist");
            }

        }
    }
}
