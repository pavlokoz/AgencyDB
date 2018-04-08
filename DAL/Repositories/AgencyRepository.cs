using System.Linq;
using DAL.Models;
using DBModels = AgencyModels.Models.AdvAgenciesDBEntities;

namespace DAL.Repositories
{
    public class AgencyRepository
    {
        private DBModels agencyModels;

        #region Constructors 
        public AgencyRepository()
        {
            this.agencyModels = new DBModels();
        }
        #endregion

        #region Execude methods for agency
        public IQueryable<AgencyModel> ExecuteAgencies()
        {
            return (from agency in agencyModels.Agencies
                    join city in agencyModels.Cities
                    on agency.CityId equals city.CityId
                    select new AgencyModel
                    {
                        Name = agency.Name,
                        City = city.CityName,
                        Address = agency.Street + agency.HouseNumber
                    });
        }        

        public IQueryable<AgencyModel> ExecuteAgenciesInCity(string city)
        {
            var result = ExecuteAgencies();
            return result.Where(x => x.City == city);
                    
        }
        #endregion
    }
}
