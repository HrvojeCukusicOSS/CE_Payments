using Microsoft.AspNetCore.Components;
using Payments.Model.Entities;
using Payments.Model.Models;
using Payments.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Payments.Web.Services
{
    public class StatusPaymentSolutionService : IStatusPaymentSolutionService
    {
        private readonly HttpClient httpClient;

        public StatusPaymentSolutionService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<StatusPaymentSolution> AddStatus(StatusPaymentSolution status)
        {
            return await httpClient.PostJsonAsync<StatusPaymentSolution>($"api/StatusPaymentSolution/AddStatus/{status}",status);
        }

        //public async Task<HttpResponseMessage> DeleteStatus(int id)
        //{
        //    return await httpClient.DeleteAsync($"api/StatusPaymentSolution/AddStatus/{id}");
        //}

        public async Task<IEnumerable<StatusPaymentSolution>> GetStatuses()
        {
            return await httpClient.GetJsonAsync<StatusPaymentSolution[]>($"/api/StatusPaymentSolution/GetStatuses");
        }

        
    }
}
