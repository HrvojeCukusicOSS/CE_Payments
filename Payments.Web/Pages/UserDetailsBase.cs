using Microsoft.AspNetCore.Components;
using Payment.Models;
using Payments.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Pages
{
    public class UserDetailsBase:ComponentBase
    {

        public UserTest UserTest = new UserTest();

        [Inject]
        public IUserTestService UserTestService { get; set; }
        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            UserTest = await UserTestService.GetUserTest(int.Parse(Id));
        }

    }
}
