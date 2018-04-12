using System.Linq;
using DAL.Models;
using DBModels = AgencyModels.Models.AdvAgenciesDBEntities;

namespace DAL.Repositories
{
    public class AccountRepository
    {
        private DBModels dbModels;

        #region constructors
        public AccountRepository()
        {
            dbModels = new DBModels();
        }
        #endregion

        #region public methods
        public IQueryable<AccountModel> GetPaidAccounts()
        {
            return (from account in dbModels.Accounts
                    join client in dbModels.Clients
                    on account.ClientId equals client.ClientId
                    join campaign in dbModels.AdvertisingCampaigns
                    on account.CampaignId equals campaign.CampaignId
                    join payment in dbModels.Payments
                    on account.AccountId equals payment.AccountId
                    select new
                    {
                        campaign.CampaignName,
                        ClientFullName = client.FirstName + " " + client.LastName,
                        Account = account.Account1,
                        Payment = payment.Payment1
                    } 
                    into x
                    group x by new
                    {
                        x.CampaignName,
                        x.ClientFullName,
                        x.Account
                    } 
                    into result
                    where result.Key.Account <= result.Sum(i => i.Payment)
                    select new AccountModel
                    {
                        CampaignName = result.Key.CampaignName,
                        ClientFullName = result.Key.ClientFullName,
                        Account = result.Key.Account
                    });
                    
        }
        #endregion
    }
}
