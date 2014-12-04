using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.TeamFoundation.VersionControl.Client;

namespace TfsCheckoutNotification.App
{
    public partial class PendingChangesWindow : Form
    {
        private readonly Main _mainForm;
        
        public PendingChangesWindow()
        {
            InitializeComponent();

            this._mainForm = (Main)Application.OpenForms["Main"];

            if (this._mainForm == null)
            {
                MessageBox.Show("There was an error loading the app information. Closing...");
                this.Close();
            }

            PopulatePendingChangesList();
        }

        private void PopulatePendingChangesList()
        {
            lstPendingChanges.Items.Clear();

            lstPendingChanges.Items.Add("(Select  All)");

            foreach (var pendingChange in this._mainForm.PendingChanges)
            {
                lstPendingChanges.Items.Add(pendingChange.ServerPath);
            }

            lblPendingChanges.Text = string.Format("All your {0} pending changes are here:",
                lstPendingChanges.Items.Count - 1);
        }

        private void lstPendingChanges_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index != 0) return;
            for (var i = 1; i < lstPendingChanges.Items.Count; i++)
            {
                lstPendingChanges.SetItemChecked(i, e.NewValue == CheckState.Checked);
            }
        }

        private void btnCheckin_Click(object sender, System.EventArgs e)
        {
            if (
                MessageBox.Show(
                    "Are you sure you want to check in all the selected items?\r\n\r\nIf there's a check in policy for any of these pending changes, it will be overwritten.",
                    "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    this.Checkin();

                    this.PopulatePendingChangesList();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(string.Format("There was an error checking in your changes:\r\n\r\n {0}", exception.Message), "Error commiting changes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Checkin()
        {
            var vcs = this._mainForm.GetVersionControlServer();

            var workspaces = vcs.QueryWorkspaces(null, vcs.AuthorizedUser, Environment.MachineName);

            foreach (var workspace in workspaces)
            {
                var pendingChanges = workspace.GetPendingChanges();

                var serverPaths = lstPendingChanges.CheckedItems.Cast<string>();

                var workspacePendingChanges =
                    pendingChanges.Where(
                        x => serverPaths.Contains(x.ServerItem)).ToArray();

                var evaluationResult = workspace.EvaluateCheckin(CheckinEvaluationOptions.Policies, null, workspacePendingChanges,
                    "Check-in made by TFS Checkout Notification", null, null);

                workspace.CheckIn(workspacePendingChanges, "Check-in made by TFS Checkout Notification", null, null,
                    !evaluationResult.PolicyFailures.Any()
                        ? null
                        : new PolicyOverrideInfo("Check-in made by TFS Checkout Notification",
                            evaluationResult.PolicyFailures));

                this._mainForm.QueryPendingChanges(true);
                this.PopulatePendingChangesList();
            }
        }

        private void lstPendingChanges_SelectedValueChanged(object sender, System.EventArgs e)
        {
            btnCheckin.Enabled = lstPendingChanges.CheckedItems.Count > 1;
            btnUndo.Enabled = lstPendingChanges.CheckedItems.Count > 1;
        }

        private void btnUndo_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to undo all the selected items?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    this.Undo();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(string.Format("There was an error undoing your changes: \r\n\r\n{0}", exception.Message), "Error undoing changes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Undo()
        {
            var vcs = this._mainForm.GetVersionControlServer();

            var workspaces = vcs.QueryWorkspaces(null, vcs.AuthorizedUser, Environment.MachineName);

            foreach (var workspace in workspaces)
            {
                var pendingChanges = workspace.GetPendingChanges();

                var serverPaths = lstPendingChanges.CheckedItems.Cast<string>();

                var workspacePendingChanges =
                    pendingChanges.Where(
                        x => serverPaths.Contains(x.ServerItem)).ToArray();

                workspace.Undo(workspacePendingChanges);

                this._mainForm.QueryPendingChanges(true);
                this.PopulatePendingChangesList();
            }
        }
    }
}
