using Benefits.Api.Models;
using Benefits.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Benefits.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        IPolicyRepository policyRepository = null;
        public PolicyController(IPolicyRepository policyRepository)
        {
            this.policyRepository = policyRepository;
        }

        // GET: api/<PolicyController>
        [HttpGet]
        public IActionResult Get()
        {
            List<PolicyDto> policies;

            try
            {
                policies = policyRepository.SelectAllPolicies();
            }
            catch
            {
                return StatusCode(500);
            }

            return Ok(policies);
        }

        // GET api/<PolicyController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult result;
            PolicyDto policy;

            try
            {
                policy = policyRepository.SelectPolicyById(id);
            }
            catch
            {
                return StatusCode(500);
            }

            // result = policy.Id == id ? Ok(policy) : NotFound(500); // This is not valid in Version 8, Upgrade to 9, and this should work

            if (policy.Id == id)
            {
                result = Ok(policy);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // POST api/<PolicyController>
        [HttpPost]
        public IActionResult Post(PolicyDto value)
        {
            try
            {
                policyRepository.InsertPolicy(value);
            }
            catch
            {
                return StatusCode(500);
            }
            return Ok();
        }

        // DELETE api/<PolicyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            policyRepository.DeletePolicyById(id);
        }
    }
}
