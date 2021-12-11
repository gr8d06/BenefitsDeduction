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
        // GET: api/<PolicyController>
        [HttpGet]
        public IActionResult Get()
        {
            List<PolicyDto> policies;

            try
            {
                var repo = new PolicyRepository();
                policies = repo.SelectAllPolicies();
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
                var repo = new PolicyRepository();
                policy = repo.SelectPolicyById(id);
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
        public IActionResult Post([FromBody] string value)
        {
            var repo = new PolicyController();
            try
            {
                //TODO: map the submitted body value to an object. 
                repo.Post(value);
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
            var repo = new PolicyRepository();
            repo.DeletePolicyById(id);
        }
    }
}
