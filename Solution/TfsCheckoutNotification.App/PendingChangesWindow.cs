using System;
using System.Diagnostics;
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
            

            try
            {
                InitializeComponent();

                this._mainForm = (Main)Application.OpenForms["Main"];

                if (this._mainForm == null)
                {
                    MessageBox.Show(Common.ResourceManager.GetString("PendingChanges_ErrorLoadingInfo"));
                    this.Close();
                }

                PopulatePendingChangesList();
            }
            catch (Exception exception)
            {
                Common.TreatUnexpectedException(exception, this);
            }
        }

        private void PopulatePendingChangesList()
        {
            try
            {
                lstPendingChanges.Items.Clear();

                lstPendingChanges.Items.Add("(Select All)");

                foreach (var pendingChange in this._mainForm.PendingChanges)
                {
                    lstPendingChanges.Items.Add(pendingChange.ServerPath);
                }

                lblPendingChanges.Text = (lstPendingChanges.Items.Count - 1) == 0
                    ? Common.ResourceManager.GetString("PendingChanges_AllYourPendingChangesEmpty")
                    : string.Format(Common.ResourceManager.GetString("PendingChanges_AllYourPendingChanges"),
                        lstPendingChanges.Items.Count - 1);
            }
            catch (Exception exception)
            {
                Common.TreatUnexpectedException(exception, this);
            }
        }

        private void lstPendingChanges_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                if (e.Index != 0) return;
                for (var i = 1; i < lstPendingChanges.Items.Count; i++)
                {
                    lstPendingChanges.SetItemChecked(i, e.NewValue == CheckState.Checked);
                }
            }
            catch (Exception exception)
            {
                Common.TreatUnexpectedException(exception, this);
            }
        }

        private void btnCheckin_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                        MessageBox.Show(
                            Common.ResourceManager.GetString("PendingChanges_CheckInConfirmation"),
                            Common.ResourceManager.GetString("PendingChange_ConfirmationTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        this.Checkin();

                        this.PopulatePendingChangesList();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(string.Format(Common.ResourceManager.GetString("PendingChange_ErrorCheckingIn"), exception.Message), Common.ResourceManager.GetString("PendingChange_ErrorCheckingInTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exception)
            {
                Common.TreatUnexpectedException(exception, this);
            }
        }

        private void Checkin()
        {
            try
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
                        Common.ResourceManager.GetString("PendingChange_CheckInComment"), null, null);

                    workspace.CheckIn(workspacePendingChanges, Common.ResourceManager.GetString("PendingChange_CheckInComment"), null, null,
                        !evaluationResult.PolicyFailures.Any()
                            ? null
                            : new PolicyOverrideInfo(Common.ResourceManager.GetString("PendingChange_CheckInComment"),
                                evaluationResult.PolicyFailures));

                    this.RefreshPendingChanges();
                }
            }
            catch (Exception exception)
            {
                Common.TreatUnexpectedException(exception, this);
            }
        }

        private void lstPendingChanges_SelectedValueChanged(object sender, EventArgs e)
        {
            CheckButtonsState();
        }

        private void CheckButtonsState()
        {
            try
            {
                var hasToCheck = lstPendingChanges.CheckedItems.Count >= 1 && lstPendingChanges.Items.Count > 1;

                btnCheckin.Enabled = hasToCheck;
                btnUndo.Enabled = hasToCheck;
            }
            catch (Exception exception)
            {
                Common.TreatUnexpectedException(exception, this);
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Common.ResourceManager.GetString("PendingChange_UndoConfirmation"), Common.ResourceManager.GetString("PendingChange_ConfirmationTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    this.Undo();
                }
                catch (Exception exception)
                {
                    EventLog.WriteEntry(Common.EventLogSource, exception.Message, EventLogEntryType.Error);
                    MessageBox.Show(string.Format(Common.ResourceManager.GetString("PendingChange_ErrorUndoing"), exception.Message), Common.ResourceManager.GetString("PendingChanges_ErrorUndoingTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Undo()
        {
            try
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

                    this.RefreshPendingChanges();
                }
            }
            catch (Exception exception)
            {
                Common.TreatUnexpectedException(exception, this);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshPendingChanges();
        }

        private void RefreshPendingChanges()
        {
            this._mainForm.QueryPendingChanges(true);
            this.PopulatePendingChangesList();

            this.CheckButtonsState();
        }

        private void lstPendingChanges_DoubleClick(object sender, EventArgs e)
        {
            this.CheckButtonsState();
        }
    }
}
