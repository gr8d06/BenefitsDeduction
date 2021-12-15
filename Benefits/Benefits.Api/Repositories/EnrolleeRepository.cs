using Benefits.Api.Interfaces;
using Benefits.Api.Models;
using Benefits.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace Benefits.Api.Repositories
{
    public class EnrolleeRepository : IEnrolleeRepository
    {
        private string _connectionString = "";

        public EnrolleeRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionString"];
        }


        //We have the option here to make these Async by wrapping the return object in a Task and giving the keyword Async e.g  async Task<List<IEnrollee>> ....
        // then use the await keyword and a ReadAsync() method on the reader. 
        public async Task<List<IEnrollee>> SelectAllEnrollees()
        {            
            List<IEnrollee> enrolleeList = new List<IEnrollee>(); ;
            List<IEnrollee> primaryList = new List<IEnrollee>(); ;

            try
            {
                //objects in the "using" statements are destroyed after scope leaves the method. 
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();

                using SqlCommand command = new SqlCommand(EnrolleeSprocs.SelectAll, connection);
                using SqlDataReader reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    var enrollee = MapEnrolleeDto(reader);
                    enrolleeList.Add(enrollee);
                }

                primaryList = enrolleeList.Where(x=>x.IsPrimary == true).ToList();
                var dependantsList = enrolleeList.Where(x=> x.IsPrimary == false).ToList();

                foreach(var primary in primaryList)
                {
                    primary.DependantsList = dependantsList.Where(d => d.PrimaryId == primary.Id).ToList();
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine($"An error has occured. {e.Message}");
            }

            return primaryList;
        }

        public async Task<IEnrollee> SelectEnrolleeById(int Id)
        {
            EnrolleeDto enrollee = null;
            try
            {
                //objects in the "using" statements are destroyed after scope leaves the method. 
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();

                using SqlCommand command = new SqlCommand(EnrolleeSprocs.SelectById, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                using SqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    enrollee = MapEnrolleeDto(reader);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"An error has occured. {e.Message}");
            }
            return enrollee;
        }

        public async Task<int> InsertEnrollee(IEnrollee enrollee)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();

                using SqlCommand command = new SqlCommand(EnrolleeSprocs.Insert, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FirstName", enrollee.FirstName);
                command.Parameters.AddWithValue("@LastName", enrollee.LastName);
                command.Parameters.AddWithValue("@IsActiveAccount", true);
                command.Parameters.AddWithValue("@IsPrimary", enrollee.IsPrimary);
                command.Parameters.AddWithValue("@StartDate", DateTime.UtcNow);
                command.Parameters.AddWithValue("@PrimaryId", enrollee.IsPrimary ? 0 : enrollee.PrimaryId); //Should do this earlier. 
                command.Parameters.AddWithValue("@Address", enrollee.Address);
                command.Parameters.AddWithValue("@PolicyId", 1); //Again, hard coding for demo only. 
                command.Parameters.AddWithValue("@Relation", enrollee.Relation);
                command.Parameters.AddWithValue("@PayCheckDeduction", enrollee.PayCheckDeduction);

                command.Parameters.Add("@Id", SqlDbType.Int);
                command.Parameters["@Id"].Direction = ParameterDirection.Output;

                await command.ExecuteNonQueryAsync();
                return Convert.ToInt32(command.Parameters["@Id"].Value);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); //throw this back up the chain for now. Let the controller handle it.
            }
        }

        public void UpdateEnrollee(IEnrollee enrollee)
        {
            throw new NotImplementedException();
        }

        public void DeleteEnrolleeById(int Id)
        {
            throw new NotImplementedException();
        }

        private EnrolleeDto MapEnrolleeDto(SqlDataReader reader)
        {
            return new EnrolleeDto()
            {
                Id = Convert.ToInt32(reader["Id"]),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                IsActive = (bool)reader["IsActiveAccount"],
                IsPrimary = (bool)reader["IsPrimary"],
                EnrolledDate = Convert.ToDateTime(reader["StartDate"]).Date,
                PrimaryId = Convert.ToInt32(reader["PrimaryId"]),
                Address = reader["Address"].ToString(),
                Relation = reader["Relation"].ToString(),
                PolicyNumber = Convert.ToInt32(reader["PolicyId"]),
                PayCheckDeduction = decimal.Round(Convert.ToDecimal(reader["PaycheckDeduction"]),2,MidpointRounding.AwayFromZero)
            };
        }

        internal static class EnrolleeSprocs{
            public static string SelectAll => "dbo.SelectAllEnrollees";
            public static string SelectById => "dbo.SelectEnrolleeById";
            public static string Insert => "dbo.InsertEnrollee";
            public static string Delete => "dbo.DeleteEnrolleeById";

        }



    }
}


