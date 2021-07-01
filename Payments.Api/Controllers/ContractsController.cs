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
    public class ContractsController : Controller
    {   

        private readonly IContractRepository _contractRepository;

        public ContractsController(IContractRepository _contractRepository)
        {
            this._contractRepository = _contractRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contract>>> GetContracts() 
        {
            try
            {
                

                return (await _contractRepository.GetContracts()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Contract>> GetContract(int id)
        {
            try
            {
                var v = (await _contractRepository.GetContract(id));
                return v;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        
    }
}
