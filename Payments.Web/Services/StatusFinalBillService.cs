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
    public class StatusFinalBillService : IStatusFinalBillService
    {
        private readonly HttpClient httpClient;

        public StatusFinalBillService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<StatusFinalBill> AddStatus(StatusFinalBill status)
        {
            return await httpClient.PostJsonAsync<StatusFinalBill>($"api/StatusFinalBill/AddStatus/{status}",status);
        }

        public async Task<StatusFinalBill> UpdateStatus(StatusFinalBill status)
        {
            return await httpClient.PostJsonAsync<StatusFinalBill>($"api/StatusFinalBill/UpdateStatus/{status}",status);
        }

        public async Task<StatusFinalBill> GetStatus(int id)
        {
            return await httpClient.GetJsonAsync<StatusFinalBill>($"/api/StatusFinalBill/GetStatus/{id}");
        }

        public async Task<IEnumerable<StatusFinalBill>> GetStatuses()
        {
            return await httpClient.GetJsonAsync<StatusFinalBill[]>($"/api/StatusFinalBill/GetStatuses");
        }

        
    }
}
