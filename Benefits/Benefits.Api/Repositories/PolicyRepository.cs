using Benefits.Api.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Benefits.Api.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private string _connectionString = "";
        public PolicyRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionString"];
        }

        public async Task<List<PolicyDto>> SelectAllPolicies()
        {
            var policyList = new List<PolicyDto>();
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();

                using SqlCommand command = new SqlCommand(PolicySprocs.SelectAll, connection);
                command.CommandType = CommandType.StoredProcedure;
                using SqlDataReader reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    var policy = MapPolicyDto(reader);
                    policyList.Add(policy);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return policyList;

        }

        public async Task<PolicyDto> SelectPolicyById(int id)
        {
            var policy = new PolicyDto();
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();

                using SqlCommand command = new SqlCommand(PolicySprocs.SelectById, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                using SqlDataReader reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    policy = MapPolicyDto(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return policy;

        }

        public void InsertPolicy(PolicyDto policy)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();

                using SqlCommand command = new SqlCommand(PolicySprocs.SelectById, connection);
                command.Parameters.AddWithValue("@IsActive", policy.IsActive);
                command.Parameters.AddWithValue("@Description", policy.Description);
                command.Parameters.AddWithValue("@PrimaryPrice", policy.PrimaryPrice);
                command.Parameters.AddWithValue("@DependantPrice", policy.DependantPrice);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeletePolicyById(int id)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();

                using SqlCommand command = new SqlCommand(PolicySprocs.Delete, connection);
                command.Parameters.AddWithValue("@Id", id);

                var result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private PolicyDto MapPolicyDto(SqlDataReader reader)
        {
            PolicyDto policy = new PolicyDto
            {
                Id = Convert.ToInt32(reader["Id"]),
                IsActive = (bool)reader["IsActive"],
                Description = reader["Description"].ToString(),
                PrimaryPrice = decimal.Round(Convert.ToDecimal(reader["PrimaryPrice"]), 2, MidpointRounding.AwayFromZero),
                DependantPrice = decimal.Round(Convert.ToDecimal(reader["DependantPrice"]), 2, MidpointRounding.AwayFromZero)
            };

            return policy;
        }



        internal static class PolicySprocs
        {
            public static string SelectAll => "dbo.SelectAllPolicies";
            public static string SelectById => "dbo.SelectPolicyById";
            public static string Insert => "dbo.InsertPolicy";
            public static string Delete => "dbo.DeletePolicyById";

        }
    }
}
