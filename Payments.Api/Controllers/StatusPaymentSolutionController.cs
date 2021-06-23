using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payments.Domain.Repository.Interfaces;
using Payments.Model.Entities;
using Payments.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatusPaymentSolutionController : Controller
    {

        private readonly IStatusPaymentSolutionRepository _statusPaymentSolutionRepository;

        public StatusPaymentSolutionController(IStatusPaymentSolutionRepository statusRepository)
        {
            this._statusPaymentSolutionRepository = statusRepository;
        }
      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusPaymentSolution>>> GetStatuses()
        {
            try
            {
                return (await _statusPaymentSolutionRepository.GetStatuses()).ToList(); 
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<StatusPaymentSolution>> GetStatus(int id)
        {
            try
            {
                return (await _statusPaymentSolutionRepository.GetStatus(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost]
        [Route("{id:int},{status}")]
        public async Task<ActionResult<StatusPaymentSolution>> UpdateStatusPaymentSolution(int id, StatusPaymentSolution status)
        {
            try
            {
                if (status == null)
                    return BadRequest();

                var userToUpdate = await _statusPaymentSolutionRepository.GetStatus(id);
                if (userToUpdate == null)
                    return NotFound($"No user with Id= {id}");
                return await _statusPaymentSolutionRepository.UpdateStatus(status);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating user");
            }
        }
        [HttpPost]
        [Route("{status}")]
        public async Task<ActionResult<StatusPaymentSolution>> AddStatus(StatusPaymentSolution status)
        {
            try
            {
                if (status == null)
                    return BadRequest();

                var createUser = await _statusPaymentSolutionRepository.AddStatus(status);
                return CreatedAtAction(nameof(GetStatus), new { id = createUser.IdStatus }, createUser);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new employee record");
            }

        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<StatusPaymentSolution>> DeleteUserModel(int id)
        {
            try
            {
                var userToDelete = await _statusPaymentSolutionRepository.GetStatus(id);

                if (userToDelete == null)
                {
                    return NotFound($"User with Id = {id} not found");
                }
                return await _statusPaymentSolutionRepository.DeleteStatus(id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new employee record");
            }
        }
    }
}