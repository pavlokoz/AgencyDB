using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgencyModels.Models;
using DAL.Models;

namespace DAL.Repositories
{
    public class AgencyRepository
    {
        private AgencyModel agencyModels;

        #region Constructors 
        public AgencyRepository()
        {
            this.agencyModels = new AgencyModel();
        }
        #endregion

        #region Execude methods for agency
        public IQueryable<ModelAgency> ExecudeAgencies()
        {
            return (from agency in agencyModels.Agencies
                    join city in agencyModels.Cities
                    on agency.CityId equals city.CityId
                    select new ModelAgency
                    {
                        Name = agency.Name,
                        City = city.CityName,
                        Address = agency.Street + agency.HouseNumber
                    });
        }        

        public IQueryable<ModelAgency> ExecudeAgenciesInCity(string city)
        {
            var result = ExecudeAgencies();
            return result.Where(x => x.City == city);
                    
        }
        #endregion
    }
}
