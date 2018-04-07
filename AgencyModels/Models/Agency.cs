namespace AgencyModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Agency")]
    public partial class Agency
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agency()
        {
            AdvertisingCampaigns = new HashSet<AdvertisingCampaign>();
            ContactPersons = new HashSet<ContactPerson>();
        }

        public string Name { get; set; }

        public long AgencyId { get; set; }

        [Required]
        public string Street { get; set; }

        public int HouseNumber { get; set; }

        public long CityId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdvertisingCampaign> AdvertisingCampaigns { get; set; }

        public virtual City City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContactPerson> ContactPersons { get; set; }
    }
}
