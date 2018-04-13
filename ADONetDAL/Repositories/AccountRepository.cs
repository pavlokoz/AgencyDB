using System.Collections.Generic;
using System.Data.SqlClient;
using AgencyModels.Models;
using System.Configuration;
using System.Data;
using System;

namespace ADONetDAL.Repositories
{
    public class AccountRepository
    {
        #region Constructors
        public AccountRepository() { }
        #endregion

        #region public methods for account
        public virtual IList<AccountModel> GetPaidAccounts()
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager
                .ConnectionStrings["AgencyDBConnectionString"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetPaidAccount", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    IList<AccountModel> listToReturn = new List<AccountModel>();
                    while (reader.Read())
                    {
                        listToReturn.Add(new AccountModel
                        {
                            CampaignName = reader["CampaignName"].ToString(),
                            Account = Convert.ToDecimal(reader["Account"]),
                            ClientFullName = reader["FullName"].ToString()
                        });
                    }
                    return listToReturn;
                }
            }
        }
        #endregion
    }
}
