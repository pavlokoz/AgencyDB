using AgencyModels.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ADONetDAL.Repositories
{
    public class CampaignRepository
    {
        #region Constructors
        public CampaignRepository() { }
        #endregion

        #region public methods for campaign
        public virtual IList<CampaignModel> GetCampaigns()
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager
                .ConnectionStrings["AgencyDBConnectionString"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetCampaigns", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    IList<CampaignModel> listToReturn = new List<CampaignModel>();
                    while (reader.Read())
                    {
                        listToReturn.Add(new CampaignModel
                        {
                            CampaignName = reader["CampaignName"].ToString(),
                            AgencyName = reader["Name"].ToString(),
                            Characteristic = reader["Characteristic"].ToString(),
                            Slogan = reader["Slogan"].ToString(),
                            StartDate = DateTime.Parse(reader["StartDate"].ToString()),
                            EndDate = DateTime.Parse(reader["EndDate"].ToString())
                        });
                    }
                    return listToReturn;
                }
            }
        }

        public virtual IList<CampaignModel> GetCampaignsByAgencyName(string agencyName)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager
                .ConnectionStrings["AgencyDBConnectionString"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetCampaignsByAgencyName", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("AgencyName", agencyName);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    IList<CampaignModel> listToReturn = new List<CampaignModel>();
                    while (reader.Read())
                    {
                        listToReturn.Add(new CampaignModel
                        {
                            CampaignName = reader["CampaignName"].ToString(),
                            AgencyName = reader["Name"].ToString(),
                            Characteristic = reader["Characteristic"].ToString(),
                            Slogan = reader["Slogan"].ToString(),
                            StartDate = DateTime.Parse(reader["StartDate"].ToString()),
                            EndDate = DateTime.Parse(reader["EndDate"].ToString())
                        });
                    }
                    return listToReturn;
                }
            }
        }

        public virtual IList<CampaignModel> GetCampaignsWithCost()
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager
                .ConnectionStrings["AgencyDBConnectionString"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetCampaignsWithCost", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    IList<CampaignModel> listToReturn = new List<CampaignModel>();
                    while (reader.Read())
                    {
                        listToReturn.Add(new CampaignModel
                        {
                            CampaignName = reader["CampaignName"].ToString(),
                            AgencyName = reader["AgencyName"].ToString(),
                            Characteristic = reader["Characteristic"].ToString(),
                            Slogan = reader["Slogan"].ToString(),
                            StartDate = DateTime.Parse(reader["StartDate"].ToString()),
                            EndDate = DateTime.Parse(reader["EndDate"].ToString()),
                            TotalCost = Convert.ToDecimal(reader["TotalAccount"])
                        });
                    }
                    return listToReturn;
                }
            }
        }
        #endregion
    }
}
