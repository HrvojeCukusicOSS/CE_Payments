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
    public class PaymentInformationController : Controller
    {

        private readonly IPaymentInformationRepository _PaymentInformationRepository;

        public PaymentInformationController(IPaymentInformationRepository receiverlRepository)
        {
            this._PaymentInformationRepository = receiverlRepository;
        }
      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentInformation>>> GetPaymentInformations()
        {
            try
            {
                return (await _PaymentInformationRepository.GetPaymentInformations()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<PaymentInformation>> GetPaymentInformation(int id)
        {
            try
            {
                return (await _PaymentInformationRepository.GetPaymentInformation(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost]
        [Route("{status}")]
        public async Task<ActionResult<PaymentInformation>> UpdatePaymentInformation( PaymentInformation status)
        {
            try
            {
                if (status == null)
                    return BadRequest();

                var userToUpdate = await _PaymentInformationRepository.GetPaymentInformation(status.IdPaymentInformation);
                if (userToUpdate == null)
                    return NotFound($"No user with Id= {status.IdPaymentInformation}");
               
                return await _PaymentInformationRepository.UpdatePaymentInformation(status);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating user");
            }
        }
        [HttpPost]
        [Route("{status}")]
        public async Task<ActionResult<PaymentInformation>> AddPaymentInformation(PaymentInformation status)
        {
            try
            {
                if (status == null)
                    return BadRequest();

                var createUser = await _PaymentInformationRepository.AddPaymentInformation(status);
                return CreatedAtAction(nameof(GetPaymentInformation), new { id = createUser.IdPaymentInformation }, createUser);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new employee record");
            }

        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<PaymentInformation>> DeletePaymentInformation(int id)
        {
            try
            {
                var userToDelete = await _PaymentInformationRepository.GetPaymentInformation(id);

                if (userToDelete == null)
                {
                    return NotFound($"User with Id = {id} not found");
                }
                return await _PaymentInformationRepository.DeletePaymentInformation(id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error creating new employee record");
            }
        }
    }
}