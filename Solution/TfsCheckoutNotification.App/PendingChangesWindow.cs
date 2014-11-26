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

            foreach (var pendingChange in this._mainForm.PendingChanges)
            {
                lstPendingChanges.Items.Add(pendingChange.ServerPath);
            }
        }
    }
}
