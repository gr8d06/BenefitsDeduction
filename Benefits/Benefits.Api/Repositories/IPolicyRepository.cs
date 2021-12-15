using Benefits.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Benefits.Api.Repositories
{
    public interface IPolicyRepository
    {
        public Task<List<PolicyDto>> SelectAllPolicies();
        public Task<PolicyDto> SelectPolicyById(int id);
        public void InsertPolicy(PolicyDto policy);
        public void DeletePolicyById(int id);

    }
}
