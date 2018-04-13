namespace AgencyDB
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataViewer = new System.Windows.Forms.DataGridView();
            this.ExecuteCampaignTotalCost = new System.Windows.Forms.Button();
            this.DebtorClientsExecute = new System.Windows.Forms.Button();
            this.ExecutePaidAccount = new System.Windows.Forms.Button();
            this.ExecuteCampaign = new System.Windows.Forms.Button();
            this.ExecuteClients = new System.Windows.Forms.Button();
            this.ExecuteAgencies = new System.Windows.Forms.Button();
            this.AgencyFilter = new System.Windows.Forms.TextBox();
            this.ClientFilter = new System.Windows.Forms.TextBox();
            this.CampaignFilter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // DataViewer
            // 
            this.DataViewer.AllowUserToAddRows = false;
            this.DataViewer.AllowUserToDeleteRows = false;
            this.DataViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataViewer.Location = new System.Drawing.Point(13, 13);
            this.DataViewer.Name = "DataViewer";
            this.DataViewer.ReadOnly = true;
            this.DataViewer.RowHeadersVisible = false;
            this.DataViewer.Size = new System.Drawing.Size(657, 425);
            this.DataViewer.TabIndex = 0;
            // 
            // ExecuteCampaignTotalCost
            // 
            this.ExecuteCampaignTotalCost.Location = new System.Drawing.Point(676, 414);
            this.ExecuteCampaignTotalCost.Name = "ExecuteCampaignTotalCost";
            this.ExecuteCampaignTotalCost.Size = new System.Drawing.Size(129, 24);
            this.ExecuteCampaignTotalCost.TabIndex = 1;
            this.ExecuteCampaignTotalCost.Text = "Campaign Total Cost";
            this.ExecuteCampaignTotalCost.UseVisualStyleBackColor = true;
            this.ExecuteCampaignTotalCost.Click += new System.EventHandler(this.ExecuteCampaignTotalCost_Click);
            // 
            // DebtorClientsExecute
            // 
            this.DebtorClientsExecute.Location = new System.Drawing.Point(677, 385);
            this.DebtorClientsExecute.Name = "DebtorClientsExecute";
            this.DebtorClientsExecute.Size = new System.Drawing.Size(128, 23);
            this.DebtorClientsExecute.TabIndex = 2;
            this.DebtorClientsExecute.Text = "Debtor Clients";
            this.DebtorClientsExecute.UseVisualStyleBackColor = true;
            this.DebtorClientsExecute.Click += new System.EventHandler(this.DebtorClientsExecute_Click);
            // 
            // ExecutePaidAccount
            // 
            this.ExecutePaidAccount.Location = new System.Drawing.Point(677, 356);
            this.ExecutePaidAccount.Name = "ExecutePaidAccount";
            this.ExecutePaidAccount.Size = new System.Drawing.Size(128, 23);
            this.ExecutePaidAccount.TabIndex = 3;
            this.ExecutePaidAccount.Text = "Paid Account";
            this.ExecutePaidAccount.UseVisualStyleBackColor = true;
            this.ExecutePaidAccount.Click += new System.EventHandler(this.ExecutePaidAccount_Click);
            // 
            // ExecuteCampaign
            // 
            this.ExecuteCampaign.Location = new System.Drawing.Point(677, 327);
            this.ExecuteCampaign.Name = "ExecuteCampaign";
            this.ExecuteCampaign.Size = new System.Drawing.Size(128, 23);
            this.ExecuteCampaign.TabIndex = 4;
            this.ExecuteCampaign.Text = "Campaign";
            this.ExecuteCampaign.UseVisualStyleBackColor = true;
            this.ExecuteCampaign.Click += new System.EventHandler(this.ExecuteCampaign_Click);
            // 
            // ExecuteClients
            // 
            this.ExecuteClients.Location = new System.Drawing.Point(677, 298);
            this.ExecuteClients.Name = "ExecuteClients";
            this.ExecuteClients.Size = new System.Drawing.Size(128, 23);
            this.ExecuteClients.TabIndex = 5;
            this.ExecuteClients.Text = "Clients";
            this.ExecuteClients.UseVisualStyleBackColor = true;
            this.ExecuteClients.Click += new System.EventHandler(this.ExecuteClients_Click);
            // 
            // ExecuteAgencies
            // 
            this.ExecuteAgencies.Location = new System.Drawing.Point(677, 269);
            this.ExecuteAgencies.Name = "ExecuteAgencies";
            this.ExecuteAgencies.Size = new System.Drawing.Size(128, 23);
            this.ExecuteAgencies.TabIndex = 6;
            this.ExecuteAgencies.Text = "Agencies";
            this.ExecuteAgencies.UseVisualStyleBackColor = true;
            this.ExecuteAgencies.Click += new System.EventHandler(this.ExecuteAgencies_Click);
            // 
            // AgencyFilter
            // 
            this.AgencyFilter.Location = new System.Drawing.Point(677, 243);
            this.AgencyFilter.Name = "AgencyFilter";
            this.AgencyFilter.Size = new System.Drawing.Size(128, 20);
            this.AgencyFilter.TabIndex = 7;
            this.AgencyFilter.Leave += new System.EventHandler(this.AgencyFilter_Leave);
            // 
            // ClientFilter
            // 
            this.ClientFilter.Location = new System.Drawing.Point(677, 243);
            this.ClientFilter.Name = "ClientFilter";
            this.ClientFilter.Size = new System.Drawing.Size(128, 20);
            this.ClientFilter.TabIndex = 8;
            this.ClientFilter.Leave += new System.EventHandler(this.ClientFilter_Leave);
            // 
            // CampaignFilter
            // 
            this.CampaignFilter.Location = new System.Drawing.Point(676, 243);
            this.CampaignFilter.Name = "CampaignFilter";
            this.CampaignFilter.Size = new System.Drawing.Size(129, 20);
            this.CampaignFilter.TabIndex = 9;
            this.CampaignFilter.Leave += new System.EventHandler(this.CampaignFilter_Leave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 450);
            this.Controls.Add(this.CampaignFilter);
            this.Controls.Add(this.ClientFilter);
            this.Controls.Add(this.AgencyFilter);
            this.Controls.Add(this.ExecuteAgencies);
            this.Controls.Add(this.ExecuteClients);
            this.Controls.Add(this.ExecuteCampaign);
            this.Controls.Add(this.ExecutePaidAccount);
            this.Controls.Add(this.DebtorClientsExecute);
            this.Controls.Add(this.ExecuteCampaignTotalCost);
            this.Controls.Add(this.DataViewer);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DataViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataViewer;
        private System.Windows.Forms.Button ExecuteCampaignTotalCost;
        private System.Windows.Forms.Button DebtorClientsExecute;
        private System.Windows.Forms.Button ExecutePaidAccount;
        private System.Windows.Forms.Button ExecuteCampaign;
        private System.Windows.Forms.Button ExecuteClients;
        private System.Windows.Forms.Button ExecuteAgencies;
        private System.Windows.Forms.TextBox AgencyFilter;
        private System.Windows.Forms.TextBox ClientFilter;
        private System.Windows.Forms.TextBox CampaignFilter;
    }
}

