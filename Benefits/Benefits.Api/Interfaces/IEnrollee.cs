using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.Api.Interfaces
{
    public interface IEnrollee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsPrimary { get; set; }
        public string Address { get; set; }
        public DateTime EnrolledDate { get; set; }
        public bool IsActive { get; set; }
        public int PolicyNumber { get; set; }
        public int PrimaryId { get; set; }
        public string Relation { get; set; }
        public decimal PayCheckDeduction { get; set; }
        public List<IEnrollee> DependantsList { get; set;}
    }
}
