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
    public class PayersController : Controller
    {

        private readonly IPayersRepository _payerlRepository;

        public PayersController(IPayersRepository payerlRepository)
        {
            this._payerlRepository = payerlRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult<IEnumerable<PayersTable>>> GetPayers()
        {
            try
            {
                return (await _payerlRepository.GetPayers()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        public async Task<ActionResult<PayersTable>> GetPayer(int id)
        {
            try
            {
                return (await _payerlRepository.GetPayer(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        public async Task<ActionResult<PayersTable>> UpdatePayer(int id, PayersTable payer)
        {
            try
            {
                if (payer == null)
                    return BadRequest();

                var userToUpdate = await _payerlRepository.GetPayer(id);
                if (userToUpdate == null)
                    return NotFound($"No user with Id= {id}");
                return await _payerlRepository.UpdatePayer(payer);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating user");
            }
        }
        public async Task<ActionResult<PayersTable>> AddUserModel(PayersTable payermodel)
        {
            try
            {
                if (payermodel == null)
                    return BadRequest();

                var createUser = await _payerlRepository.AddPayer(payermodel);
                return CreatedAtAction(nameof(GetPayer), new { id = createUser.IdPayer }, createUser);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new employee record");
            }

        }
        public async Task<ActionResult<PayersTable>> DeleteUserModel(int id)
        {
            try
            {

                var userToDelete = await _payerlRepository.GetPayer(id);

                if (userToDelete == null)
                {
                    return NotFound($"User with Id = {id} not found");
                }
                return await _payerlRepository.DeletePayer(id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new employee record");
            }

        }
    }
}
