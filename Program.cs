using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Information_System
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // Init database
                Controller.Init();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Homepage());
            }
            catch (SqlException ex)
            {   // Database errors
                MessageBox.Show("SQL Error: " + ex.Message.ToString(), caption: "Error Detected", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {   // Other errors
                MessageBox.Show(ex.Message.ToString(), caption: "Error Detected", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
            
        }
    }
}
