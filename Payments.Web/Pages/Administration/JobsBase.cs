using Microsoft.AspNetCore.Components;
using Payments.Model.Entities;
using Payments.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Pages.Administration
{
    public class JobsBase:ComponentBase
    {
        [Inject]
        public IJobsService JobsService { get; set; }
        public IEnumerable<JobsTable> Jobs { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Jobs = (await JobsService.ReadJobsAsync()).ToList();
        }
    }
}
