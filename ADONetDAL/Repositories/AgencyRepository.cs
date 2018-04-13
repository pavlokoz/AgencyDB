using AgencyModels.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ADONetDAL.Repositories
{
    public class AgencyRepository
    {
        #region Constructors 
        public AgencyRepository() { }
        #endregion

        #region public methods for agency
        public virtual IList<AgencyModel> GetAgencies()
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager
                .ConnectionStrings["AgencyDBConnectionString"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAgencies", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    IList<AgencyModel> listToReturn = new List<AgencyModel>();
                    while (reader.Read())
                    {
                        listToReturn.Add(new AgencyModel
                        {
                            Name = reader["Name"].ToString(),
                            Address = reader["Street"].ToString() + reader["HouseNumber"].ToString(),
                            City = reader["CityName"].ToString()
                        });
                    }
                    return listToReturn;
                }
            }
        }

        public virtual IList<AgencyModel> GetAgenciesByName(string agencyName)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager
                .ConnectionStrings["AgencyDBConnectionString"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAgenciesByName", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("AgencyName", agencyName);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    IList<AgencyModel> listToReturn = new List<AgencyModel>();
                    while (reader.Read())
                    {
                        listToReturn.Add(new AgencyModel
                        {
                            Name = reader["Name"].ToString(),
                            Address = reader["Street"].ToString() + reader["HouseNumber"].ToString(),
                            City = reader["CityName"].ToString()
                        });
                    }
                    return listToReturn;
                }
            }
        }
        #endregion
    }
}
