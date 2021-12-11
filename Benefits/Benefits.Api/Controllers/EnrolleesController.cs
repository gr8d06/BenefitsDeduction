using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Benefits.Api.Interfaces;
using Benefits.Api.Models;
using Benefits.Api.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Benefits.Api.Controllers { 

    [ApiController]
    [Route("[controller]")]
    public class EnrolleesController : ControllerBase
    {

        public EnrolleesController()
        {}

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var repo = new EnrolleeRepository();
                var enrolleeList = repo.SelectAllEnrollees();
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
                var repo = new EnrolleeRepository();
                var enrollee = repo.SelectEnrolleeById(id);

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
                PolicyRepository polRepo = new PolicyRepository();
                var policy = polRepo.SelectPolicyById(1);  //HARD CODED for demo and time sake only. 

                if (enrollee == null ||
                    string.IsNullOrEmpty(enrollee.FirstName) ||
                    string.IsNullOrEmpty(enrollee.LastName) ||
                    string.IsNullOrEmpty(enrollee.Address))
                {
                    return BadRequest();
                }

                if (enrollee.IsPrimary)
                {
                    enrollee.PayCheckDeduction = CalculateRate(policy.PrimaryPrice, enrollee.FirstName);
                }
                else
                {
                    //this should be a dependant with a valid id that links to a primary.
                    if (enrollee.PrimaryId <= 0)
                    {
                        return BadRequest();
                    }

                    enrollee.PayCheckDeduction = CalculateRate(policy.DependantPrice, enrollee.FirstName);
                }

                EnrolleeRepository enrolleeRepo = new EnrolleeRepository();
                enrolleeRepo.InsertEnrollee(enrollee);

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        private decimal CalculateRate(decimal yearlyRate, string firstName)
        {
            decimal deductionRate = yearlyRate / 26;
            if (firstName.ToLower()[0] == 'a') 
            {
                deductionRate *= 0.9M;
            }
            
            return Math.Round(deductionRate,2,MidpointRounding.AwayFromZero);
        }

    }
}
