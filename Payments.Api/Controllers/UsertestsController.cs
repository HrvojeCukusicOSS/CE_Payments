using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Models;
using Payments.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsertestsController : Controller
    {
        private readonly IUserTestRepository userTestRepository;

        public UsertestsController(IUserTestRepository userTestRepository)
        {
            this.userTestRepository = userTestRepository;

        }

        [HttpGet]
        [Route("List")]
        public async Task<ActionResult<IEnumerable<UserTest>>> GetUserTests()
        {

            try
            {
               
                return (await userTestRepository.GetUserTests()).ToList();
                
            }
            catch(Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("List/{id:int}")]
        public async Task<ActionResult<UserTest>> GetUsertest(int id)
        {
            try
            {
                var result = await userTestRepository.GetUserTest(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPut("List/{id:int}")]
        public async Task<ActionResult<UserTest>> UpdateUserTest(int id, UserTest userTest)
        {
            try
            {
                if (userTest == null)
                    return BadRequest();

                var userToUpdate = await userTestRepository.GetUserTest(id);
                if (userToUpdate == null)
                    return NotFound($"No user with Id= {id}");
                return await userTestRepository.UpdateUserTest(userTest);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating user");
            }
        
        }
        [HttpPost("List/{id:int}")]
        public async Task<ActionResult<UserTest>> AddUserTest(UserTest userTest)
        {
            try
            {
                if (userTest == null)
                    return BadRequest();

                var createUser = await userTestRepository.AddUserTest(userTest);
                return CreatedAtAction(nameof(GetUsertest), new { id = createUser.UserTestId }, createUser);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new employee record");
            }

        }
        [HttpDelete("List/{id:int}")]
        public async Task<ActionResult<UserTest>> DeleteUserTest(int id)
        {
            try
            {

                var userToDelete = await userTestRepository.GetUserTest(id);

                if(userToDelete == null)
                {
                    return NotFound($"User with Id = {id} not found");
                }
                return await userTestRepository.DeleteUserTest(id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new employee record");
            }

        }

    }
}
