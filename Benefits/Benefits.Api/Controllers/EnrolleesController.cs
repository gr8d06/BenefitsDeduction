using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Benefits.Api.Interfaces;
using Benefits.Api.Models;
using Benefits.Api.Repositories;
using Benefits.Api.Validators;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Benefits.Api.Controllers { 

    [ApiController]
    [Route("[controller]")]
    public class EnrolleesController : ControllerBase
    {
        IEnrolleeRepository enrolleeRepository = null;
        public EnrolleesController(IEnrolleeRepository enrolleeRepository)
        {
            this.enrolleeRepository = enrolleeRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var enrolleeList = enrolleeRepository.SelectAllEnrollees();
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
        public IActionResult Post(EnrolleeDto enrollee)
        {
            try
            {
               bool result = EnrolleeDtoValidator.ValidateEnrolleeDto(enrollee);
                if (result)
                {
                    EnrolleeRepository enrolleeRepo = new EnrolleeRepository();
                    enrolleeRepo.InsertEnrollee(enrollee);
                    return Ok();
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
