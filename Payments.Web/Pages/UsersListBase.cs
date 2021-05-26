using Microsoft.AspNetCore.Components;
using Payment.Models;
using Payments.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Pages
{
    public class UsersListBase:ComponentBase
    {
        [Inject]
        public IUserTestService UserTestService { get; set; }
        public IEnumerable<UserTest> UsersList { get; set; }

        protected override async Task OnInitializedAsync()
        {

            UsersList = (await UserTestService.GetUserTests()).ToList();
        }
    }
}
