using Microsoft.EntityFrameworkCore;
using Payments.Domain.Repository.Interfaces;
using Payments.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.Repository
{
    public class JobsRepository : IJobsRepository
    {
        protected AppDbContext Context;
        public JobsRepository(AppDbContext context)
        {
            Context = context;
        }
        
        public async Task<IEnumerable<JobsTable>> ReadJobsAsync()
        {
            return await Context.Jobs.ToListAsync();
        }

        public async Task<JobsTable> ReadJobByIdAsync(int Id)
        {
            return await Context.Jobs.FirstOrDefaultAsync(j => j.JobsID == Id);
        }

        public async Task<JobsTable> CreateJob(JobsTable Job)
        {
            var result = await Context.Jobs.AddAsync(Job);
            await Context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<JobsTable> UpdateJob(JobsTable Job)
        {
            var result = await Context.Jobs.FirstOrDefaultAsync(j => j.JobsID == Job.JobsID);
            if (result != null)
            {
                result.Name = Job.Name;
                result.Price = Job.Price;
                result.Description = Job.Description;
                result.JobListId = Job.JobListId;
                result.JobList = Job.JobList;
                await Context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<JobsTable> DeleteJob(int id)
        {
            var result = await Context.Jobs.FirstOrDefaultAsync(j => j.JobsID == id);
            if (result != null)
            {
                Context.Jobs.Remove(result);
                await Context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}