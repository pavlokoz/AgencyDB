namespace AgencyModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ClientId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CampaignId { get; set; }

        [Key]
        [Column("Payment", Order = 2)]
        public decimal Payment1 { get; set; }

        public virtual AdvertisingCampaign AdvertisingCampaign { get; set; }

        public virtual Client Client { get; set; }
    }
}
