using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DAL.Repositories;

namespace AgencyDB
{
    public partial class MainForm : Form
    {
        private AgencyRepository agency;
        private ClientRepository client;

        public MainForm()
        {
            InitializeComponent();
            agency = new AgencyRepository();
            client = new ClientRepository();
        }

        private void Execude_Click(object sender, EventArgs e)
        {
            var agencyResult = agency.ExecuteAgenciesInCity("Lviv").ToList();
            var clientAgencyNameResult = client.ExecuteClientsByNameAndAgency("Shos", "Lviv");
            var clientLastNameResult = client.ExecuteClientsByName("Shos");
        }
    }
}
