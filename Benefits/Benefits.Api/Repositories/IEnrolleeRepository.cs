using Benefits.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benefits.Api.Repositories
{
    public interface IEnrolleeRepository
    {
        public List<IEnrollee> SelectAllEnrollees();
        public IEnrollee SelectEnrolleeById(int Id);

        public void InsertEnrollee(IEnrollee enrollee);
        public void DeleteEnrolleeById(int Id);
        public void UpdateEnrollee(IEnrollee enrollee);
    }
}
