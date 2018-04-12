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
        private AccountRepository account;
        private CampaignRepository campaign;
        public MainForm()
        {
            InitializeComponent();
            agency = new AgencyRepository();
            client = new ClientRepository();
            account = new AccountRepository();
            campaign = new CampaignRepository();
        }

        private void ExecuteCampaignTotalCost_Click(object sender, EventArgs e)
        {
            DataViewer.DataSource = campaign.GetCampaignModelsWithCost().ToList();
        }

        private void DebtorClientsExecute_Click(object sender, EventArgs e)
        {
            DataViewer.DataSource = client.ExecuteDebtorClients().ToList();
        }

        private void ExecutePaidAccount_Click(object sender, EventArgs e)
        {
            DataViewer.DataSource = account.GetPaidAccounts().ToList();
        }

        private void ExecuteCampaign_Click(object sender, EventArgs e)
        {
            DataViewer.DataSource = campaign.GetCampaignModels().ToList();
            DataViewer.Columns["TotalCost"].Visible = false;
        }

        private void ExecuteClients_Click(object sender, EventArgs e)
        {
            DataViewer.DataSource = client.ExecuteClients().ToList();
        }

        private void ExecuteAgencies_Click(object sender, EventArgs e)
        {
            DataViewer.DataSource = agency.ExecuteAgencies().ToList();
        }
    }
}
