using Benefits.Api.Models;
using System.Collections.Generic;

namespace Benefits.Api.Repositories
{
    public interface IPolicyRepository
    {
        public List<PolicyDto> SelectAllPolicies();
        public PolicyDto SelectPolicyById(int id);
        public void InsertPolicy(PolicyDto policy);
        public void DeletePolicyById(int id);

    }
}
