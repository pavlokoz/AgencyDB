using System.Linq;
using DAL.Models;
using DBModels = AgencyModels.Models.AdvAgenciesDBEntities;

namespace DAL.Repositories
{
    public class ClientRepository
    {
        private DBModels dbModels;

        #region Constructors 
        public ClientRepository()
        {
            this.dbModels = new DBModels();
        }
        #endregion

        #region Execude methods for client
        public IQueryable<ClientModel> ExecuteClients()
        {
            return (from client in dbModels.Clients
                    select new ClientModel
                    {
                        FirstName = client.FirstName,
                        LastName = client.LastName
                    });
        }

        public IQueryable<ClientModel> ExecuteClientsForAgency(string agencyName)
        {
            return (from client in dbModels.Clients
                    join campaign in dbModels.AdvertisingCampaigns
                    on client.ClientId equals campaign.ClientId
                    join agency in dbModels.Agencies
                    on campaign.AgencyId equals agency.AgencyId
                    where agency.Name == agencyName
                    select new ClientModel
                    {
                        FirstName = client.FirstName,
                        LastName = client.LastName
                    });
        }

        public IQueryable<ClientModel> ExecuteClientsByName(string lastName)
        {
            return this.ExecuteClients().
                Where
                (
                    client => client.LastName.Contains(lastName)
                );
        }

        public IQueryable<ClientModel> ExecuteClientsByNameAndAgency(string lastName, string agencyName)
        {
            return this.ExecuteClientsForAgency(agencyName).
                Where
                (
                    client => client.LastName.Contains(lastName)
                );
        }

        public IQueryable<ClientModel> ExecuteDebtorClients()
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
                        client.FirstName,
                        client.LastName,
                        Account = account.Account1,
                        Payment = payment.Payment1
                    }
                    into x
                    group x by new
                    {
                        x.FirstName,
                        x.LastName,
                        x.Account
                    }
                    into result
                    where result.Key.Account > result.Sum(i => i.Payment)
                    select new ClientModel
                    {
                        FirstName = result.Key.FirstName,
                        LastName = result.Key.LastName
                    });
        }
        #endregion
    }
}
