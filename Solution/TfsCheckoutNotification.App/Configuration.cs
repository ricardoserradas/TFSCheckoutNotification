using Microsoft.TeamFoundation.Client;
using System;
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
                cmbIntervalType.SelectedItem = Get_UniversalIntervalType(Properties.Settings.Default["IntervalType"].ToString());
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
            grpIntervalConfiguration.Enabled = rdMonitorInterval.Checked;
        }

        private void SaveConfiguration()
        {
            Properties.Settings.Default["CurrentCollection"] = txtCollection.Text;
            Properties.Settings.Default["IsIntervalMonitorType"] = rdMonitorInterval.Checked;
            if (rdMonitorInterval.Checked)
            {
                Properties.Settings.Default["IntervalValue"] = int.Parse(txtIntervalValue.Text);
                Properties.Settings.Default["IntervalType"] = Get_DefaultIntervalType(cmbIntervalType.SelectedItem.ToString()); 
            }
            Properties.Settings.Default.Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCollection.Text))
            {
                MessageBox.Show(Main.ResourceManager.GetString("Main_SpecifyCollection"), Main.ResourceManager.GetString("Main_ErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnChangeCollection.Focus();

                return;
            }

            if (rdMonitorInterval.Checked)
            {
                int tryResult;
                
                if (string.IsNullOrWhiteSpace(txtIntervalValue.Text))
                {
                    MessageBox.Show(Main.ResourceManager.GetString("Configuration_SetInterval"), Main.ResourceManager.GetString("Main_ErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIntervalValue.Focus();
                    return;
                }
                
                if (!int.TryParse(txtIntervalValue.Text, out tryResult))
                {
                    MessageBox.Show(Main.ResourceManager.GetString("Configuration_IntervalInteger"), Main.ResourceManager.GetString("Main_ErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIntervalValue.Text = string.Empty;
                    txtIntervalValue.Focus();
                    return;
                }
                
                if (cmbIntervalType.SelectedItem == null)
                {
                    MessageBox.Show(Main.ResourceManager.GetString("Configuration_IntervalType"), Main.ResourceManager.GetString("Main_ErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbIntervalType.Focus();
                    return;
                }
            }
            
            this.SaveConfiguration();

            var actualForm = (Main)Application.OpenForms["Main"];

            if (actualForm != null) actualForm.ConfigureTimer();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string Get_DefaultIntervalType(string intervalInput)
        {
            if (intervalInput.Equals("hora(s)") || intervalInput.Equals("hour"))
            {
                return "hour";
            }

            if (intervalInput.Equals("minuto(s)") | intervalInput.Equals("minute"))
            {
                return "minute";
            }

            return null;
        }
        private string Get_UniversalIntervalType(string intervalInput)
        {
            if (intervalInput.Equals("hour"))
            {
                return Main.ResourceManager.GetString("Configuration_IntervalHour");
            }

            if (intervalInput.Equals("minute"))
            {
                return Main.ResourceManager.GetString("Configuration_IntervalMinute");
            }

            return null;
        }
    }
}
