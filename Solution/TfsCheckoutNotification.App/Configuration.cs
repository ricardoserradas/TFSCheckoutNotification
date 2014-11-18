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

            var isIntervalMonitorType = (bool)Properties.Settings.Default["IsIntervalMonitorType"];

            if (isIntervalMonitorType)
            {
                rdMonitorInterval.Checked = true;
                txtIntervalValue.Text = Properties.Settings.Default["IntervalValue"].ToString();
                cmbIntervalType.SelectedItem = Properties.Settings.Default["IntervalType"].ToString();
            }
            else
            {
                rdMonitorVisualStudio.Checked = true;
                grpIntervalConfiguration.Enabled = false;
            }
        }

        private void btnChangeCollection_Click(object sender, EventArgs e)
        {
            var tpcPicker = new TeamProjectPicker(TeamProjectPickerMode.NoProject, false);

            var dialogResult = tpcPicker.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                txtCollection.Text = tpcPicker.SelectedTeamProjectCollection.Uri.ToString();
                
            }
        }

        private void rdMonitorType_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMonitorInterval.Checked)
            {
                grpIntervalConfiguration.Enabled = true;
            }
            else
            {
                grpIntervalConfiguration.Enabled = false;
            }
        }

        private void SaveConfiguration()
        {
            Properties.Settings.Default["CurrentCollection"] = txtCollection.Text;
            Properties.Settings.Default["IsIntervalMonitorType"] = rdMonitorInterval.Checked;
            if (rdMonitorInterval.Checked)
            {
                Properties.Settings.Default["IntervalValue"] = txtIntervalValue.Text;
                Properties.Settings.Default["IntervalType"] = cmbIntervalType.SelectedItem.ToString(); 
            }
            Properties.Settings.Default.Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCollection.Text))
            {
                MessageBox.Show("You must specify the collection to monitor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnChangeCollection.Focus();

                return;
            }

            if (rdMonitorInterval.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtIntervalValue.Text))
                {
                    txtIntervalValue.Focus();
                    return;
                }
                else if (cmbIntervalType.SelectedItem == null)
                {
                    cmbIntervalType.Focus();
                    return;
                }
            }
            
            this.SaveConfiguration();

            var actualForm = (Form1)Application.OpenForms["Form1"];

            actualForm.ConfigureTimer();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
