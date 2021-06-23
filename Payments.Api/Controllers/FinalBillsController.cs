using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payments.Domain.Repository;
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
    public class FinalBillsController : Controller
    {   

        private readonly IFinallBillRepository _finalBillRepository;

        public FinalBillsController(IFinallBillRepository _finalBillRepository)
        {
            this._finalBillRepository = _finalBillRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinalBill>>> GetFinalBills() 
        {
            try
            {
                return (await _finalBillRepository.GetFinalBills()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<FinalBill>> GetFinalBill(int id)
        {
            try
            {
                var v = (await _finalBillRepository.GetFinalBill(id));
                return v;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<FinalBill>> UpdateFinalBill(int id, FinalBill finalBill)
        {
            try
            {
                if (finalBill == null)
                    return BadRequest();

                var userToUpdate = await _finalBillRepository.GetFinalBill(id);
                if (userToUpdate == null)
                    return NotFound($"No bill with Id= {id}");
                return await _finalBillRepository.UpdateFinalBill(finalBill);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating user");
            }

        }
        [HttpPost]
        [Route("/{id:int}")]
        public async Task<ActionResult<FinalBill>> AddFinalBill(FinalBill payermodel)
        {
            try
            {
                if (payermodel == null)
                    return BadRequest();

                var createUser = await _finalBillRepository.AddFinalBill(payermodel);
                return CreatedAtAction(nameof(GetFinalBill), new { id = createUser.IdFinalBill }, createUser);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new employee record");
            }

        }
        [HttpDelete]
        [Route("/{id:int}")]
        public async Task<ActionResult<FinalBill>> DeleteFinalBill(int id)
        {
            try
            {

                var userToDelete = await _finalBillRepository.GetFinalBill(id);

                if (userToDelete == null)
                {
                    return NotFound($"User with Id = {id} not found");
                }
                return await _finalBillRepository.DeleteFinalBill(id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new employee record");
            }

        }
    }
}
