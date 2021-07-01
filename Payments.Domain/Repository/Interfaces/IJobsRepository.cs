using Payments.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.Repository.Interfaces
{
    public interface IJobsRepository
    {
        Task<IEnumerable<JobsTable>> ReadJobsAsync();
        Task<JobsTable> ReadJobByIdAsync(int Id);
        Task<JobsTable> CreateJob(JobsTable Job);
        Task<JobsTable> UpdateJob(JobsTable Job);
        Task<JobsTable> DeleteJob(int id);
    }
}