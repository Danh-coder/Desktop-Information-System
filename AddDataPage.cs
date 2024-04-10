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
    public partial class AddDataPage : UserControl
    {
        private TeachingStaffForm teachingStaffForm = new TeachingStaffForm();
        private AdminstrationForm adminstrationForm = new AdminstrationForm();
        private StudentForm studentForm = new StudentForm();

        public AddDataPage()
        {
            InitializeComponent();
            TeachingStaffForm teachingStaffForm = new TeachingStaffForm();
            addUserControl(teachingStaffForm);
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void addTeachingStaffBtn_Click(object sender, EventArgs e)
        {
            addUserControl(teachingStaffForm);
        }

        private void addAdministrationBtn_Click(object sender, EventArgs e)
        {
            addUserControl(adminstrationForm);
        }

        private void addStudentBtn_Click(object sender, EventArgs e)
        {
            addUserControl(studentForm);
        }
    }
}
