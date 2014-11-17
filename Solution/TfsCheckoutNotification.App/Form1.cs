using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TfsCheckoutNotification.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.notifyIcon.BalloonTipText = string.Format("You have {0} pending checkin(s)", 2);
            this.notifyIcon.ShowBalloonTip(3);
        }

        private void menu_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
