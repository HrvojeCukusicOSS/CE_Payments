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
    public class StatusFinalBillController : Controller
    {

        private readonly IStatusFinalBillRepository _statusFinalBillRepository;

        public StatusFinalBillController(IStatusFinalBillRepository receiverlRepository)
        {
            this._statusFinalBillRepository = receiverlRepository;
        }
      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusFinalBill>>> GetStatuses()
        {
            try
            {
                return (await _statusFinalBillRepository.GetStatuses()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<StatusFinalBill>> GetStatus(int id)
        {
            try
            {
                return (await _statusFinalBillRepository.GetStatus(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost]
        [Route("{status}")]
        public async Task<ActionResult<StatusFinalBill>> UpdateStatus( StatusFinalBill status)
        {
            try
            {
                if (status == null)
                    return BadRequest();

                var userToUpdate = await _statusFinalBillRepository.GetStatus(status.IdStatus);
                if (userToUpdate == null)
                    return NotFound($"No user with Id= {status.IdStatus}");
               
                return await _statusFinalBillRepository.UpdateStatus(status);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating user");
            }
        }
        [HttpPost]
        [Route("{status}")]
        public async Task<ActionResult<StatusFinalBill>> AddStatus(StatusFinalBill status)
        {
            try
            {
                if (status == null)
                    return BadRequest();

                var createUser = await _statusFinalBillRepository.AddStatus(status);
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
        public async Task<ActionResult<StatusFinalBill>> DeleteUserModel(int id)
        {
            try
            {
                var userToDelete = await _statusFinalBillRepository.GetStatus(id);

                if (userToDelete == null)
                {
                    return NotFound($"User with Id = {id} not found");
                }
                return await _statusFinalBillRepository.DeleteStatus(id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new employee record");
            }
        }
    }
}