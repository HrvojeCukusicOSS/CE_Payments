using Microsoft.AspNetCore.Components;
using Payment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Payments.Web.Services
{
    public class UserTestService : IUserTestService
    {
        private readonly HttpClient httpClient;

        public UserTestService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<UserTest>> GetUserTests()
        {
            return await httpClient.GetJsonAsync<UserTest[]>("api/Usertests/List");
        }
        public async Task<UserTest> GetUserTest(int id)
        {
            return await httpClient.GetJsonAsync<UserTest>($"api/Usertests/List/{id}");
        }
    }
}
