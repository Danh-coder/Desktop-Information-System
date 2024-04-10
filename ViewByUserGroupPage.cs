using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Information_System
{
    public partial class ViewByUserGroupPage : UserControl
    {
        public ViewByUserGroupPage()
        {
            InitializeComponent();
            ViewTeachingStaff viewTeachingStaff = new ViewTeachingStaff();
            addUserControl(viewTeachingStaff);
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void viewTeachingStaffBtn_Click(object sender, EventArgs e)
        {
            ViewTeachingStaff viewTeachingStaff = new ViewTeachingStaff();
            addUserControl(viewTeachingStaff);
        }

        private void viewAdministrationBtn_Click(object sender, EventArgs e)
        {
            ViewAdministration viewAdministration = new ViewAdministration();
            addUserControl(viewAdministration);
        }

        private void viewStudentBtn_Click(object sender, EventArgs e)
        {
            ViewStudent viewStudent = new ViewStudent();
            addUserControl(viewStudent);
        }
    }
}
