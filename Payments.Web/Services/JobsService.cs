using Payments.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Payments.Model.Entities;
using Payments.Model.Models;
using System.Net.Http;

namespace Payments.Web.Services
{
    public class JobsService : IJobsService
    {
        private readonly HttpClient _httpClient;
        public JobsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<JobsTable>> ReadJobsAsync()
        {
            return await _httpClient.GetJsonAsync<JobsTable[]>($"api/JobsTable/ReadJobsAsync");
        }
    }
}
