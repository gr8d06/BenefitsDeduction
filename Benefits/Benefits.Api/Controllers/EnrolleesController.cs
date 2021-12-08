using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Benefits.Api.Interfaces;
using Benefits.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Benefits.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnrolleesController : ControllerBase
    {
        //[HttpGet]
        //public IEnumerable<IEnrollee> Get()
        //{
        //    return new List<IEnrollee>()
        //    {
        //        new Primary(){Id = 1, FirstName="Alex", LastName="Dane", IsPrimary=true, IsActive=true, Address="5457 S 700 E, Whitestown, IN 46075", EnrolledDate=DateTime.Now.Date, PolicyNumber=123, PrimaryId=0, Relation="Primary" } 
        //    };
        //}
        [HttpGet]
        public object Get()
        {
            string enrolleeList = System.IO.File.ReadAllText("C:\\Workspace\\Benefits3\\Benefits.Api\\Enrollees.json");
            //object jsonObj = JsonConvert.SerializeObject(enrolleeList);
            return enrolleeList;
        }

        //[HttpGet]
        //public IEnrollee Get(int Id)
        //{

        //}
    }
}
