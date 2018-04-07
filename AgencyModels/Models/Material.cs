namespace AgencyModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Material
    {
        [Required]
        public string FilePath { get; set; }

        public int TypeId { get; set; }

        [Key]
        public long FileId { get; set; }

        public long? AdvertisementId { get; set; }

        public virtual Advertisement Advertisement { get; set; }

        public virtual Type Type { get; set; }
    }
}
