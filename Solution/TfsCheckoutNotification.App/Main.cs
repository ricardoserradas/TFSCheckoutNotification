using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.Client;
using System.Diagnostics;

namespace TfsCheckoutNotification.App
{
    public partial class Main : Form
    {
        private bool VisualStudioWasOpened{
            get{
                return (bool)Properties.Settings.Default["VisualStudioWasOpened"];
            }
            set{
                Properties.Settings.Default["VisualStudioWasOpened"] = value;
                Properties.Settings.Default.Save();
            }
        }
        private bool VisualStudioWasClosed{
            get{
                return (bool)Properties.Settings.Default["VisualStudioWasClosed"];
            }
            set{
                Properties.Settings.Default["VisualStudioWasClosed"] = value;
                Properties.Settings.Default.Save();
            }
        }
        
        public Main()
        {
            InitializeComponent();

            QueryPendingChanges();

            ConfigureTimer();
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

            this.CheckVisualStudioOpened();
            this.CheckVisualStudioClosed();

            if (this.VisualStudioWasOpened && this.VisualStudioWasClosed && !timer_toast.Enabled)
            {
                timer_toast.Interval = 5000; // after visual studio closes with pending checkins, it notifies the user every 1 minutes.

                this.VisualStudioWasOpened = false;
                this.VisualStudioWasClosed = false;

                timer_toast.Start();
            }
            else if(this.VisualStudioWasOpened && !this.VisualStudioWasClosed && timer_toast.Enabled)
            {
                timer_toast.Stop();
            }

            timer_checkInterval.Start();
        }

        private void timer_toast_Tick(object sender, EventArgs e)
        {
            this.QueryPendingChanges();
        }

        private void QueryPendingChanges(bool showToastWhenZero = false)
        {
            var tpcUri = Properties.Settings.Default["CurrentCollection"].ToString();

            var tpc = new TfsTeamProjectCollection(new Uri(tpcUri));

            var vcs = tpc.GetService<VersionControlServer>();

            var workspaces = vcs.QueryWorkspaces(null, vcs.AuthorizedUser, Environment.MachineName);

            if (!workspaces.Any()) return;
            
            var totalPendingChanges = workspaces.Sum(workspace => workspace.GetPendingChanges().Count());

            if (totalPendingChanges > 0 || showToastWhenZero)
            {
                ShowToast(totalPendingChanges);
            }
        }

        private void ShowToast(int totalPendingChanges, string message = "")
        {
            this.notifyIcon.BalloonTipIcon = string.IsNullOrWhiteSpace(message) ? ToolTipIcon.Info : ToolTipIcon.Warning;
            this.notifyIcon.BalloonTipText = string.Format(string.IsNullOrWhiteSpace(message) ? "You have {0} pending change(s)" : message, totalPendingChanges == 0 ? "no" : totalPendingChanges.ToString(CultureInfo.InvariantCulture));
            this.notifyIcon.ShowBalloonTip(3);
        }

        public void ConfigureTimer()
        {
            timer_checkInterval.Stop();
            timer_toast.Stop();

            var collection = Properties.Settings.Default["CurrentCollection"].ToString();

            if (!string.IsNullOrWhiteSpace(collection))
            {
                var isIntervalMonitorType = (bool)Properties.Settings.Default["IsIntervalMonitorType"];

                if (isIntervalMonitorType)
                {
                    var intervalValue = (int)Properties.Settings.Default["IntervalValue"];
                    var intervalType = Properties.Settings.Default["IntervalType"].ToString();
                    int interval;

                    if (intervalType.Equals("minute"))
                    {
                        interval = intervalValue * 60000;
                    }
                    else
                    {
                        interval = intervalValue * 3600000;
                    }

                    timer_toast.Interval = interval;
                    timer_toast.Start();
                }
                else
                {
                    timer_checkInterval.Interval = 1000;
                    this.VisualStudioWasOpened = false;
                    this.VisualStudioWasClosed = false;
                    timer_checkInterval.Start();
                } 
            }
            else
            {
                this.ShowToast(0, "You must specify the collection to monitor.");
            }
        }

        private void CheckVisualStudioOpened()
        {
            var processes = Process.GetProcessesByName("devenv");

            if (!processes.Any()) return;
            
            this.VisualStudioWasOpened = true;
            this.VisualStudioWasClosed = false;
            timer_checkInterval.Interval = 1000;
        }

        private void CheckVisualStudioClosed()
        {
            if (!this.VisualStudioWasOpened) return;
            
            var processes = Process.GetProcessesByName("devenv");

            if (!processes.Any())
            {
                this.VisualStudioWasClosed = true;
            }
        }
    }
}
