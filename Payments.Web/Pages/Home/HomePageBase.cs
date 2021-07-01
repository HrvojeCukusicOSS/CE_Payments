using Microsoft.AspNetCore.Components;
using Payments.Model.Entities;
using Payments.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Pages.Home
{
    public class HomePageBase : ComponentBase
    {

        [Inject]
        private IContractService ContractService { get; set; }

        public IEnumerable<Contract> Contracts { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Contracts = (await ContractService.GetContracts()).ToList();
            


        }


    }

}
