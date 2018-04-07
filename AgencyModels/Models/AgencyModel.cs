namespace AgencyModels.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AgencyModel : DbContext
    {
        public AgencyModel()
            : base("name=AgencyModel")
        {
        }

        public virtual DbSet<Advertisement> Advertisements { get; set; }
        public virtual DbSet<AdvertisingCampaign> AdvertisingCampaigns { get; set; }
        public virtual DbSet<Agency> Agencies { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<DisplayDate> DisplayDates { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<ContactPerson> ContactPersons { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advertisement>()
                .HasMany(e => e.DisplayDates)
                .WithMany(e => e.Advertisements)
                .Map(m => m.ToTable("AdvertisementDisplayDate").MapLeftKey("AdvertisementId").MapRightKey("DateId"));

            modelBuilder.Entity<AdvertisingCampaign>()
                .HasMany(e => e.Advertisements)
                .WithRequired(e => e.AdvertisingCampaign)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AdvertisingCampaign>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.AdvertisingCampaign)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AdvertisingCampaign>()
                .HasMany(e => e.Payments)
                .WithRequired(e => e.AdvertisingCampaign)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Agency>()
                .HasMany(e => e.AdvertisingCampaigns)
                .WithRequired(e => e.Agency)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Agency>()
                .HasMany(e => e.ContactPersons)
                .WithRequired(e => e.Agency)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Agencies)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.AdvertisingCampaigns)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Payments)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Materials)
                .WithRequired(e => e.Type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Account1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ContactPerson>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Payment1)
                .HasPrecision(18, 0);
        }
    }
}
