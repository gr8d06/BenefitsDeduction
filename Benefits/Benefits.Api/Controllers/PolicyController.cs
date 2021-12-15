using Benefits.Api.Models;
using Benefits.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult<PolicyDto>> Get()
        {
            List<PolicyDto> policies;

            try
            {
                policies = await policyRepository.SelectAllPolicies();
            }
            catch
            {
                return StatusCode(500);
            }

            return Ok(policies);
        }

        // GET api/<PolicyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PolicyDto>> Get(int id)
        {
            PolicyDto policy;

            try
            {
                policy = await policyRepository.SelectPolicyById(id);
            }
            catch
            {
                return StatusCode(500);
            }

            if (policy.Id == id)
            {
               return policy;
            }
            else
            {
               return NotFound();
            }
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
