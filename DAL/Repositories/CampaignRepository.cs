using System.Linq;
using AgencyModels.Models;
using DBModels = AgencyModels.EntityModels.AdvAgenciesDBEntities;

namespace DAL.Repositories
{
    public class CampaignRepository
    {
        private DBModels agencyModels;

        #region Constructors
        public CampaignRepository()
        {
            agencyModels = new DBModels();
        }
        #endregion

        #region public methods for campaings
        public IQueryable<CampaignModel> GetCampaigns()
        {
            return (from campaign in agencyModels.AdvertisingCampaigns
                    join agency in agencyModels.Agencies
                    on campaign.AgencyId equals agency.AgencyId
                    select new CampaignModel
                    {
                        CampaignName = campaign.CampaignName,
                        Slogan = campaign.Slogan,
                        Characteristic = campaign.Characteristic,
                        StartDate = campaign.StartDate,
                        EndDate = campaign.EndDate,
                        AgencyName = agency.Name
                    });
        }

        public IQueryable<CampaignModel> GetCampaignsByName(string campaignName)
        {
            return this.GetCampaigns().Where(x => x.CampaignName.ToLower().Contains(campaignName.ToLower()));
        }

        public IQueryable<CampaignModel> GetCampaignsByAgencyName(string agencyName)
        {
            return this.GetCampaigns().Where(x => x.AgencyName.ToLower().Contains(agencyName.ToLower()));
        }

        public IQueryable<CampaignModel>  GetCampaignsWithCost()
        {
            return (from campaign in agencyModels.AdvertisingCampaigns
                    join agency in agencyModels.Agencies
                    on campaign.AgencyId equals agency.AgencyId
                    join account in agencyModels.Accounts
                    on campaign.CampaignId equals account.CampaignId
                    select new
                    {
                        campaign.CampaignName,
                        campaign.Slogan,
                        campaign.Characteristic,
                        campaign.StartDate,
                        campaign.EndDate,
                        Account = account.Account1,
                        AgencyName = agency.Name
                    } into result
                    group result by new
                    {
                        result.CampaignName,
                        result.Slogan,
                        result.Characteristic,
                        result.StartDate,
                        result.EndDate,
                        result.AgencyName,
                    } into x
                    select new CampaignModel
                    {
                        CampaignName = x.Key.CampaignName,
                        Slogan = x.Key.Slogan,
                        Characteristic = x.Key.Characteristic,
                        StartDate = x.Key.StartDate,
                        EndDate = x.Key.EndDate,
                        AgencyName = x.Key.AgencyName,
                        TotalCost = x.Sum(i => i.Account)
                    });                    
        }
        #endregion
    }
}
