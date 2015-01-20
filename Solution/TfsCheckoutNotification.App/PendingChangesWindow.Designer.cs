namespace TfsCheckoutNotification.App
{
    partial class PendingChangesWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PendingChangesWindow));
            this.lstPendingChanges = new System.Windows.Forms.CheckedListBox();
            this.lblPendingChanges = new System.Windows.Forms.Label();
            this.btnCheckin = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstPendingChanges
            // 
            resources.ApplyResources(this.lstPendingChanges, "lstPendingChanges");
            this.lstPendingChanges.CheckOnClick = true;
            this.lstPendingChanges.FormattingEnabled = true;
            this.lstPendingChanges.Name = "lstPendingChanges";
            this.lstPendingChanges.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstPendingChanges_ItemCheck);
            this.lstPendingChanges.SelectedValueChanged += new System.EventHandler(this.lstPendingChanges_SelectedValueChanged);
            this.lstPendingChanges.DoubleClick += new System.EventHandler(this.lstPendingChanges_DoubleClick);
            // 
            // lblPendingChanges
            // 
            resources.ApplyResources(this.lblPendingChanges, "lblPendingChanges");
            this.lblPendingChanges.Name = "lblPendingChanges";
            // 
            // btnCheckin
            // 
            resources.ApplyResources(this.btnCheckin, "btnCheckin");
            this.btnCheckin.Name = "btnCheckin";
            this.btnCheckin.UseVisualStyleBackColor = true;
            this.btnCheckin.Click += new System.EventHandler(this.btnCheckin_Click);
            // 
            // btnUndo
            // 
            resources.ApplyResources(this.btnUndo, "btnUndo");
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRefresh
            // 
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // PendingChangesWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnCheckin);
            this.Controls.Add(this.lblPendingChanges);
            this.Controls.Add(this.lstPendingChanges);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PendingChangesWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lstPendingChanges;
        private System.Windows.Forms.Label lblPendingChanges;
        private System.Windows.Forms.Button btnCheckin;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRefresh;
    }
}