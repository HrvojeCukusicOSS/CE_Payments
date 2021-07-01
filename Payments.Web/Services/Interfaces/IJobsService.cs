using Payments.Model.Entities;
using Payments.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Services.Interfaces
{
    public interface IJobsService
    {
        Task<IEnumerable<JobsTable>> ReadJobsAsync();
    }
}
