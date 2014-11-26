using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.Client;
using System.Diagnostics;
using model = TfsCheckoutNotification.Model;

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

        private readonly List<model.PendingChange> _pendingChanges;

        public List<model.PendingChange> PendingChanges
        {
            get { return this._pendingChanges; }
        }
        
        public Main()
        {
            this._pendingChanges = new List<model.PendingChange>();

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
            this._pendingChanges.Clear();
            
            var tpcUri = Properties.Settings.Default["CurrentCollection"].ToString();

            if (!string.IsNullOrWhiteSpace(tpcUri))
            {
                try
                {
                    var tpc = new TfsTeamProjectCollection(new Uri(tpcUri));

                    var vcs = tpc.GetService<VersionControlServer>();

                    var workspaces = vcs.QueryWorkspaces(null, vcs.AuthorizedUser, Environment.MachineName);

                    if (!workspaces.Any()) return;

                    foreach (var workspace in workspaces)
                    {
                        this._pendingChanges.AddRange(this.ConvertPendingChangeToViewModel(workspace.GetPendingChanges()));
                    }

                    if (this.PendingChanges.Count > 0 || showToastWhenZero)
                    {
                        ShowToast(this.PendingChanges.Count);
                    }
                }
                catch (Exception ex)
                {
                    ShowToast(0, "There was an error connecting to your Team Foundation Service. Check your connection.");
                }
            }
            else
            {
                this.ShowToast(0, "You must specify the collection to monitor.");
            }
        }

        private IEnumerable<model.PendingChange> ConvertPendingChangeToViewModel(IEnumerable<PendingChange> pendingChanges)
        {
            return pendingChanges.Select(pendingChange => new model.PendingChange
            {
                ServerPath = pendingChange.ServerItem
            });
        }

        private void ShowToast(int totalPendingChanges, string message = "")
        {
            var pendingChangesWindow = (PendingChangesWindow) Application.OpenForms["PendingChangesWindow"];

            if (pendingChangesWindow != null) return;

            this.notifyIcon.BalloonTipIcon = string.IsNullOrWhiteSpace(message) ? ToolTipIcon.Info : ToolTipIcon.Warning;
            this.notifyIcon.BalloonTipText = string.Format(string.IsNullOrWhiteSpace(message) ? "You have {0} pending change(s)" : message, totalPendingChanges == 0 ? "no" : totalPendingChanges.ToString(CultureInfo.InvariantCulture));
            this.notifyIcon.ShowBalloonTip(3);
        }

        public void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            var pendinChangesWindow = new PendingChangesWindow();
            pendinChangesWindow.Show();
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
                    timer_checkInterval.Interval = 600000; // If the user has pending changes and closes visual studio, he will be notified every 10 minutes.
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
