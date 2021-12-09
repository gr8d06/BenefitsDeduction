using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Benefits.Api.Interfaces;
using Benefits.Api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Benefits.Api.Controllers { 

    [ApiController]
    [Route("[controller]")]
    public class EnrolleesController : ControllerBase
    {


        [HttpGet]
        public object Get()
        {
            string enrolleeList = System.IO.File.ReadAllText(".\\Enrollees.json");
            //object jsonObj = JsonConvert.SerializeObject(enrolleeList);
            return enrolleeList;
        }

        [HttpPost]
        public object Post()
        {

            return "post hit";
        }

    }
}
