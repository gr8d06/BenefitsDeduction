﻿using Benefits.Api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Benefits.Api.Repositories
{
    public class PolicyRepository
    {
        private string _connectionString = "Data Source=localhost;Initial Catalog=Benefits;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public List<PolicyDto> SelectAllPolicies()
        {
            var policyList = new List<PolicyDto>();
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();

                using SqlCommand command = new SqlCommand(PolicySprocs.SelectAll, connection);
                using SqlDataReader reader = command.ExecuteReader();
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

        public PolicyDto SelectPolicyById(int id)
        {
            var policy= new PolicyDto();
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();

                using SqlCommand command = new SqlCommand(PolicySprocs.SelectById, connection);
                command.Parameters.AddWithValue("@Id", id);

                using SqlDataReader reader = command.ExecuteReader();
                policy = MapPolicyDto(reader);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return policy;

        }

        private PolicyDto MapPolicyDto(SqlDataReader reader) => new PolicyDto()
        {
            Id = Convert.ToInt32(reader["Id"]),
            IsActive = (bool)reader["IsActive"],
            Description = reader["Description"].ToString(),
            PrimaryPrice = decimal.Round(Convert.ToDecimal(reader["PrimaryPrice"]), 2, MidpointRounding.AwayFromZero),
            DependantPrice = decimal.Round(Convert.ToDecimal(reader["DependantPrice"]), 2, MidpointRounding.AwayFromZero)
        };



        internal static class PolicySprocs
        {
            public static string SelectAll => "dbo.SelectAllPolicies";
            public static string SelectById => "dbo.SelectPolicyById";
            public static string Insert => "dbo.InsertPolicy";
            public static string Delete => "dbo.DeletePolicyById";

        }
    }
}
