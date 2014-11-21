namespace TfsCheckoutNotification.App
{
    partial class Configuration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.grpIntervalConfiguration = new System.Windows.Forms.GroupBox();
            this.cmbIntervalType = new System.Windows.Forms.ComboBox();
            this.txtIntervalValue = new System.Windows.Forms.TextBox();
            this.lblNotificationInterval = new System.Windows.Forms.Label();
            this.txtCollection = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangeCollection = new System.Windows.Forms.Button();
            this.grpMonitorType = new System.Windows.Forms.GroupBox();
            this.rdMonitorVisualStudio = new System.Windows.Forms.RadioButton();
            this.rdMonitorInterval = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpIntervalConfiguration.SuspendLayout();
            this.grpMonitorType.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpIntervalConfiguration
            // 
            this.grpIntervalConfiguration.Controls.Add(this.cmbIntervalType);
            this.grpIntervalConfiguration.Controls.Add(this.txtIntervalValue);
            this.grpIntervalConfiguration.Controls.Add(this.lblNotificationInterval);
            this.grpIntervalConfiguration.Location = new System.Drawing.Point(20, 103);
            this.grpIntervalConfiguration.Name = "grpIntervalConfiguration";
            this.grpIntervalConfiguration.Size = new System.Drawing.Size(521, 60);
            this.grpIntervalConfiguration.TabIndex = 6;
            this.grpIntervalConfiguration.TabStop = false;
            this.grpIntervalConfiguration.Text = "Interval Configuration";
            // 
            // cmbIntervalType
            // 
            this.cmbIntervalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIntervalType.FormattingEnabled = true;
            this.cmbIntervalType.Items.AddRange(new object[] {
            "hour",
            "minute"});
            this.cmbIntervalType.Location = new System.Drawing.Point(204, 26);
            this.cmbIntervalType.Name = "cmbIntervalType";
            this.cmbIntervalType.Size = new System.Drawing.Size(118, 21);
            this.cmbIntervalType.TabIndex = 11;
            // 
            // txtIntervalValue
            // 
            this.txtIntervalValue.Location = new System.Drawing.Point(144, 26);
            this.txtIntervalValue.Name = "txtIntervalValue";
            this.txtIntervalValue.Size = new System.Drawing.Size(54, 20);
            this.txtIntervalValue.TabIndex = 10;
            // 
            // lblNotificationInterval
            // 
            this.lblNotificationInterval.AutoSize = true;
            this.lblNotificationInterval.Location = new System.Drawing.Point(6, 29);
            this.lblNotificationInterval.Name = "lblNotificationInterval";
            this.lblNotificationInterval.Size = new System.Drawing.Size(133, 13);
            this.lblNotificationInterval.TabIndex = 9;
            this.lblNotificationInterval.Text = "Check and notify me every";
            // 
            // txtCollection
            // 
            this.txtCollection.Enabled = false;
            this.txtCollection.Location = new System.Drawing.Point(128, 12);
            this.txtCollection.Name = "txtCollection";
            this.txtCollection.Size = new System.Drawing.Size(332, 20);
            this.txtCollection.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Collection to monitor:";
            // 
            // btnChangeCollection
            // 
            this.btnChangeCollection.Location = new System.Drawing.Point(466, 10);
            this.btnChangeCollection.Name = "btnChangeCollection";
            this.btnChangeCollection.Size = new System.Drawing.Size(75, 23);
            this.btnChangeCollection.TabIndex = 9;
            this.btnChangeCollection.Text = "Change...";
            this.btnChangeCollection.UseVisualStyleBackColor = true;
            this.btnChangeCollection.Click += new System.EventHandler(this.btnChangeCollection_Click);
            // 
            // grpMonitorType
            // 
            this.grpMonitorType.Controls.Add(this.rdMonitorVisualStudio);
            this.grpMonitorType.Controls.Add(this.rdMonitorInterval);
            this.grpMonitorType.Location = new System.Drawing.Point(20, 51);
            this.grpMonitorType.Name = "grpMonitorType";
            this.grpMonitorType.Size = new System.Drawing.Size(521, 46);
            this.grpMonitorType.TabIndex = 12;
            this.grpMonitorType.TabStop = false;
            this.grpMonitorType.Text = "Monitor Type";
            // 
            // rdMonitorVisualStudio
            // 
            this.rdMonitorVisualStudio.AutoSize = true;
            this.rdMonitorVisualStudio.Location = new System.Drawing.Point(167, 19);
            this.rdMonitorVisualStudio.Name = "rdMonitorVisualStudio";
            this.rdMonitorVisualStudio.Size = new System.Drawing.Size(195, 17);
            this.rdMonitorVisualStudio.TabIndex = 14;
            this.rdMonitorVisualStudio.TabStop = true;
            this.rdMonitorVisualStudio.Text = "Notify me when Visual Studio closes";
            this.rdMonitorVisualStudio.UseVisualStyleBackColor = true;
            // 
            // rdMonitorInterval
            // 
            this.rdMonitorInterval.AutoSize = true;
            this.rdMonitorInterval.Location = new System.Drawing.Point(6, 19);
            this.rdMonitorInterval.Name = "rdMonitorInterval";
            this.rdMonitorInterval.Size = new System.Drawing.Size(112, 17);
            this.rdMonitorInterval.TabIndex = 13;
            this.rdMonitorInterval.TabStop = true;
            this.rdMonitorInterval.Text = "Monitor by Interval";
            this.rdMonitorInterval.UseVisualStyleBackColor = true;
            this.rdMonitorInterval.CheckedChanged += new System.EventHandler(this.rdMonitorType_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(203, 169);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(284, 169);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 200);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpMonitorType);
            this.Controls.Add(this.txtCollection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChangeCollection);
            this.Controls.Add(this.grpIntervalConfiguration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configuration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration - TFS Checkout Notification";
            this.grpIntervalConfiguration.ResumeLayout(false);
            this.grpIntervalConfiguration.PerformLayout();
            this.grpMonitorType.ResumeLayout(false);
            this.grpMonitorType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpIntervalConfiguration;
        private System.Windows.Forms.ComboBox cmbIntervalType;
        private System.Windows.Forms.TextBox txtIntervalValue;
        private System.Windows.Forms.Label lblNotificationInterval;
        private System.Windows.Forms.TextBox txtCollection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChangeCollection;
        private System.Windows.Forms.GroupBox grpMonitorType;
        private System.Windows.Forms.RadioButton rdMonitorVisualStudio;
        private System.Windows.Forms.RadioButton rdMonitorInterval;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

    }
}