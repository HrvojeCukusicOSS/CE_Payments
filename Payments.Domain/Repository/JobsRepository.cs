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
        public async Task<IEnumerable<JobsTable>> ReadAllJobsAsync()
        {
            return await Context.Set<JobsTable>().ToListAsync();
        }
        public async Task<JobsTable> ReadJobByIdAsync(int Id)
        {
            return await Context.Set<JobsTable>().FindAsync(Id);
        }
        public async Task<JobsTable> ReadJobByNameAsync(string Name)
        {
            return await Context.Set<JobsTable>().FindAsync(Name);
        }
        public async Task CreateJob(JobsTable Job)
        {
            await Context.Set<JobsTable>().AddAsync(Job);
            await Context.SaveChangesAsync();
        }
        public Task UpdateJob(JobsTable Job)
        {
            Context.Entry(Job).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }
        public Task DeleteJob(JobsTable Job)
        {
            Context.Set<JobsTable>().Remove(Job);
            return Context.SaveChangesAsync();
        }
    }
}