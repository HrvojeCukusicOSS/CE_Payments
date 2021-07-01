using Microsoft.AspNetCore.Components;
using Payments.Model.Entities;
using Payments.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Payments.Web.Services
{
    public class ContractService: IContractService
    {
        private readonly HttpClient httpClient;

        public ContractService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Contract>> GetContracts()
        {
            return await httpClient.GetJsonAsync<Contract[]>("api/Contracts/GetContracts");
        }
        public async Task<Contract> GetContract(int id)
        {
            return await httpClient.GetJsonAsync<Contract>($"api/Contracts/GetContract/{id}");
        }
    }
}
