using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace TfsCheckoutNotification.App
{
    public class Common
    {
        public static ResourceManager ResourceManager = new ResourceManager("TfsCheckoutNotification.App.Resources", typeof(Common).Assembly);

        public static void TreatUnexpectedException(Exception exception, Form form)
        {
            EventLog.WriteEntry(EventLogSource, exception.Message, EventLogEntryType.Error);
            MessageBox.Show(
                ResourceManager.GetString("Common_UnexpectedException"),
                ResourceManager.GetString("Main_ErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            form.Close();
        }

        public static string EventLogSource
        {
            get { return "TFS Checkout Notification"; }
        }
    }
}
