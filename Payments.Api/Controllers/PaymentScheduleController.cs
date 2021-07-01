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
    public class PaymentScheduleController : Controller
    {

        private readonly IPaymentScheduleRepository _PaymentScheduleRepository;

        public PaymentScheduleController(IPaymentScheduleRepository receiverlRepository)
        {
            this._PaymentScheduleRepository = receiverlRepository;
        }
      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentSchedule>>> GetPaymentSchedules()
        {
            try
            {
                return (await _PaymentScheduleRepository.GetPaymentSchedules()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<PaymentSchedule>> GetPaymentSchedule(int id)
        {
            try
            {
                return (await _PaymentScheduleRepository.GetPaymentSchedule(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost]
        [Route("{status}")]
        public async Task<ActionResult<PaymentSchedule>> UpdatePaymentSchedule( PaymentSchedule status)
        {
            try
            {
                if (status == null)
                    return BadRequest();

                var userToUpdate = await _PaymentScheduleRepository.GetPaymentSchedule(status.IdPaymentSchedule);
                if (userToUpdate == null)
                    return NotFound($"No user with Id= {status.IdPaymentSchedule}");
               
                return await _PaymentScheduleRepository.UpdatePaymentSchedule(status);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating user");
            }
        }
        [HttpPost]
        [Route("{status}")]
        public async Task<ActionResult<PaymentSchedule>> AddPaymentSchedule(PaymentSchedule status)
        {
            try
            {
                if (status == null)
                    return BadRequest();

                var createUser = await _PaymentScheduleRepository.AddPaymentSchedule(status);
                return CreatedAtAction(nameof(GetPaymentSchedule), new { id = createUser.IdPaymentSchedule }, createUser);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new employee record");
            }

        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<PaymentSchedule>> DeletePaymentSchedule(int id)
        {
            try
            {
                var userToDelete = await _PaymentScheduleRepository.GetPaymentSchedule(id);

                if (userToDelete == null)
                {
                    return NotFound($"User with Id = {id} not found");
                }
                return await _PaymentScheduleRepository.DeletePaymentSchedule(id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error creating new employee record");
            }
        }
    }
}