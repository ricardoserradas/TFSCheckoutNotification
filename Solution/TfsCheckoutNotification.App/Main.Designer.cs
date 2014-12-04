namespace TfsCheckoutNotification.App
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu_Configure = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_checkInterval = new System.Windows.Forms.Timer(this.components);
            this.timer_toast = new System.Windows.Forms.Timer(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_showPendingChanges = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipTitle = "TFS Checkout Notification";
            this.notifyIcon.ContextMenuStrip = this.contextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "TFS Checkout Notification";
            this.notifyIcon.Visible = true;
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_showPendingChanges,
            this.toolStripSeparator1,
            this.menu_Configure,
            this.menu_Exit});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(209, 98);
            // 
            // menu_Configure
            // 
            this.menu_Configure.Name = "menu_Configure";
            this.menu_Configure.Size = new System.Drawing.Size(208, 22);
            this.menu_Configure.Text = "Configure";
            this.menu_Configure.Click += new System.EventHandler(this.menu_Configure_Click);
            // 
            // menu_Exit
            // 
            this.menu_Exit.Name = "menu_Exit";
            this.menu_Exit.Size = new System.Drawing.Size(208, 22);
            this.menu_Exit.Text = "Exit";
            this.menu_Exit.Click += new System.EventHandler(this.menu_Exit_Click);
            // 
            // timer_checkInterval
            // 
            this.timer_checkInterval.Interval = 10000;
            this.timer_checkInterval.Tick += new System.EventHandler(this.timer_checkInterval_Tick);
            // 
            // timer_toast
            // 
            this.timer_toast.Enabled = true;
            this.timer_toast.Tick += new System.EventHandler(this.timer_toast_Tick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(205, 6);
            // 
            // menu_showPendingChanges
            // 
            this.menu_showPendingChanges.Name = "menu_showPendingChanges";
            this.menu_showPendingChanges.Size = new System.Drawing.Size(208, 22);
            this.menu_showPendingChanges.Text = "Show Pending Changes...";
            this.menu_showPendingChanges.Click += new System.EventHandler(this.menu_showPendingChanges_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menu_Configure;
        private System.Windows.Forms.ToolStripMenuItem menu_Exit;
        private System.Windows.Forms.Timer timer_checkInterval;
        private System.Windows.Forms.Timer timer_toast;
        private System.Windows.Forms.ToolStripMenuItem menu_showPendingChanges;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

