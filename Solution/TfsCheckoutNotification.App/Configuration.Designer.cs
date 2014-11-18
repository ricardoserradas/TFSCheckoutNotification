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
            this.btnChangeCollection = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCollection = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnChangeCollection
            // 
            this.btnChangeCollection.Location = new System.Drawing.Point(461, 4);
            this.btnChangeCollection.Name = "btnChangeCollection";
            this.btnChangeCollection.Size = new System.Drawing.Size(75, 23);
            this.btnChangeCollection.TabIndex = 0;
            this.btnChangeCollection.Text = "Change...";
            this.btnChangeCollection.UseVisualStyleBackColor = true;
            this.btnChangeCollection.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Collection to monitor:";
            // 
            // txtCollection
            // 
            this.txtCollection.Enabled = false;
            this.txtCollection.Location = new System.Drawing.Point(123, 6);
            this.txtCollection.Name = "txtCollection";
            this.txtCollection.Size = new System.Drawing.Size(332, 20);
            this.txtCollection.TabIndex = 2;
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 171);
            this.Controls.Add(this.txtCollection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChangeCollection);
            this.Name = "Configuration";
            this.Text = "Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChangeCollection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCollection;
    }
}