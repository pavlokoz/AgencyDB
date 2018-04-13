using System.Linq;
using AgencyModels.Models;
using DBModels = AgencyModels.EntityModels.AdvAgenciesDBEntities;

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

        #region public methods for agency
        public IQueryable<AgencyModel> GetAgencies()
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

        public IQueryable<AgencyModel> GetAgenciesInCity(string city)
        {
            var result = GetAgencies();
            return result.Where(x => x.City == city);
                    
        }

        public IQueryable<AgencyModel> GetAgenciesByName(string name)
        {
            var result = GetAgencies();
            return result.Where(x => x.Name.Contains(name));
        }
        #endregion
    }
}
