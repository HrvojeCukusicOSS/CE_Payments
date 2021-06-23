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
    public class ReceiversController : Controller
    {

        private readonly IReceiversRepository _receiverlRepository;

        public ReceiversController(IReceiversRepository receiverlRepository)
        {
            this._receiverlRepository = receiverlRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult<IEnumerable<ReceiversTable>>> GetReceivers()
        {
            try
            {
                return (await _receiverlRepository.GetReceivers()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        public async Task<ActionResult<ReceiversTable>> GetReceiver(int id)
        {
            try
            {
                return (await _receiverlRepository.GetReceiver(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        public async Task<ActionResult<ReceiversTable>> UpdateReceiver(int id, ReceiversTable receiver)
        {
            try
            {
                if (receiver == null)
                    return BadRequest();

                var userToUpdate = await _receiverlRepository.GetReceiver(id);
                if (userToUpdate == null)
                    return NotFound($"No user with Id= {id}");
                return await _receiverlRepository.UpdateReceiver(receiver);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating user");
            }
        }
        public async Task<ActionResult<ReceiversTable>> AddUserModel(ReceiversTable receivermodel)
        {
            try
            {
                if (receivermodel == null)
                    return BadRequest();

                var createUser = await _receiverlRepository.AddReceiver(receivermodel);
                return CreatedAtAction(nameof(GetReceiver), new { id = createUser.IdReceiver }, createUser);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new employee record");
            }

        }
        public async Task<ActionResult<ReceiversTable>> DeleteUserModel(int id)
        {
            try
            {

                var userToDelete = await _receiverlRepository.GetReceiver(id);

                if (userToDelete == null)
                {
                    return NotFound($"User with Id = {id} not found");
                }
                return await _receiverlRepository.DeleteReceiver(id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new employee record");
            }

        }
    }
}
