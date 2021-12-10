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
            try
            {
                string enrolleeList = System.IO.File.ReadAllText(".\\Enrollees.json");
                return Ok(enrolleeList);
            }
            catch
            {
                return StatusCode(500);
            }
        }


        [HttpPost]
        public IActionResult Post()
        {
            return Ok("post hit");
        }

    }
}
