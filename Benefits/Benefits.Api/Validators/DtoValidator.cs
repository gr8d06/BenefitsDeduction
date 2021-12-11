using Benefits.Api.Interfaces;
using Benefits.Api.Repositories;
using System;

namespace Benefits.Api.Validators
{
    public static class DtoValidator
    {

        public static bool ValidateEnrolleeDto(IEnrollee enrollee)
        {
            bool result = true;

            PolicyRepository polRepo = new PolicyRepository();
            var policy = polRepo.SelectPolicyById(1);  //HARD CODED for demo and time sake only. 

            if (enrollee == null ||
                string.IsNullOrEmpty(enrollee.FirstName) ||
                string.IsNullOrEmpty(enrollee.LastName) ||
                string.IsNullOrEmpty(enrollee.Address))
            {
                return result;
            }

            if (enrollee.IsPrimary)
            {
                enrollee.PayCheckDeduction = CalculateRate(policy.PrimaryPrice, enrollee.FirstName);
            }
            else
            {
                //this should be a dependant with a valid id that links to a primary.
                if (enrollee.PrimaryId <= 0)
                {
                    return result;
                }

                enrollee.PayCheckDeduction = CalculateRate(policy.DependantPrice, enrollee.FirstName);
            }

            EnrolleeRepository enrolleeRepo = new EnrolleeRepository();
            enrolleeRepo.InsertEnrollee(enrollee);
            
            return result;
        }

        private static decimal CalculateRate(decimal yearlyRate, string firstName)
        {
            decimal deductionRate = yearlyRate / 26;
            if (firstName.ToLower()[0] == 'a')
            {
                deductionRate *= 0.9M;
            }

            return Math.Round(deductionRate, 2, MidpointRounding.AwayFromZero);
        }
    }
}
