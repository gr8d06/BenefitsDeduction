using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Benefits.Api.Interfaces;
using Benefits.Api.Models;
using Benefits.Api.Repositories;
using Benefits.Api.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Benefits.Api.Controllers { 

    [ApiController]
    [Route("[controller]")]
    public class EnrolleesController : ControllerBase
    {
        IEnrolleeRepository enrolleeRepository = null;
        IConfiguration configuration = null;
        LinkGenerator linkGenerator = null;

        public EnrolleesController(IEnrolleeRepository enrolleeRepository, IConfiguration configuration, LinkGenerator linkGenerator)
        {
            this.enrolleeRepository = enrolleeRepository;
            this.configuration = configuration;
            this.linkGenerator = linkGenerator; 
        }

        [HttpGet]
        public async Task<ActionResult<List<EnrolleeDto>>> Get()
        {
            try
            {
                var enrolleeList = await enrolleeRepository.SelectAllEnrollees();
                return Ok(enrolleeList);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult result;
            try
            {
                var enrollee = enrolleeRepository.SelectEnrolleeById(id);

                if (enrollee.Id == id)
                {
                    result = Ok(enrollee);
                }
                else
                {
                    result = NotFound();
                }
            }
            catch
            {
                result = StatusCode(500);
            }
            return result;
        }


        [HttpPost]
        public async Task<ActionResult<EnrolleeDto>> Post(EnrolleeDto enrollee)
        {
            try
            { 
               bool result = await EnrolleeDtoValidator.ValidateEnrolleeDto(enrollee, configuration);
                if (result)
                {
                    EnrolleeRepository enrolleeRepo = new EnrolleeRepository(configuration);
                    var newId = await enrolleeRepo.InsertEnrollee(enrollee);
                    var location = linkGenerator.GetPathByAction("Get", "Enrollees", new { id = newId });
                    var newEnrollee = await enrolleeRepo.SelectEnrolleeById(newId);
                    return Created(location, newEnrollee); 
                }
                return BadRequest();
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}
