using System.Linq;
using DAL.Models;
using DBModels = AgencyModels.Models.AdvAgenciesDBEntities;

namespace DAL.Repositories
{
    public class CampaignRepository
    {
        private DBModels agencyModels;

        public CampaignRepository()
        {
            agencyModels = new DBModels();
        }

        #region 
        public IQueryable<CampaignModel> GetCampaignModels()
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

        public IQueryable<CampaignModel> GetCampaignModelsByName(string campaignName)
        {
            return this.GetCampaignModels().Where(x => x.CampaignName.ToLower().Contains(campaignName.ToLower()));
        }

        public IQueryable<CampaignModel> GetCampaignModelsByAgencyName(string agencyName)
        {
            return this.GetCampaignModels().Where(x => x.AgencyName.ToLower().Contains(agencyName.ToLower()));
        }

        public IQueryable<CampaignModel>  GetCampaignModelsWithCost()
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
