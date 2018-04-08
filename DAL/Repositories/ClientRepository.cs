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

        public IQueryable <ClientModel> ExecuteClientsForAgency(string agencyName)
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
        #endregion

    }
}
