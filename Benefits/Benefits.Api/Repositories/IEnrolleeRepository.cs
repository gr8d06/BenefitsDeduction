using Benefits.Api.Interfaces;
using Benefits.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benefits.Api.Repositories
{
    public interface IEnrolleeRepository
    {
        
        public Task<List<IEnrollee>> SelectAllEnrollees();
        public Task<IEnrollee> SelectEnrolleeById(int Id);

        public Task<int>InsertEnrollee(IEnrollee enrollee);
        public void DeleteEnrolleeById(int Id);
        public void UpdateEnrollee(IEnrollee enrollee);
    }
}
