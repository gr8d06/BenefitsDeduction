using Benefits.Api.Interfaces;
using Benefits.Api.Models;
using Benefits.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Benefits.Api.Repositories
{
    public class EnrolleeRepository : IEnrolleeRepository
    {

        // Would not typically leave a connection string in the class
        // This is for demo only. Store in a config file or secure location. 
        private string _connectionString = "Data Source=localhost;Initial Catalog=Benefits;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // Would be good to inject in a database interface instead of creating in the repo: loose coupling. 
        // Entity framework is a good option for managing the ORM and Repos, but this will due for demonstration. 

        public EnrolleeRepository()
        { }

        public void DeleteEnrolleeById(int Id)
        {
            throw new NotImplementedException();
        }

        public void InsertEnrollee(IEnrollee enrollee)
        {
            throw new NotImplementedException();
        }

        public  List<IEnrollee> SelectAllEnrollees()
        {            
            List<IEnrollee> enrolleeList = new List<IEnrollee>(); ;

            try
            {
                //objects in the "using" statements are destroyed after scope leaves the method. 
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();

                using SqlCommand command = new SqlCommand(EnrolleeSprocs.SelectAll, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var enrollee = MapEnrolleeDto(reader);
                    enrolleeList.Add(enrollee);
                }

                //enrolleeList.GroupBy(x => x.PrimaryId).Select(y => new)
                //Create a subset/list of dependants, group by primaryId, assign the groups to dependants where primaryId = Id.

            }
            catch(Exception e)
            {
                Console.WriteLine($"An error has occured. {e.Message}");
            }

            return enrolleeList;
        }

        public IEnrollee SelectEnrolleeById(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEnrollee(IEnrollee enrollee)
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
                IsPrimary = (bool)reader["IsActiveAccount"],
                EnrolledDate = Convert.ToDateTime(reader["StartDate"]).Date,
                PrimaryId = Convert.ToInt32(reader["PrimaryId"]),
                Address = reader["Address"].ToString(),
                Relation = reader["Relation"].ToString()
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


