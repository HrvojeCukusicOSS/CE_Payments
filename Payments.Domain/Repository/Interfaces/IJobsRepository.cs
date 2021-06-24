using Payments.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.Repository.Interfaces
{
    public interface IJobsRepository
    {
        Task<IEnumerable<JobsTable>> ReadAllJobsAsync();
        Task<JobsTable> ReadJobByIdAsync(int Id);
        Task<JobsTable> ReadJobByNameAsync(string Name);
        Task CreateJob(JobsTable Job);
        Task UpdateJob(JobsTable Job);
        Task DeleteJob(JobsTable Job);
    }
}