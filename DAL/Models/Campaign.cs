namespace DAL.Models
{
    using System;

    public class CampaignModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CampaignName { get; set; }
        public string Slogan { get; set; }
        public string Characteristic { get; set; }
    }
}
