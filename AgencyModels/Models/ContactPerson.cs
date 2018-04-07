namespace AgencyModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContactPerson")]
    public partial class ContactPerson
    {
        [Key]
        [Column(Order = 0)]
        public string EMail { get; set; }

        [Key]
        [Column(Order = 1)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 2)]
        public string LastName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long PersonId { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AgencyId { get; set; }

        public virtual Agency Agency { get; set; }
    }
}
