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
            this.SuspendLayout();
            // 
            // lstPendingChanges
            // 
            this.lstPendingChanges.FormattingEnabled = true;
            this.lstPendingChanges.Location = new System.Drawing.Point(12, 27);
            this.lstPendingChanges.Name = "lstPendingChanges";
            this.lstPendingChanges.Size = new System.Drawing.Size(698, 229);
            this.lstPendingChanges.TabIndex = 0;
            // 
            // lblPendingChanges
            // 
            this.lblPendingChanges.AutoSize = true;
            this.lblPendingChanges.Location = new System.Drawing.Point(12, 9);
            this.lblPendingChanges.Name = "lblPendingChanges";
            this.lblPendingChanges.Size = new System.Drawing.Size(171, 13);
            this.lblPendingChanges.TabIndex = 1;
            this.lblPendingChanges.Text = "All your pending changes are here:";
            // 
            // PendingChangesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 274);
            this.Controls.Add(this.lblPendingChanges);
            this.Controls.Add(this.lstPendingChanges);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PendingChangesWindow";
            this.Text = "TFS Checkout Notification - Pending Changes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lstPendingChanges;
        private System.Windows.Forms.Label lblPendingChanges;
    }
}