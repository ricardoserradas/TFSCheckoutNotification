using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TfsCheckoutNotification.App
{
    public class Common
    {
        public static void TreatUnexpectedException(Exception exception, Form form)
        {
            EventLog.WriteEntry(EventLogSource, exception.Message, EventLogEntryType.Error);
            MessageBox.Show(
                "There was an unexpected error with TFS Checkout Notification and it needs to be closed. \r\n\r\nContact the author to notify him about the problem. There's a new Event Log entry that may help.",
                "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            form.Close();
        }

        public static string EventLogSource
        {
            get { return "TFS Checkout Notification"; }
        }
    }
}
