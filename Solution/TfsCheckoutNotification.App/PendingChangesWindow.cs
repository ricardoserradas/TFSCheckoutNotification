using System.Windows.Forms;

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
            if (this._mainForm.PendingChanges.Count <= 0) return;
            lstPendingChanges.Items.Add("(Select  All)");

            foreach (var pendingChange in this._mainForm.PendingChanges)
            {
                lstPendingChanges.Items.Add(pendingChange.ServerPath);
            }
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
                MessageBox.Show("Checkin here");
            }
        }

        private void lstPendingChanges_SelectedValueChanged(object sender, System.EventArgs e)
        {
            btnCheckin.Enabled = lstPendingChanges.CheckedItems.Count > 0;
            btnUndo.Enabled = lstPendingChanges.CheckedItems.Count > 0;
        }

        private void btnUndo_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to undo all the selected items?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                MessageBox.Show("Undo here.");
            }
        }
    }
}
