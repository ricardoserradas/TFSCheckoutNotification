using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Proxy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TfsCheckoutNotification.App
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();

            txtCollection.Text = Properties.Settings.Default["CurrentCollection"].ToString();
        }

        private void btnChangeCollection_Click(object sender, EventArgs e)
        {
            var tpcPicker = new TeamProjectPicker(TeamProjectPickerMode.NoProject, false);

            var dialogResult = tpcPicker.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                txtCollection.Text = tpcPicker.SelectedTeamProjectCollection.Uri.ToString();
                Properties.Settings.Default["CurrentCollection"] = txtCollection.Text;
                Properties.Settings.Default.Save();
            }
        }
    }
}
