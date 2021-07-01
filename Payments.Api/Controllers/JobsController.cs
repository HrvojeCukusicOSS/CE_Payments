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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobsController : Controller
    {
        private readonly IJobsRepository _jobsRepository;

        public JobsController(IJobsRepository JobsRepository)
        {
            _jobsRepository = JobsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobsTable>>> ReadJobsAsync()
        {
            try
            {
                return (await _jobsRepository.ReadJobsAsync()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<JobsTable>> ReadJobByIdAsync(int Id)
        {
            try
            {
                var result = await _jobsRepository.ReadJobByIdAsync(Id);
                if (result == null)
                    return NotFound();
                return result;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data form the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<JobsTable>> CreateJob(JobsTable Job)
        {
            try
            {
                if (Job == null)
                    return BadRequest();

                var createdJob = await _jobsRepository.CreateJob(Job);

                return CreatedAtAction(nameof(CreateJob),
                    new { id = createdJob.JobsID }, createdJob);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<JobsTable>> UpdateJob(int id, JobsTable Job)
        {
            try
            {
                if (id != Job.JobsID)
                    return BadRequest("Employee ID mismatch");

                var jobToUpdate = await _jobsRepository.ReadJobByIdAsync(id);

                if (jobToUpdate == null)
                    return NotFound($"Employee with Id = {id} not found");

                return await _jobsRepository.UpdateJob(Job);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<JobsTable>> DeleteJob(int id)
        {
            try
            {
                var employeeToDelete = await _jobsRepository.ReadJobByIdAsync(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return await _jobsRepository.DeleteJob(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
