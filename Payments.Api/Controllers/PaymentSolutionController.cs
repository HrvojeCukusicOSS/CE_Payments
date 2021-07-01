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
    public class PaymentSolutionController : Controller
    {

        private readonly IPaymentSolutionRepository _PaymentSolutionRepository;

        public PaymentSolutionController(IPaymentSolutionRepository receiverlRepository)
        {
            this._PaymentSolutionRepository = receiverlRepository;
        }
      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentSolution>>> GetPaymentSolutiones()
        {
            try
            {
                return (await _PaymentSolutionRepository.GetPaymentSolutions()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<PaymentSolution>> GetPaymentSolution(int id)
        {
            try
            {
                return (await _PaymentSolutionRepository.GetPaymentSolution(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost]
        [Route("{status}")]
        public async Task<ActionResult<PaymentSolution>> UpdatePaymentSolution( PaymentSolution status)
        {
            try
            {
                if (status == null)
                    return BadRequest();

                var userToUpdate = await _PaymentSolutionRepository.GetPaymentSolution(status.IdPaymentSolution);
                if (userToUpdate == null)
                    return NotFound($"No user with Id= {status.IdPaymentSolution}");
               
                return await _PaymentSolutionRepository.UpdatePaymentSolution(status);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating user");
            }
        }
        [HttpPost]
        [Route("{status}")]
        public async Task<ActionResult<PaymentSolution>> AddPaymentSolution(PaymentSolution status)
        {
            try
            {
                if (status == null)
                    return BadRequest();

                var createUser = await _PaymentSolutionRepository.AddPaymentSolution(status);
                return CreatedAtAction(nameof(GetPaymentSolution), new { id = createUser.IdPaymentSolution }, createUser);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new employee record");
            }

        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<PaymentSolution>> DeletePaymentSolution(int id)
        {
            try
            {
                var userToDelete = await _PaymentSolutionRepository.GetPaymentSolution(id);

                if (userToDelete == null)
                {
                    return NotFound($"User with Id = {id} not found");
                }
                return await _PaymentSolutionRepository.DeletePaymentSolution(id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error creating new employee record");
            }
        }
    }
}