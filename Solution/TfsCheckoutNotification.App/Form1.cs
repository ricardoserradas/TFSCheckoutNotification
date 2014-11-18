using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.Client;

namespace TfsCheckoutNotification.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            QueryPendingChanges(true);
        }

        private void menu_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menu_Configure_Click(object sender, EventArgs e)
        {
            var configuration = new Configuration();

            configuration.Show();
        }

        private void timer_checkInterval_Tick(object sender, EventArgs e)
        {
            timer_checkInterval.Stop();

            QueryPendingChanges();

            timer_checkInterval.Start();
        }

        private void QueryPendingChanges(bool showToastWhenZero = false)
        {
            var tpcUri = Properties.Settings.Default["CurrentCollection"].ToString();

            var tpc = new TfsTeamProjectCollection(new Uri(tpcUri));

            var vcs = tpc.GetService<VersionControlServer>();

            var workspaces = vcs.QueryWorkspaces(null, vcs.AuthorizedUser.ToString(), Environment.MachineName);

            if (workspaces.Count() > 0)
            {
                var totalPendingChanges = 0;

                foreach (Workspace workspace in workspaces)
                {
                    totalPendingChanges += workspace.GetPendingChanges().Count();
                }

                if (totalPendingChanges > 0 || showToastWhenZero)
                {
                    ShowToast(totalPendingChanges);
                }
            }
        }

        private void ShowToast(int totalPendingChanges)
        {
            this.notifyIcon.BalloonTipText = string.Format("You have {0} pending change(s)", totalPendingChanges == 0 ? "no" : totalPendingChanges.ToString());
            this.notifyIcon.ShowBalloonTip(3);
        }
    }
}
