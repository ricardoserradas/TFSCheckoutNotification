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
            resources.ApplyResources(this.grpIntervalConfiguration, "grpIntervalConfiguration");
            this.grpIntervalConfiguration.Controls.Add(this.cmbIntervalType);
            this.grpIntervalConfiguration.Controls.Add(this.txtIntervalValue);
            this.grpIntervalConfiguration.Controls.Add(this.lblNotificationInterval);
            this.grpIntervalConfiguration.Name = "grpIntervalConfiguration";
            this.grpIntervalConfiguration.TabStop = false;
            // 
            // cmbIntervalType
            // 
            resources.ApplyResources(this.cmbIntervalType, "cmbIntervalType");
            this.cmbIntervalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIntervalType.FormattingEnabled = true;
            this.cmbIntervalType.Items.AddRange(new object[] {
            resources.GetString("cmbIntervalType.Items"),
            resources.GetString("cmbIntervalType.Items1")});
            this.cmbIntervalType.Name = "cmbIntervalType";
            // 
            // txtIntervalValue
            // 
            resources.ApplyResources(this.txtIntervalValue, "txtIntervalValue");
            this.txtIntervalValue.Name = "txtIntervalValue";
            // 
            // lblNotificationInterval
            // 
            resources.ApplyResources(this.lblNotificationInterval, "lblNotificationInterval");
            this.lblNotificationInterval.Name = "lblNotificationInterval";
            // 
            // txtCollection
            // 
            resources.ApplyResources(this.txtCollection, "txtCollection");
            this.txtCollection.Name = "txtCollection";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnChangeCollection
            // 
            resources.ApplyResources(this.btnChangeCollection, "btnChangeCollection");
            this.btnChangeCollection.Name = "btnChangeCollection";
            this.btnChangeCollection.UseVisualStyleBackColor = true;
            this.btnChangeCollection.Click += new System.EventHandler(this.btnChangeCollection_Click);
            // 
            // grpMonitorType
            // 
            resources.ApplyResources(this.grpMonitorType, "grpMonitorType");
            this.grpMonitorType.Controls.Add(this.rdMonitorVisualStudio);
            this.grpMonitorType.Controls.Add(this.rdMonitorInterval);
            this.grpMonitorType.Name = "grpMonitorType";
            this.grpMonitorType.TabStop = false;
            // 
            // rdMonitorVisualStudio
            // 
            resources.ApplyResources(this.rdMonitorVisualStudio, "rdMonitorVisualStudio");
            this.rdMonitorVisualStudio.Name = "rdMonitorVisualStudio";
            this.rdMonitorVisualStudio.TabStop = true;
            this.rdMonitorVisualStudio.UseVisualStyleBackColor = true;
            // 
            // rdMonitorInterval
            // 
            resources.ApplyResources(this.rdMonitorInterval, "rdMonitorInterval");
            this.rdMonitorInterval.Name = "rdMonitorInterval";
            this.rdMonitorInterval.TabStop = true;
            this.rdMonitorInterval.UseVisualStyleBackColor = true;
            this.rdMonitorInterval.CheckedChanged += new System.EventHandler(this.rdMonitorType_CheckedChanged);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Configuration
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpMonitorType);
            this.Controls.Add(this.txtCollection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChangeCollection);
            this.Controls.Add(this.grpIntervalConfiguration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configuration";
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