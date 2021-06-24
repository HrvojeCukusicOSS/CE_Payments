using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payments.Domain.Repository.Interfaces;
using Payments.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Api.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobsRepository _jobsRepository;

        public JobsController(IJobsRepository jobsRepository)
        {
            _jobsRepository = jobsRepository;
        }

        public async Task<ActionResult<IEnumerable<JobsTable>>> ReadAllJobsAsync()
        {
            try
            {
                return (await _jobsRepository.ReadAllJobsAsync()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        public async Task<ActionResult<JobsTable>> ReadJobByIdAsync(int Id)
        {
            try
            {
                return (await _jobsRepository.ReadJobByIdAsync(Id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        public async Task<ActionResult<JobsTable>> ReadJobByNameAsync(string Name)
        {
            try
            {
                return (await _jobsRepository.ReadJobByNameAsync(Name));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        public async Task<ActionResult> CreateJob(JobsTable Job)
        {
            try
            {
                if (Job == null)
                    return BadRequest();
                var createJob = await _jobsRepository.CreateJob(Job);
                return CreatedAtAction(nameof(ReadJobByIdAsync), new { Id = createJob.JobID }, createJob);
            }
            catch
            {

            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
