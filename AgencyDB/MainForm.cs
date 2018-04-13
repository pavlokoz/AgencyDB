using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ADONetDAL.Repositories;
//using DAL.Repositories;

namespace AgencyDB
{
    public partial class MainForm : Form
    {
        #region models of repositories
        private AgencyRepository agency;
        private ClientRepository client;
        private AccountRepository account;
        private CampaignRepository campaign;
        #endregion

        public MainForm()
        {
            InitializeComponent();
            this.UnVisibleAllTextBoxes();
            this.agency = new AgencyRepository();
            this.client = new ClientRepository();
            this.account = new AccountRepository();
            this.campaign = new CampaignRepository();
        }

        private void UnVisibleAllTextBoxes()
        {
            this.AgencyFilter.Text = string.Empty;
            this.ClientFilter.Text = string.Empty;
            this.CampaignFilter.Text = string.Empty;
            this.AgencyFilter.Visible = false;
            this.ClientFilter.Visible = false;
            this.CampaignFilter.Visible = false;
        }

        #region Button Click Events
        private void ExecuteCampaignTotalCost_Click(object sender, EventArgs e)
        {           
            this.DataViewer.DataSource = this.campaign.GetCampaignsWithCost().ToList();
            this.DataViewer.Columns["TotalCost"].Visible = true ;
            this.UnVisibleAllTextBoxes();
        }

        private void DebtorClientsExecute_Click(object sender, EventArgs e)
        {
            this.DataViewer.DataSource = this.client.GetDebtorClients().ToList();
            this.UnVisibleAllTextBoxes();
        }

        private void ExecutePaidAccount_Click(object sender, EventArgs e)
        {
            this.DataViewer.DataSource = this.account.GetPaidAccounts().ToList();
            this.UnVisibleAllTextBoxes();
        }

        private void ExecuteCampaign_Click(object sender, EventArgs e)
        {
            this.DataViewer.DataSource = this.campaign.GetCampaigns().ToList();
            this.DataViewer.Columns["TotalCost"].Visible = false;
            this.UnVisibleAllTextBoxes();
            this.CampaignFilter.Visible = true;
        }

        private void ExecuteClients_Click(object sender, EventArgs e)
        {
            this.DataViewer.DataSource = this.client.GetClients().ToList();
            this.UnVisibleAllTextBoxes();
            this.ClientFilter.Visible = true;
        }

        private void ExecuteAgencies_Click(object sender, EventArgs e)
        {
            this.DataViewer.DataSource = this.agency.GetAgencies().ToList();
            this.UnVisibleAllTextBoxes();
            this.AgencyFilter.Visible = true;
        }
        #endregion

        #region Filters Leave Events
        private void AgencyFilter_Leave(object sender, EventArgs e)
        {
            this.DataViewer.DataSource = (string.IsNullOrWhiteSpace(this.AgencyFilter.Text) ?
                this.agency.GetAgencies() :
                this.agency.GetAgenciesByName(this.AgencyFilter.Text)
                ).
                ToList();
        }

        private void CampaignFilter_Leave(object sender, EventArgs e)
        {
            this.DataViewer.DataSource = (string.IsNullOrWhiteSpace(this.CampaignFilter.Text) ?
                this.campaign.GetCampaigns() :
                this.campaign.GetCampaignsByAgencyName(this.CampaignFilter.Text)
                ).
                ToList();
        }

        private void ClientFilter_Leave(object sender, EventArgs e)
        {
            this.DataViewer.DataSource = (string.IsNullOrWhiteSpace(this.ClientFilter.Text) ?
                this.client.GetClients() :
                this.client.GetClientsByName(this.ClientFilter.Text)
                ).
                ToList();
        }
        #endregion
    }
}
