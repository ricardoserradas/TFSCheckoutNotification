﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.Client;
using System.Diagnostics;
using model = TfsCheckoutNotification.Model;

namespace TfsCheckoutNotification.App
{
    public partial class Main : Form
    {
        private static bool VisualStudioWasOpened
        {
            get
            {
                return (bool)Properties.Settings.Default["VisualStudioWasOpened"];
            }
            set
            {
                Properties.Settings.Default["VisualStudioWasOpened"] = value;
                Properties.Settings.Default.Save();
            }
        }
        private static bool VisualStudioWasClosed
        {
            get
            {
                return (bool)Properties.Settings.Default["VisualStudioWasClosed"];
            }
            set
            {
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
            try
            {
#if DEBUG
                Thread.CurrentThread.CurrentUICulture = MessageBox.Show("Choose Yes for pt-BR or No for en-US", "Choose Language", MessageBoxButtons.YesNo) ==
                                                        DialogResult.Yes ? new CultureInfo("pt-BR") : new CultureInfo("en-US");
#endif


                this._pendingChanges = new List<model.PendingChange>();

                InitializeComponent();

                QueryPendingChanges();

                ConfigureTimer();
            }
            catch (Exception exception)
            {
                Common.TreatUnexpectedException(exception, this);
            }
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
            try
            {
                timer_checkInterval.Stop();

                this.CheckVisualStudioOpened();
                this.CheckVisualStudioClosed();

                if (VisualStudioWasOpened && VisualStudioWasClosed && !timer_toast.Enabled)
                {
                    timer_toast.Interval = 5000; // after visual studio closes with pending checkins, it notifies the user every 1 minutes.

                    VisualStudioWasOpened = false;
                    VisualStudioWasClosed = false;

                    timer_toast.Start();
                }
                else if (VisualStudioWasOpened && !VisualStudioWasClosed && timer_toast.Enabled)
                {
                    timer_toast.Stop();
                }

                timer_checkInterval.Start();
            }
            catch (Exception exception)
            {
                Common.TreatUnexpectedException(exception, this);
            }
        }

        private void timer_toast_Tick(object sender, EventArgs e)
        {
            this.QueryPendingChanges();
        }

        public VersionControlServer GetVersionControlServer()
        {
            var tpcUri = Properties.Settings.Default["CurrentCollection"].ToString();

            if (string.IsNullOrWhiteSpace(tpcUri))
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(tpcUri)) return null;

            var tpc = new TfsTeamProjectCollection(new Uri(tpcUri));

            var vcs = tpc.GetService<VersionControlServer>();

            return vcs;
        }

        public void QueryPendingChanges(bool showToastWhenZero = false)
        {
            this._pendingChanges.Clear();

            try
            {
                var vcs = this.GetVersionControlServer();

                if (vcs == null)
                {
                    return;
                }

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
            catch (Exception exception)
            {
                EventLog.WriteEntry(Common.EventLogSource, exception.Message, EventLogEntryType.Error);
                this.ShowToast(0, Common.ResourceManager.GetString("Main_ErrorConnectTFS"));
            }
        }

        private IEnumerable<model.PendingChange> ConvertPendingChangeToViewModel(IEnumerable<PendingChange> pendingChanges)
        {
            return pendingChanges.Select(pendingChange => new model.PendingChange
            {
                ServerPath = pendingChange.ServerItem
            });
        }

        private void ShowToast(int totalPendingChanges, string message = "", bool showConfiguration = false)
        {
            var pendingChangesWindow = (PendingChangesWindow)Application.OpenForms["PendingChangesWindow"];

            if (pendingChangesWindow != null) return;

            this.notifyIcon.Tag = showConfiguration;

            this.notifyIcon.BalloonTipIcon = string.IsNullOrWhiteSpace(message) ? ToolTipIcon.Info : ToolTipIcon.Warning;

            if (string.IsNullOrWhiteSpace(message))
            {
                this.notifyIcon.BalloonTipText = totalPendingChanges == 0
                ? Common.ResourceManager.GetString("Main_NoPendingChanges")
                : string.Format(Common.ResourceManager.GetString("Main_CountPendingChanges"), totalPendingChanges);
            }
            else
            {
                this.notifyIcon.BalloonTipText = message;
            }
            
            this.notifyIcon.ShowBalloonTip(3);
        }

        public void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            var balloon = (NotifyIcon) sender;

            if (bool.Parse(balloon.Tag.ToString()))
            {
                this.ShowConfigurationWindow();
            }
            else
            {
                this.ShowPendingChangesWindow();
            }
        }

        private void ShowConfigurationWindow()
        {
            try
            {
                var configurationWindow = (Configuration)Application.OpenForms["Configuration"];

                if (configurationWindow == null)
                {
                    var pendinChangesWindow = new Configuration();
                    pendinChangesWindow.Show();
                }
                else
                {
                    configurationWindow.Focus();
                }
            }
            catch (Exception exception)
            {
                Common.TreatUnexpectedException(exception, this);
            }
        }

        private void ShowPendingChangesWindow()
        {
            try
            {
                var pendingChangesWindow = (PendingChangesWindow)Application.OpenForms["PendingChangesWindow"];

                if (pendingChangesWindow == null)
                {
                    var pendinChangesWindow = new PendingChangesWindow();
                    pendinChangesWindow.Show();
                }
                else
                {
                    pendingChangesWindow.Focus();
                }
            }
            catch (Exception exception)
            {
                Common.TreatUnexpectedException(exception, this);
            }
        }

        public void ConfigureTimer()
        {
            try
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
                        VisualStudioWasOpened = false;
                        VisualStudioWasClosed = false;
                        timer_checkInterval.Start();
                    }
                }
                else
                {
                    this.ShowToast(0, Common.ResourceManager.GetString("Main_SpecifyCollection"), true);
                }
            }
            catch (Exception exception)
            {
                Common.TreatUnexpectedException(exception, this);
            }
        }

        private void CheckVisualStudioOpened()
        {
            try
            {
                var processes = Process.GetProcessesByName("devenv");

                if (!processes.Any()) return;

                VisualStudioWasOpened = true;
                VisualStudioWasClosed = false;
                timer_checkInterval.Interval = 1000;
            }
            catch (Exception exception)
            {
                Common.TreatUnexpectedException(exception, this);
            }
        }

        private void CheckVisualStudioClosed()
        {
            try
            {
                if (!VisualStudioWasOpened) return;

                var processes = Process.GetProcessesByName("devenv");

                if (!processes.Any())
                {
                    VisualStudioWasClosed = true;
                }
            }
            catch (Exception exception)
            {
                Common.TreatUnexpectedException(exception, this);
            }
        }

        private void menu_showPendingChanges_Click(object sender, EventArgs e)
        {
            this.ShowPendingChangesWindow();
        }
    }
}
