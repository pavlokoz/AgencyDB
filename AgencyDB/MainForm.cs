using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Repositories;
using DAL.Models;

namespace AgencyDB
{
    public partial class MainForm : Form
    {
        private AgencyRepository agency;

        public MainForm()
        {
            InitializeComponent();
            agency = new AgencyRepository();
        }

        private void Execude_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = agency.ExecudeAgenciesInCity("Lviv").ToList();
        }
    }
}
