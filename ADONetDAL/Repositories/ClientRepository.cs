using AgencyModels.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ADONetDAL.Repositories
{
    public class ClientRepository
    {
        #region Constructors 
        public ClientRepository() { }
        #endregion

        #region public methods for client
        public virtual IList<ClientModel> GetClients()
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager
                .ConnectionStrings["AgencyDBConnectionString"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetClients", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    IList<ClientModel> listToReturn = new List<ClientModel>();
                    while (reader.Read())
                    {
                        listToReturn.Add(new ClientModel
                        {
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString()
                        });
                    }
                    return listToReturn;
                }
            }
        }

        public virtual IList<ClientModel> GetClientsByName(string name)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager
                .ConnectionStrings["AgencyDBConnectionString"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetClientsByName", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("Name", name);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    IList<ClientModel> listToReturn = new List<ClientModel>();
                    while (reader.Read())
                    {
                        listToReturn.Add(new ClientModel
                        {
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString()
                        });
                    }
                    return listToReturn;
                }
            }
        }

        public virtual IList<ClientModel> GetDebtorClients()
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager
                .ConnectionStrings["AgencyDBConnectionString"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetDebtorClients", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    IList<ClientModel> listToReturn = new List<ClientModel>();
                    while (reader.Read())
                    {
                        listToReturn.Add(new ClientModel
                        {
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString()
                        });
                    }
                    return listToReturn;
                }
            }
        }

        #endregion
    }
}
